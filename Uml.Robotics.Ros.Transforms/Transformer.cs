using System;
using System.Collections.Generic;
using System.Threading;
using Messages.std_msgs;
using Messages.tf;
using Messages.geometry_msgs;

namespace Uml.Robotics.Ros.Transforms
{
    public class Transformer
    {
        private const string tf_prefix = "/";
        private const uint MAX_GRAPH_DEPTH = 100;
        private const double DEFAULT_CACHE_TIME = 1000000000;
        private const ulong DEFAULT_MAX_EXTRAPOLATION_DISTANCE = 0;
        private ulong cache_time;

        private Dictionary<string, uint> frameIDs = new Dictionary<string, uint>();
        private Dictionary<uint, string> frameids_reverse = new Dictionary<uint, string>();
        private Dictionary<uint, TimeCache> frames = new Dictionary<uint, TimeCache>();

        private bool interpolating;
        private NodeHandle nh;

        private void InitNodeHandle()
        {
            nh = new NodeHandle();
            nh.Subscribe<tfMessage>("/tf", 0, Update);
            nh.Subscribe<tfMessage>("/tf_static", 0, Update);
        }

        public Transformer(bool interpolating = true, ulong ct = (ulong)DEFAULT_CACHE_TIME)
        {
            frameIDs["NO_PARENT"] = 0;
            frameids_reverse[0] = "NO_PARENT";
            InitNodeHandle();
            this.interpolating = interpolating;
            cache_time = ct;
        }

        private void Update(tfMessage msg)
        {
            foreach (TransformStamped tf in msg.transforms)
                if (!setTransform(new Transform(tf)))
                    ROS.Warn()("Failed to setTransform in transformer update function");
        }

        public static string resolve(string prefix, string frame_name)
        {
            if (frame_name.Length > 0)
            {
                if (frame_name[0] == '/')
                    return frame_name;
            }
            if (prefix.Length > 0)
            {
                if (prefix[0] == '/' && prefix.Length == 1)
                    return "/" + frame_name;
                if (prefix[0] == '/')
                    return prefix + "/" + frame_name;
                return "/" + prefix + "/" + frame_name;
            }
            return "/" + frame_name;
        }

        public void clear()
        {
            foreach (TimeCache tc in frames.Values)
                tc.ClearList();
            frameIDs.Clear();
            frameids_reverse.Clear();
        }

        private uint getFrameIDInternal(string frame)
        {
            uint value;
            if (frameIDs.TryGetValue(frame, out value))
            {
                return value;
            }
            return 0;
        }

        public uint getFrameID(string frame)
        {
            return getFrameIDInternal(frame);
        }

        public bool frameExists(string frame)
        {
            return getFrameID(frame) != 0;
        }

        private bool frameExistsInternal(string frame)
        {
            return getFrameIDInternal(frame) != 0;
        }

        public bool lookupTransform(string target_frame, string source_frame, Time time, out Transform transform)
        {
            bool result = lookupTransform(target_frame, source_frame, time, out transform, out string error_string);
            if (!result && error_string != null)
                ROS.Error()(error_string);
            return result;
        }

