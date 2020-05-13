using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uml.Robotics.Ros;

namespace Uml.Robotics.Ros.Transforms
{
    public abstract class ATransformAccum
    {
        public TransformStorage st;
        public abstract uint Gather(TimeCache cache, ulong time, out string errorMessage);
        public abstract void Accum(bool source);
        public abstract void Finalize(WalkEnding end, ulong time);
    }

    public class CanTransformAccum : ATransformAccum
    {
        public override uint Gather(TimeCache cache, ulong time, out string errorMessage)
        {
            return cache.GetParent(time, out errorMessage);
        }

        public override void Accum(bool source)
        {
        }

        public override void Finalize(WalkEnding end, ulong time)
        {
        }
    }

    public class TransformAccum : ATransformAccum
    {
        public Quaternion result_quat;
        public Vector3 result_vec;
        public Quaternion source_to_top_quat = new Quaternion();
        public Vector3 source_to_top_vec = new Vector3();
        public Quaternion target_to_top_quat = new Quaternion();
        public Vector3 target_to_top_vec = new Vector3();
        public ulong time;

        public override uint Gather(TimeCache cache, ulong time, out string errorMessage)
        {
            if (!cache.GetData(time, ref st, out errorMessage))
                return 0;
            return st.FrameId;
        }

        public override void Finalize(WalkEnding end, ulong time)
        {
            switch (end)
            {
                case WalkEnding.Identity:
                    break;
                case WalkEnding.TargetParentOfSource:
                    result_vec = source_to_top_vec;
                    result_quat = source_to_top_quat;
                    break;
                case WalkEnding.SourceParentOfTarget:
                    {
                        Quaternion inv_target_quat = target_to_top_quat.Inverse();
                        Vector3 inv_target_vec = QuatRotate(inv_target_quat, -1 * target_to_top_vec);
                        result_quat = inv_target_quat;
                        result_vec = inv_target_vec;
                    }
                    break;
                case WalkEnding.FullPath:
                    {
                        Quaternion inv_target_quat = target_to_top_quat.Inverse();
                        Vector3 inv_target_vec = QuatRotate(inv_target_quat, -1 * target_to_top_vec);
                        result_vec = QuatRotate(inv_target_quat, source_to_top_vec) + inv_target_vec;
                        result_quat = inv_target_quat * source_to_top_quat;
                    }
                    break;
            }
            this.time = time;
        }

        public override void Accum(bool source)
        {
            if (source)
            {
                source_to_top_vec = QuatRotate(st.Rotation, source_to_top_vec) + st.Translation;
                source_to_top_quat = st.Rotation * source_to_top_quat;
            }
            else
            {
                target_to_top_vec = QuatRotate(st.Rotation, target_to_top_vec) + st.Translation;
                target_to_top_quat = st.Rotation * target_to_top_quat;
            }
        }

        public Vector3 QuatRotate(Quaternion rotation, Vector3 v)
        {
            Quaternion q = rotation * v;
            return new Vector3(q.X, q.Y, q.Z);
        }
    }
}
