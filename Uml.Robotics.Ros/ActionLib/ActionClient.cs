using Messages.actionlib_msgs;
using Messages.std_msgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Uml.Robotics.Ros.ActionLib
{
    public class ActionClient<TGoal, TResult, TFeedback>
        : IActionClient<TGoal, TResult, TFeedback>
        where TGoal : InnerActionMessage, new()
        where TResult : InnerActionMessage, new()
        where TFeedback : InnerActionMessage, new()
    {
        const int MAX_STATUS_MISSING_UNACKNOWLEDGED = 3;        // number of status messages to wait for server to reflect a published goal before republishing it
        const int MAX_STATUS_MISSING_WAIT_RESULT = 5;           // if goal disappeared from status list and is waiting for result: number of messages to wait before considering goal lost

        private static int nextGoalId = 0; // Shared among all clients
        private static readonly object lockId = new object();

        public string Name { get; private set; }
        public int QueueSize { get; private set; }
        public Publisher<GoalActionMessage<TGoal>> GoalPublisher { get; private set; }
        public Publisher<GoalID> CancelPublisher { get; private set; }
        public Time LatestStatusTime { get; private set; }
        public uint? LatestSequenceNumber { get; private set; } = null;
        public int? PreemptTimeout { get; set; } = null;
        public TimeSpan ActionServerWaitTimeout { get; set; } = TimeSpan.FromSeconds(3);

        private readonly object gate = new object();

        private NodeHandle nodeHandle;
        private bool statusReceived;
        private Dictionary<string, ClientGoalHandle<TGoal, TResult, TFeedback>> goalHandles;
        private Dictionary<string, int> goalSubscriberCount;
        private Dictionary<string, int> cancelSubscriberCount;
        private Subscriber statusSubscriber;
        private Subscriber feedbackSubscriber;
        private Subscriber resultSubscriber;
        private string statusCallerId = null;

        public ActionClient(string name, NodeHandle parentNodeHandle, int queueSize = 50)
        {
            this.Name = name;
            this.QueueSize = queueSize;
            this.nodeHandle = new NodeHandle(parentNodeHandle, name);
            this.statusReceived = false;
            this.goalHandles = new Dictionary<string, ClientGoalHandle<TGoal, TResult, TFeedback>>();
            this.goalSubscriberCount = new Dictionary<string, int>();
            this.cancelSubscriberCount = new Dictionary<string, int>();

            statusSubscriber = nodeHandle.Subscribe<GoalStatusArray>("status", queueSize, OnStatusMessage);
            feedbackSubscriber = nodeHandle.Subscribe<FeedbackActionMessage<TFeedback>>("feedback", queueSize, OnFeedbackMessage);
            resultSubscriber = nodeHandle.Subscribe<ResultActionMessage<TResult>>("result", queueSize, OnResultMessage);

            GoalPublisher = nodeHandle.Advertise<GoalActionMessage<TGoal>>(
                "goal",
                queueSize,
                OnGoalConnectCallback,
                OnGoalDisconnectCallback
            );

            CancelPublisher = nodeHandle.Advertise<GoalID>(
                "cancel",
                queueSize,
                OnCancelConnectCallback,
                OnCancelDisconnectCallback
            );

            ROS.RosShuttingDown += ROS_RosShuttingDown;
        }


        private void ROS_RosShuttingDown(object sender, EventArgs e)
        {
            HandleConnectionLost();
        }


        /// <summary>
        /// Cancel all goals that were stamped at and before the specified time. All goals stamped at or before `time` will be canceled
        /// </summary>
        public void CancelGoalsAtAndBeforeTime(Time time)
        {
            var cancelMessage = new GoalID { stamp = time };
            CancelPublisher.Publish(cancelMessage);
        }


        /// <summary>
        /// Cancel all goals currently running on the action server
        /// This preempts all goals running on the action server at the point that this message is serviced by the ActionServer.
        /// </summary>
        public void CancelGoalsAtAndBeforeTime()
        {
            CancelGoalsAtAndBeforeTime(ROS.GetTime());
        }


        public TGoal CreateGoal()
        {
            return new TGoal();
        }


        public ClientGoalHandle<TGoal, TResult, TFeedback> SendGoal(
            TGoal goal,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>> OnTransistionCallback = null,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>, FeedbackActionMessage<TFeedback>> OnFeedbackCallback = null
        )
        {
            // Create Goal Message;
            var goalId = new GoalID();

            lock (lockId)
            {
                var now = ROS.GetTime();

                // Create sortable goal id
                goalId.id = $"{ThisNode.Name}-{nextGoalId:x08}-{now.data.sec:x08}.{now.data.nsec:x08}";
                goalId.stamp = now;
                nextGoalId = nextGoalId + 1;
            }

            // Prepare Goal Message
            var goalAction = new GoalActionMessage<TGoal>
            {
                Header = new Messages.std_msgs.Header
                {
                    stamp = ROS.GetTime()
                },
                GoalId = goalId,
                Goal = goal
            };

            // Register goal message
            var goalHandle = new ClientGoalHandle<TGoal, TResult, TFeedback>(
                this,
                goalAction,
                OnTransistionCallback,
                OnFeedbackCallback
            );

            lock (gate)
            {
                goalHandles[goalAction.GoalId.id] = goalHandle;
            }

            // Publish goal message
            GoalPublisher.Publish(goalAction);
            ROS.Debug()("Goal published: {0}", goalHandle.Id);

            return goalHandle;
        }


        public void Shutdown()
        {
            Dispose();
        }


        public void Dispose()
        {
            ROS.RosShuttingDown -= ROS_RosShuttingDown;

            statusSubscriber?.Dispose();
            feedbackSubscriber?.Dispose();
            resultSubscriber?.Dispose();
            GoalPublisher?.Dispose();
            CancelPublisher?.Dispose();
            nodeHandle?.Dispose();
        }


        private bool CheckActionServerStatusAndLog()
        {
            lock (gate)
            {
                if (IsServerConnected())
                    return true;

                ROS.Warn()($"ActionServer {this.Name} is not ready (status received: {statusReceived}; callerId: {statusCallerId}; "
                    + $"goal: {statusCallerId != null && goalSubscriberCount.ContainsKey(statusCallerId)} ({goalSubscriberCount.Count}); "
                    + $"cancel: {statusCallerId != null && cancelSubscriberCount.ContainsKey(statusCallerId)} ({cancelSubscriberCount.Count}); "
                    + $"feedback: {feedbackSubscriber.NumPublishers}; result: {resultSubscriber.NumPublishers}).");
            }

            return false;
        }

        /// <summary>
        /// Waits for the ActionServer to connect to this client.
        /// Often, it can take a second for the action server &amp; client to negotiate
        /// a connection, thus, risking the first few goals to be dropped. This call lets
        /// the user wait until the network connection to the server is negotiated
        /// NOTE: Using this call in a single threaded ROS application, or any
        /// application where the action client's callback queue is not being
        /// serviced, will not work. Without a separate thread servicing the queue, or
        /// an AsyncSpinner, there is no way for the client to tell whether
        /// or not the server is up because it can't receive a status message.
        /// </summary>
        /// <param name="timeout">Max time to block before returning. A null timeout is interpreted as an infinite timeout.</param>
        /// <returns>True if the server connected in the allocated time, false on timeout</returns>
        public bool WaitForActionServerToStart(TimeSpan? timeout = null)
        {
            var tic = DateTime.UtcNow;
            while (ROS.OK)
            {
                if (IsServerConnected())
                    return true;

                if (timeout != null)
                {
                    var toc = DateTime.UtcNow;
                    TimeSpan elapsed = toc - tic;
                    if (elapsed > timeout)
                        break;
                }

                Thread.Sleep(10);

            }

            return CheckActionServerStatusAndLog();
        }

        /// <summary>
        /// Waits for the ActionServer to connect to this client.
        /// Often, it can take a second for the action server &amp; client to negotiate
        /// a connection, thus, risking the first few goals to be dropped.This call lets
        /// the user wait until the network connection to the server is negotiated
        /// NOTE: Using this call in a single threaded ROS application, or any
        /// application where the action client's callback queue is not being
        /// serviced, will not work. Without a separate thread servicing the queue, or
        /// a multi-threaded spinner, there is no way for the client to tell whether
        /// or not the server is up because it can't receive a status message.
        /// </summary>
        /// <param name="timeout">Max time to block before returning. A null timeout is interpreted as an infinite timeout.</param>
        /// <returns>True if the server connected in the allocated time, false on timeout</returns>
        public async Task<bool> WaitForActionServerToStartAsync(TimeSpan? timeout = null, CancellationToken cancel = default(CancellationToken))
        {
            var tic = DateTime.UtcNow;
            while (ROS.OK)
            {
                if (IsServerConnected())
                    return true;

                if (cancel.IsCancellationRequested)
                    break;

                if (timeout != null)
                {
                    var toc = DateTime.UtcNow;
                    TimeSpan elapsed = toc - tic;
                    if (elapsed > timeout)
                        break;
                }
                await Task.Delay(10);

            }

            return CheckActionServerStatusAndLog();
        }


        /// <summary>
        /// Waits for the ActionServer to connect to this client. Spins the callbacks.
        /// <seealso cref="WaitForActionServerToStart"/>
        /// </summary>
        public bool WaitForActionServerToStartSpinning(TimeSpan? timeout, SingleThreadSpinner spinner)
        {
            var tic = DateTime.UtcNow;
            while (ROS.OK)
            {
                if (IsServerConnected())
                    return true;

                if (timeout != null)
                {
                    var toc = DateTime.UtcNow;
                    TimeSpan elapsed = toc - tic;
                    if (elapsed > timeout)
                        break;
                }

                spinner.SpinOnce();
                Thread.Sleep(10);
            }

            return CheckActionServerStatusAndLog();
        }


        public void TransitionToState(ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle, CommunicationState nextState)
        {
            ROS.Debug()($"Transitioning CommState from {goalHandle.State} to {nextState}");
            goalHandle.FireTransitionCallback(nextState);
        }


        public bool IsServerConnected()
        {
            lock (gate)
            {
                if (!statusReceived || statusCallerId == null)
                    return false;

                if (!goalSubscriberCount.ContainsKey(statusCallerId))
                    return false;

                if (!cancelSubscriberCount.ContainsKey(statusCallerId))
                    return false;

                if (feedbackSubscriber.NumPublishers == 0)
                    return false;

                if (resultSubscriber.NumPublishers == 0)
                    return false;

                ROS.Debug()($"isServerConnected: Server {statusCallerId} is fully connected.");
                return true;
            }
        }


        private GoalStatus FindGoalInStatusList(GoalStatusArray statusArray, string goalId) =>
            statusArray.status_list.FirstOrDefault(x => x.goal_id.id == goalId);


        private string FormatSubscriberDebugString(string name, Dictionary<string, int> subscriberCount)
        {
            var result = name + $" ({subscriberCount.Count} total)";
            foreach (var pair in subscriberCount)
            {
                result += pair.Key + " ";
            }

            return result;
        }


        private void HandleConnectionLost()
        {
            lock (gate)
            {
                foreach (var pair in this.goalHandles)
                {
                    this.ProcessLost(pair.Value);
                }
            }
        }


        private void OnCancelConnectCallback(SingleSubscriberPublisher publisher)
        {
            lock (gate)
            {
                bool subscriberExists = cancelSubscriberCount.TryGetValue(publisher.SubscriberName, out int subscriberCount);
                cancelSubscriberCount[publisher.SubscriberName] = (subscriberExists ? subscriberCount : 0) + 1;
                ROS.Debug()($"cancelConnectCallback: Adding {publisher.SubscriberName} to cancelSubscriberCount");
            }
        }


        private void OnCancelDisconnectCallback(SingleSubscriberPublisher publisher)
        {
            lock (gate)
            {
                bool subscriberExists = cancelSubscriberCount.TryGetValue(publisher.SubscriberName, out int subscriberCount);
                if (!subscriberExists)
                {
                    // This should never happen. Warning has been copied from official actionlib implementation
                    ROS.Warn()(
                        $"goalDisconnectCallback: Trying to remove {publisher.SubscriberName} from " +
                        "goalSubscribers, but it is not in the goalSubscribers list."
                    );
                }
                else
                {
                    ROS.Debug()(
                        $"goalDisconnectCallback: Removing {publisher.SubscriberName} from goalSubscribers, " +
                        $"(remaining with same name: {subscriberCount - 1})"
                    );
                    if (subscriberCount <= 1)
                    {
                        cancelSubscriberCount.Remove(publisher.SubscriberName);
                    }
                    else
                    {
                        cancelSubscriberCount[publisher.SubscriberName] = subscriberCount - 1;
                    }
                }
            }
        }


        private void OnFeedbackMessage(FeedbackActionMessage<TFeedback> feedback)
        {
            ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle;
            bool goalExists;
            lock (gate)
            {
                goalExists = goalHandles.TryGetValue(feedback.GoalStatus.goal_id.id, out goalHandle);
            }
            if (goalExists)
            {
                goalHandle.FireFeedback(goalHandle, feedback);
            }
        }


        private void OnGoalConnectCallback(SingleSubscriberPublisher publisher)
        {
            List<ClientGoalHandle<TGoal, TResult, TFeedback>> unacknowledgedGoalHandles;
            lock (gate)
            {
                bool keyExists = goalSubscriberCount.TryGetValue(publisher.SubscriberName, out int subscriberCount);
                goalSubscriberCount[publisher.SubscriberName] = (keyExists ? subscriberCount : 0) + 1;
                ROS.Debug()($"goalConnectCallback: Adding {publisher.SubscriberName} to goalSubscribers");

                // check if we have unacknowledged goals (the action server might have missed the goal message when it was disconnected)
                unacknowledgedGoalHandles = goalHandles.Values
                    .Where(x => x.State == CommunicationState.WAITING_FOR_GOAL_ACK)
                    .ToList();
            }

            foreach (var gh in unacknowledgedGoalHandles)
            {
                ROS.Debug()("Republishing unacknowledged goal: {0}", gh.Id);
                GoalPublisher.Publish(gh.Goal);
                gh.statusMissing = 0;
            }
        }


        private void OnGoalDisconnectCallback(SingleSubscriberPublisher publisher)
        {
            lock (gate)
            {
                bool keyExists = goalSubscriberCount.TryGetValue(publisher.SubscriberName, out int subscriberCount);
                if (!keyExists)
                {
                    // This should never happen. Warning has been copied from official actionlib implementation
                    ROS.Warn()(
                        $"goalDisconnectCallback: Trying to remove {publisher.SubscriberName} from " +
                        "goalSubscribers, but it is not in the goalSubscribers list."
                    );
                }
                else
                {
                    ROS.Debug()(
                        $"goalDisconnectCallback: Removing {publisher.SubscriberName} from goalSubscribers, " +
                        $"(remaining with same name: {subscriberCount - 1})"
                    );
                    if (subscriberCount <= 1)
                    {
                        goalSubscriberCount.Remove(publisher.SubscriberName);
                    }
                    else
                    {
                        goalSubscriberCount[publisher.SubscriberName] = subscriberCount - 1;
                    }
                }
            }
        }


        private void OnResultMessage(ResultActionMessage<TResult> result)
        {
            string goalId = result.GoalStatus.goal_id.id;
            ROS.Debug()("OnResultMessage (goal_id: {0}, status: {1})", goalId, result.GoalStatus.status);

            ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle;
            bool goalExists;
            lock (gate)
            {
                goalExists = goalHandles.TryGetValue(result.GoalStatus.goal_id.id, out goalHandle);
            }

            if (goalExists)
            {
                ROS.Debug()("Processing result for known goal handle. (goal_id: {0})", goalId);

                goalHandle.LatestGoalStatus = result.GoalStatus;
                goalHandle.LatestResultAction = result;

                if (goalHandle.State == CommunicationState.DONE)
                {
                    ROS.Error()("Got a result when we were already in the DONE state (goal_id: {0})", goalId);
                }
                else if (goalHandle.State == CommunicationState.WAITING_FOR_GOAL_ACK
                    || goalHandle.State == CommunicationState.WAITING_FOR_GOAL_ACK
                    || goalHandle.State == CommunicationState.PENDING
                    || goalHandle.State == CommunicationState.ACTIVE
                    || goalHandle.State == CommunicationState.WAITING_FOR_RESULT
                    || goalHandle.State == CommunicationState.WAITING_FOR_CANCEL_ACK
                    || goalHandle.State == CommunicationState.RECALLING
                    || goalHandle.State == CommunicationState.PREEMPTING)
                {
                    UpdateStatus(goalHandle, result.GoalStatus);
                    TransitionToState(goalHandle, CommunicationState.DONE);
                }
                else
                {
                    ROS.Error()($"Invalid comm for result message state: {goalHandle.State}.");
                }
            }
            else
            {
                ROS.Debug()("Ignoring result for unknown goal (goal_id: {0})", goalId);
            }
        }


        private void OnStatusMessage(GoalStatusArray statusArray)
        {
            bool callerIdPresent = statusArray.connection_header.TryGetValue("callerid", out string callerId);
            if (!callerIdPresent)
            {
                ROS.Error()("Received StatusMessage with no caller ID");
                return;
            }

            Time timestamp = statusArray.header.stamp;
            ROS.Debug()($"Getting status over the wire (callerid: {callerId}; count: " +
                $"{statusArray.status_list.Length})."
            );

            Dictionary<string, ClientGoalHandle<TGoal, TResult, TFeedback>> goalHandlesReferenceCopy;

            lock (gate)
            {
                if (statusReceived)
                {
                    if (statusCallerId != callerId)
                    {
                        ROS.Warn()($"onStatusMessage: Previously received status from {statusCallerId}, but we now" +
                            $" received status from {callerId}. Did the ActionServer change?"
                        );
                        statusCallerId = callerId;
                    }
                }
                else
                {
                    ROS.Debug()("onStatusMessage: Just got our first status message from the ActionServer at " +
                        $"node {callerId}"
                    );
                    statusReceived = true;
                    statusCallerId = callerId;
                }
                LatestStatusTime = timestamp;

                if (LatestSequenceNumber != null && statusArray.header.seq <= LatestSequenceNumber)
                {
                    ROS.Warn()("Status sequence number was decreased. This can only happen when the action server was restarted. Assume all active goals are lost.");
                    HandleConnectionLost();
                }
                LatestSequenceNumber = statusArray.header.seq;

                // Create a copy of all goal handle references in thread safe environment so it can be looped over all goal
                // handles without blocking the sending of new goals
                goalHandlesReferenceCopy = new Dictionary<string, ClientGoalHandle<TGoal, TResult, TFeedback>>(goalHandles);
            }

            // Loop over all goal handles and update their state, mark goal handles that are done for deletion
            var completedGoals = new List<string>();

            foreach (KeyValuePair<string, ClientGoalHandle<TGoal, TResult, TFeedback>> kv in goalHandlesReferenceCopy)
            {
                var value = kv.Value;
                var key = kv.Key;

                if (value.LatestResultAction == null || ROS.ToDateTime(value.LatestResultAction.Header.stamp) < ROS.ToDateTime(timestamp))
                {
                    var goalStatus = FindGoalInStatusList(statusArray, key);
                    UpdateStatus(value, goalStatus);
                    if (value.State == CommunicationState.DONE)
                    {
                        completedGoals.Add(key);
                    }
                }
            }

            // Remove goal handles that are done from the tracking list
            foreach (var goalHandleId in completedGoals)
            {
                ROS.Debug()("Removing completed goal handle (goal_id: {0}) from tracked goal handles", goalHandleId);
                lock (gate)
                {
                    goalHandles.Remove(goalHandleId);
                }
            }
        }


        public void ProcessLost(ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle)
        {
            ROS.Warn()("Transitioning goal to LOST");
            if (goalHandle.LatestGoalStatus != null)
            {
                goalHandle.LatestGoalStatus.status = GoalStatus.LOST;
                goalHandle.LatestGoalStatus.text = "LOST";
            }
            TransitionToState(goalHandle, CommunicationState.DONE);
        }

        public async Task<TResult> SendGoalAsync(
            TGoal goal,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>> onTransistionCallback = null,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>, FeedbackActionMessage<TFeedback>> onFeedbackCallback = null,
            CancellationToken cancel = default(CancellationToken)
        )
        {
            if (!await this.WaitForActionServerToStartAsync(this.ActionServerWaitTimeout, cancel).ConfigureAwait(false))
            {
                ROS.Info()($"Action server {this.Name} is not available.");
                throw new TimeoutException($"Action server {this.Name} is not available.");
            }

            var gh = this.SendGoal(goal, onTransistionCallback, onFeedbackCallback);
            using (cancel.Register(gh.Cancel))
            {
                return await gh.GoalTask.ConfigureAwait(false);
            }
        }

        private void UpdateStatus(ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle, GoalStatus goalStatus)
        {
            // Check if ping action is correctly reflected by the status message
            if (goalHandle.State == CommunicationState.DONE)
            {
              return;

            }

            if (goalStatus == null)
            {
                goalHandle.statusMissing += 1;
                if (goalHandle.State != CommunicationState.WAITING_FOR_GOAL_ACK &&
                    goalHandle.State != CommunicationState.WAITING_FOR_RESULT &&
                    goalHandle.State != CommunicationState.DONE)
                {
                    ProcessLost(goalHandle);
                    return;
                }
                else
                {
                    if (goalHandle.State == CommunicationState.WAITING_FOR_GOAL_ACK)
                    {
                        ROS.Debug()($"Goal status is null for {goalHandle.Id}, most propably because it was just send and there" +
                        $"and the server has not yet sent an update");

                        // if goal was not seen for thre status updates republish the goal
                        if (goalHandle.statusMissing > MAX_STATUS_MISSING_UNACKNOWLEDGED)
                        {
                            this.GoalPublisher.Publish(goalHandle.Goal);
                            goalHandle.statusMissing = 0;
                        }
                    }
                    else if (goalHandle.State == CommunicationState.WAITING_FOR_RESULT)
                    {
                        ROS.Debug()($"Goal status is null for {goalHandle.Id}, while waiting for result. Did we miss the result?");

                        // the server forgot about the goal handle, but we have not received a result message
                        if (goalHandle.statusMissing > MAX_STATUS_MISSING_WAIT_RESULT)
                        {
                            this.ProcessLost(goalHandle);
                        }
                    }

                    return;
                }
            }

            goalHandle.LatestGoalStatus = goalStatus;

            if (goalHandle.State == CommunicationState.WAITING_FOR_GOAL_ACK)
            {
                if (goalStatus.status == GoalStatus.PENDING)
                {
                    TransitionToState(goalHandle, CommunicationState.PENDING);
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.SUCCEEDED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.ABORTED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    TransitionToState(goalHandle, CommunicationState.PENDING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    TransitionToState(goalHandle, CommunicationState.PENDING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    TransitionToState(goalHandle, CommunicationState.PENDING);
                    TransitionToState(goalHandle, CommunicationState.RECALLING);
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown status from the ActionServer. status = {0}", goalStatus.status);
                }
            }
            else if (goalHandle.State == CommunicationState.PENDING)
            {
                if (goalStatus.status == GoalStatus.PENDING)
                {
                    // NOP
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.SUCCEEDED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.ABORTED)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    TransitionToState(goalHandle, CommunicationState.RECALLING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    TransitionToState(goalHandle, CommunicationState.ACTIVE);
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    TransitionToState(goalHandle, CommunicationState.RECALLING);
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown status from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else if (goalHandle.State == CommunicationState.ACTIVE)
            {

                if (goalStatus.status == GoalStatus.PENDING)
                {
                    ROS.Error()("Invalid transition from ACTIVE to PENDING");
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    // NOP
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    ROS.Error()("Invalid transition from ACTIVE to REJECTED");
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    ROS.Error()("Invalid transition from ACTIVE to RECALLING");
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    ROS.Error()("Invalid transition from ACTIVE to RECALLED");
                }
                else if (goalStatus.status == GoalStatus.PREEMPTED)
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.SUCCEEDED ||
                  goalStatus.status == GoalStatus.ABORTED)
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown status from the ActionServer. status = {0}", goalStatus.status);
                }


            }
            else if (goalHandle.State == CommunicationState.WAITING_FOR_RESULT)
            {

                if (goalStatus.status == GoalStatus.PENDING)
                {
                    ROS.Error()("Invalid Transition from WAITING_FOR_RESUT to PENDING");
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    ROS.Error()("Invalid transition from WAITING_FOR_RESUT to PREEMPTING");
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    ROS.Error()("Invalid transition from WAITING_FOR_RESUT to RECALLING");
                }
                else if (goalStatus.status == GoalStatus.ACTIVE ||
                  goalStatus.status == GoalStatus.PREEMPTED ||
                  goalStatus.status == GoalStatus.SUCCEEDED ||
                  goalStatus.status == GoalStatus.ABORTED ||
                  goalStatus.status == GoalStatus.REJECTED ||
                  goalStatus.status == GoalStatus.RECALLED)
                {
                    // NOP
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown status from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else if (goalHandle.State == CommunicationState.WAITING_FOR_CANCEL_ACK)
            {

                if (
                    goalStatus.status == GoalStatus.PENDING ||
                    goalStatus.status == GoalStatus.ACTIVE
                )
                {
                    // NOP
                }
                else if (
                    goalStatus.status == GoalStatus.SUCCEEDED ||
                    goalStatus.status == GoalStatus.ABORTED ||
                    goalStatus.status == GoalStatus.PREEMPTED
                )
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    TransitionToState(goalHandle, CommunicationState.RECALLING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    TransitionToState(goalHandle, CommunicationState.RECALLING);
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown State from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else if (goalHandle.State == CommunicationState.RECALLING)
            {

                if (goalStatus.status == GoalStatus.PENDING)
                {
                    ROS.Error()("Invalid Transition from RECALLING to PENDING");
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    ROS.Error()("Invalid Transition from RECALLING to ACTIVE");
                }
                else if (
                    goalStatus.status == GoalStatus.SUCCEEDED||
                    goalStatus.status == GoalStatus.ABORTED ||
                    goalStatus.status == GoalStatus.PREEMPTED
                )
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    TransitionToState(goalHandle, CommunicationState.PREEMPTING);
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    // NOP
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown State from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else if (goalHandle.State == CommunicationState.PREEMPTING)
            {

                if (goalStatus.status == GoalStatus.PENDING)
                {
                    ROS.Error()("Invalid Transition from PREEMPTING to PENDING");
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    ROS.Error()("Invalid Transition from PREEMPTING to ACTIVE");
                }
                else if (goalStatus.status == GoalStatus.REJECTED)
                {
                    ROS.Error()("Invalid Transition from PREEMPTING to REJECTED");
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    ROS.Error()("Invalid Transition from PREEMPTING to RECALLING");
                }
                else if (goalStatus.status == GoalStatus.RECALLED)
                {
                    ROS.Error()("Invalid Transition from PREEMPTING to RECALLED");
                }
                else if (
                    goalStatus.status == GoalStatus.PREEMPTED ||
                    goalStatus.status == GoalStatus.SUCCEEDED ||
                    goalStatus.status == GoalStatus.ABORTED
                )
                {
                    TransitionToState(goalHandle, CommunicationState.WAITING_FOR_RESULT);
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    // NOP
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown State from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else if (goalHandle.State == CommunicationState.DONE)
            {

                if (goalStatus.status == GoalStatus.PENDING)
                {
                    ROS.Error()("Invalid Transition from DONE to PENDING");
                }
                else if (goalStatus.status == GoalStatus.ACTIVE)
                {
                    ROS.Error()("Invalid Transition from DONE to ACTIVE");
                }
                else if (goalStatus.status == GoalStatus.RECALLING)
                {
                    ROS.Error()("Invalid Transition from DONE to RECALLING");
                }
                else if (goalStatus.status == GoalStatus.PREEMPTING)
                {
                    ROS.Error()("Invalid Transition from DONE to PREEMPTING");
                }
                else if (
                    goalStatus.status == GoalStatus.PREEMPTED ||
                    goalStatus.status == GoalStatus.SUCCEEDED ||
                    goalStatus.status == GoalStatus.ABORTED ||
                    goalStatus.status == GoalStatus.RECALLED ||
                    goalStatus.status == GoalStatus.REJECTED
                )
                {
                    // NOP
                }
                else
                {
                    ROS.Error()("BUG: Got an unknown status from the ActionServer. status = {0}", goalStatus.status);
                }

            }
            else
            {
                ROS.Error()("Invalid comm State: {0}", goalHandle.State);
            }

        }

        public Task<TResult> SendGoalAsync(TGoal goal, CancellationToken cancel = default(CancellationToken))
        {
            return SendGoalAsync(goal, null, null, cancel);
        }

        public Task<TResult> SendGoalAsync(TGoal goal, Action<ClientGoalHandle<TGoal, TResult, TFeedback>> OnTransistionCallback = null, CancellationToken cancel = default(CancellationToken))
        {
            return SendGoalAsync(goal, OnTransistionCallback, null, cancel);
        }

        public Task<TResult> SendGoalAsync(TGoal goal, Action<ClientGoalHandle<TGoal, TResult, TFeedback>, FeedbackActionMessage<TFeedback>> OnFeedbackCallback = null, CancellationToken cancel = default(CancellationToken))
        {
            return SendGoalAsync(goal, null, OnFeedbackCallback, cancel);
        }
    }

    public enum CommunicationState
    {
        WAITING_FOR_GOAL_ACK,
        PENDING,
        ACTIVE,
        WAITING_FOR_RESULT,
        WAITING_FOR_CANCEL_ACK,
        RECALLING,
        PREEMPTING,
        DONE
    }
}