        public bool lookupTransform(string target_frame, string source_frame, Time time, out Transform transform, out string error_string)
        {
            transform = null;
            error_string = null;

            string mapped_tgt = resolve(tf_prefix, target_frame);
            string mapped_src = resolve(tf_prefix, source_frame);

            if (mapped_tgt == mapped_src)
            {
                transform = new Transform();
                transform.Origin = new Vector3();
                transform.Basis = new Quaternion();
                transform.ChildFrameId = mapped_src;
                transform.FrameId = mapped_tgt;
                transform.Stamp = DateTime.UtcNow.ToTimeMessage();
                return true;
            }

            TfStatus retval;
            uint target_id = getFrameIDInternal(mapped_tgt);
            uint source_id = getFrameIDInternal(mapped_src);

            TransformAccum accum = new TransformAccum();

            retval = walkToTopParent(accum, TimeCache.ToLong(time.data), target_id, source_id, out error_string);
            if (retval != TfStatus.NoError)
            {
                error_string = error_string ?? "UNSPECIFIED";
                switch (retval)
                {
                    case TfStatus.ConnectivityError:
                        error_string = "NO CONNECTION: " + error_string;
                        break;
                    case TfStatus.ExtrapolationError:
                        error_string = "EXTRAPOLATION: " + error_string;
                        break;
                    case TfStatus.LookupError:
                        error_string = "LOOKUP: " + error_string;
                        break;
                    default:
                        if (accum.result_quat == null || accum.result_vec == null)
                        {
                            error_string = "ACCUM WALK FAIL!";
                        }
                        break;
                }
            }
            if (accum.result_vec != null && accum.result_quat != null)
            {
                transform = new Transform();
                transform.Origin = accum.result_vec;
                transform.Basis = accum.result_quat;
                transform.ChildFrameId = mapped_src;
                transform.FrameId = mapped_tgt;
                transform.Stamp = new Time(TimeData.FromTicks((long)accum.time));
            }
            return retval == TfStatus.NoError;
        }

        public void transformQuaternion(string target_frame, Stamped<Quaternion> stamped_in, ref Stamped<Quaternion> stamped_out)
        {
            Transform trans = new Transform();
            lookupTransform(target_frame, stamped_in.FrameId, stamped_in.Stamp, out trans);
            if (stamped_out == null)
                stamped_out = new Stamped<Quaternion>();
            stamped_out.Data = trans * stamped_in.Data;
            stamped_out.Stamp = trans.Stamp;
            stamped_out.FrameId = target_frame;
        }

        public void transformQuaternion(string target_frame, Stamped<Messages.geometry_msgs.Quaternion> stamped_in,
            ref Stamped<Messages.geometry_msgs.Quaternion> stamped_out)
        {
            Stamped<Quaternion> quatin = new Stamped<Quaternion>(stamped_in.Stamp, stamped_in.FrameId, new Quaternion(stamped_in.Data));
            Stamped<Quaternion> quatout = new Stamped<Quaternion>(stamped_out.Stamp, stamped_out.FrameId, new Quaternion(stamped_out.Data));
            transformQuaternion(target_frame, quatin, ref quatout);
            if (stamped_out == null)
                stamped_out = new Stamped<Messages.geometry_msgs.Quaternion>();
            stamped_out.Stamp = quatout.Stamp;
            stamped_out.Data = quatout.Data.ToMsg();
            stamped_out.FrameId = quatout.FrameId;
        }

        public void transformVector(string target_frame, Stamped<Vector3> stamped_in, ref Stamped<Vector3> stamped_out)
        {
            Transform trans = new Transform();
            lookupTransform(target_frame, stamped_in.FrameId, stamped_in.Stamp, out trans);
            Vector3 end = stamped_in.Data;
            Vector3 origin = new Vector3(0, 0, 0);
            Vector3 output = (trans * end) - (trans * origin);
            if (stamped_out == null)
                stamped_out = new Stamped<Vector3>();
            stamped_out.Data = output;
            stamped_out.Stamp = trans.Stamp;
            stamped_out.FrameId = target_frame;
        }

        public void transformVector(string target_frame, Stamped<Messages.geometry_msgs.Vector3> stamped_in,
            ref Stamped<Messages.geometry_msgs.Vector3> stamped_out)
        {
            Stamped<Vector3> vecin = new Stamped<Vector3>(stamped_in.Stamp, stamped_in.FrameId, new Vector3(stamped_in.Data));
            Stamped<Vector3> vecout = new Stamped<Vector3>(stamped_out.Stamp, stamped_out.FrameId, new Vector3(stamped_out.Data));
            transformVector(target_frame, vecin, ref vecout);
            if (stamped_out == null)
                stamped_out = new Stamped<Messages.geometry_msgs.Vector3>();
            stamped_out.Stamp = vecout.Stamp;
            stamped_out.Data = vecout.Data.ToMsg();
            stamped_out.FrameId = vecout.FrameId;
        }

        public TfStatus walkToTopParent<F>(F f, ulong time, uint target_id, uint source_id, out string error_str) where F : ATransformAccum
        {
            error_str = null;

            if (target_id == source_id)
            {
                f.Finalize(WalkEnding.Identity, time);
                return TfStatus.NoError;
            }
            if (time == 0)
            {
                TfStatus retval = getLatestCommonTime(target_id, source_id, ref time, out error_str);
                if (retval != TfStatus.NoError)
                    return retval;
            }
            uint frame = source_id;
            uint top_parent = frame;
            uint depth = 0;

            var extrapolationErrorMightHaveOccurred = false;
            string extrapolationErrorString = null;
            while (frame != 0)
            {
                if (!frames.ContainsKey(frame))
                {
                    top_parent = frame;
                    break;
                }
                TimeCache cache = frames[frame];
                uint parent = f.Gather(cache, time, out extrapolationErrorString);
                if (parent == 0)
                {
                    top_parent = frame;
                    extrapolationErrorMightHaveOccurred = true;
                    break;
                }

                if (frame == target_id)
                {
                    f.Finalize(WalkEnding.TargetParentOfSource, time);
                    error_str = null;
                    return TfStatus.NoError;
                }

                f.Accum(true);

                top_parent = frame;
                frame = parent;
                ++depth;
                if (depth > MAX_GRAPH_DEPTH)
                {
                    if (error_str != null)
                    {
                        error_str = "The tf tree is invalid because it contains a loop.";
                    }
                    return TfStatus.LookupError;
                }
            }

            frame = target_id;
            depth = 0;
            while (frame != top_parent)
            {
                if (!frames.ContainsKey(frame))
                    break;
                TimeCache cache = frames[frame];

                uint parent = f.Gather(cache, time, out error_str);

                if (parent == 0)
                {
                    if (error_str != null)
                    {
                        error_str += ", when looking up transform from frame [" + frameids_reverse[source_id] + "] to [" + frameids_reverse[target_id] + "]";
                    }
                    return TfStatus.ExtrapolationError;
                }

                if (frame == source_id)
                {
                    f.Finalize(WalkEnding.SourceParentOfTarget, time);
                    error_str = null;
                    return TfStatus.NoError;
                }

                f.Accum(false);

                frame = parent;
                ++depth;
                if (depth > MAX_GRAPH_DEPTH)
                {
                    if (error_str != null)
                    {
                        error_str = "The tf tree is invalid because it contains a loop.";
                    }
                    return TfStatus.LookupError;
                }
            }

            if (frame != top_parent)
            {
                if (extrapolationErrorMightHaveOccurred)
                {
                    if (extrapolationErrorString != null)
                    {
                        error_str = extrapolationErrorString + ", when looking up transform from frame [" + frameids_reverse[source_id] + "] to [" + frameids_reverse[target_id] + "]";
                    }
                }
                
                error_str = "" + frameids_reverse[source_id] + " DOES NOT CONNECT TO " + frameids_reverse[target_id];
                return TfStatus.ConnectivityError;
            }

            f.Finalize(WalkEnding.FullPath, time);
            error_str = null;
            return TfStatus.NoError;
        }

        private TfStatus getLatestCommonTime(uint target_id, uint source_id, ref ulong time, out string error_str)
        {
            error_str = null;
            if (target_id == source_id)
            {
                time = TimeCache.ToLong(ROS.GetTime().data);
                return TfStatus.NoError;
            }

            List<TimeAndFrameId> lct = new List<TimeAndFrameId>();

            uint frame = source_id;
            uint depth = 0;
            ulong common_time = ulong.MaxValue;
            while (frame != 0)
            {
                TimeCache cache;
                if (!frames.ContainsKey(frame)) break;
                cache = frames[frame];
                TimeAndFrameId latest = cache.GetLatestTimeAndParent();
                if (latest.FrameId == 0)
                    break;
                if (latest.Time != 0)
                    common_time = Math.Min(latest.Time, common_time);
                lct.Add(latest);
                frame = latest.FrameId;
                if (frame == target_id)
                {
                    time = common_time;
                    if (time == ulong.MaxValue)
                        time = 0;
                    return TfStatus.NoError;
                }
                ++depth;
                if (depth > MAX_GRAPH_DEPTH)
                {
                    if (error_str != null)
                    {
                        error_str = "The tf tree is invalid because it contains a loop.";
                    }
                    return TfStatus.LookupError;
                }
            }

            frame = target_id;
            depth = 0;
            common_time = ulong.MaxValue;
            uint common_parent = 0;
            while (true)
            {
                TimeCache cache;
                if (!frames.ContainsKey(frame))
                    break;
                cache = frames[frame];
                TimeAndFrameId latest = cache.GetLatestTimeAndParent();
                if (latest.FrameId == 0)
                    break;
                if (latest.Time != 0)
                    common_time = Math.Min(latest.Time, common_time);

                foreach (TimeAndFrameId tf in lct)
                    if (tf.FrameId == latest.FrameId)
                    {
                        common_parent = tf.FrameId;
                        break;
                    }
                frame = latest.FrameId;

                if (frame == source_id)
                {
                    time = common_time;
                    if (time == uint.MaxValue)
                    {
                        time = 0;
                    }
                    return TfStatus.NoError;
                }
                ++depth;
                if (depth > MAX_GRAPH_DEPTH)
                {
                    if (error_str != null)
                    {
                        error_str = "The tf tree is invalid because it contains a loop.";
                    }
                    return TfStatus.LookupError;
                }
            }
            if (common_parent == 0)
            {
                error_str = "" + frameids_reverse[source_id] + " DOES NOT CONNECT TO " + frameids_reverse[target_id];
                return TfStatus.ConnectivityError;
            }
            for (int i = 0; i < lct.Count; i++)
            {
                if (lct[i].Time != 0)
                    common_time = Math.Min(common_time, lct[i].Time);
                if (lct[i].FrameId == common_parent)
                    break;
            }
            if (common_time == uint.MaxValue)
                common_time = 0;
            time = common_time;
            return TfStatus.NoError;
        }

        public uint lookupOrInsertFrameNumber(string frame)
        {
            if (!frameIDs.ContainsKey(frame))
            {
                frameIDs[frame] = (uint)(frameIDs.Count + 1);
                frameids_reverse[(uint)frameids_reverse.Count + 1] = frame;
            }
            return frameIDs[frame];
        }

        public bool setTransform(Transform transform)
        {
            Transform mapped_transform = new Transform(transform.Basis, transform.Origin, transform.Stamp, transform.FrameId, transform.ChildFrameId);
            mapped_transform.ChildFrameId = resolve(tf_prefix, transform.ChildFrameId);
            mapped_transform.FrameId = resolve(tf_prefix, transform.FrameId);

            if (mapped_transform.ChildFrameId == mapped_transform.FrameId)
                return false;
            if (mapped_transform.ChildFrameId == "/")
                return false;
            if (mapped_transform.FrameId == "/")
                return false;
            uint frame_number = lookupOrInsertFrameNumber(mapped_transform.FrameId);
            uint child_frame_number = lookupOrInsertFrameNumber(mapped_transform.ChildFrameId);
            TimeCache parent_frame = null, frame = null;
            if (!frames.ContainsKey(frame_number))
            {
                parent_frame = frames[frame_number] = new TimeCache(cache_time);
            }
            if (!frames.ContainsKey(child_frame_number))
            {
                frame = frames[child_frame_number] = new TimeCache(cache_time);
            }
            else
            {
                //if we're revising a frame, that was previously labelled as having no parent, clear that knowledge from the time cache
                frame = frames[child_frame_number];
            }
            return frame.InsertData(new TransformStorage(mapped_transform, frame_number, child_frame_number));
        }

        public bool waitForTransform(string target_frame, string source_frame, Time time, Duration timeout, out string error_msg)
        {
            return waitForTransform(target_frame, source_frame, time, timeout, out error_msg, null);
        }

        public bool waitForTransform(string target_frame, Time target_time, string source_frame, Time source_time, Duration timeout, out string error_msg)
        {
            return waitForTransform(target_frame, target_time, source_frame, source_time, timeout, out error_msg, null);
        }

        public bool waitForTransform(string target_frame, Time target_time, string source_frame, Time source_time, Duration timeout, out string error_msg, Duration pollingSleepDuration)
        {
            return waitForTransform(target_frame, source_frame, target_time, timeout, out error_msg, pollingSleepDuration) &&
                   waitForTransform(target_frame, source_frame, source_time, timeout, out error_msg, pollingSleepDuration);
        }

        public bool waitForTransform(string target_frame, string source_frame, Time time, Duration timeout, out string error_msg, Duration pollingSleepDuration)
        {
            TimeSpan? ts = null;
            if (pollingSleepDuration != null)
                ts = pollingSleepDuration.ToTimeSpan();
            return waitForTransform(target_frame, source_frame, time,
                timeout.ToTimeSpan(),
                out error_msg, ts);
        }

        private bool waitForTransform(string target_frame, string source_frame, Time time, TimeSpan timeout, out string error_msg, TimeSpan? pollingSleepDuration)
        {
            if (pollingSleepDuration == null)
                pollingSleepDuration = new TimeSpan(0, 0, 0, 0, 100);
            DateTime start_time = DateTime.UtcNow;
            string mapped_target = resolve(tf_prefix, target_frame);
            string mapped_source = resolve(tf_prefix, source_frame);

            do
            {
                if (canTransform(mapped_target, mapped_source, time, out error_msg))
                    return true;
                if (!ROS.OK || !(DateTime.UtcNow.Subtract(start_time).TotalMilliseconds < timeout.TotalMilliseconds))
                    break;
                Thread.Sleep(pollingSleepDuration.Value);
            } while (ROS.OK && (DateTime.UtcNow.Subtract(start_time).TotalMilliseconds < timeout.TotalMilliseconds));
            return false;
        }

        public bool waitForTransform(string target_frame, string source_frame, Time time, Duration timeout, Duration pollingSleepDuration)
        {
            string error_msg = null;
            return waitForTransform(target_frame, source_frame, time, timeout, out error_msg, pollingSleepDuration);
        }

        public bool waitForTransform(string target_frame, Time target_time, string source_frame, Time source_time, Duration timeout, Duration pollingSleepDuration)
        {
            string error_msg = null;
            return waitForTransform(target_frame, target_time, source_frame, source_time, timeout, out error_msg, pollingSleepDuration);
        }

        private bool waitForTransform(string target_frame, string source_frame, Time time, TimeSpan timeout, TimeSpan? pollingSleepDuration)
        {
            string error_msg = null;
            return waitForTransform(target_frame, source_frame, time, timeout, out error_msg, pollingSleepDuration);
        }

        private bool canTransform(string target_frame, Time target_time, string source_frame, Time source_time, out string error_msg)
        {
            return canTransform(target_frame, source_frame, target_time, out error_msg) && canTransform(target_frame, source_frame, source_time, out error_msg);
        }

        private bool canTransform(string target_frame, string source_frame, Time time, out string error_msg)
        {
            error_msg = null;
            string mapped_target = resolve(tf_prefix, target_frame);
            string mapped_source = resolve(tf_prefix, source_frame);
            if (mapped_target == mapped_source)
                return true;

            if (!frameExistsInternal(mapped_target) || !frameExistsInternal(mapped_source))
                return false;

            uint target_id = getFrameIDInternal(mapped_target);
            uint source_id = getFrameIDInternal(mapped_source);
            return canTransformNoLock(target_id, source_id, time, out error_msg);
        }

        private bool canTransformNoLock(uint target_id, uint source_id, Time time, out string error_msg)
        {
            error_msg = null;
            if (target_id == 0 || source_id == 0)
                return false;

            CanTransformAccum accum = new CanTransformAccum();
            if (walkToTopParent(accum, TimeCache.ToLong(time.data), target_id, source_id, out error_msg) == TfStatus.NoError)
            {
                return true;
            }
            return false;
        }

        private bool canTransformInternal(uint target_id, uint source_id, Time time, out string error_msg)
        {
            return canTransformNoLock(target_id, source_id, time, out error_msg);
        }
    }
}
