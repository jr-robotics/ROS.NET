using System;
using System.Collections.Generic;
using System.Text;

using Messages;
using Messages.actionlib_msgs;
using System.Threading.Tasks;
using System.Threading;

namespace Uml.Robotics.Ros.ActionLib
{
    public class ClientGoalHandle<TGoal, TResult, TFeedback>
        where TGoal : InnerActionMessage, new()
        where TResult : InnerActionMessage, new()
        where TFeedback : InnerActionMessage, new()
    {
        private readonly object gate = new object();
        private TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        private IActionClient<TGoal, TResult, TFeedback> actionClient;
        internal int statusMissing;     // internal couter used to track if this goal handle is missing in multiple status messsages of server

        public string Id { get; }
        public GoalActionMessage<TGoal> Goal { get; }

        private CommunicationState state;
        public CommunicationState State
        {
            get { lock (gate) return state; }
            set { lock (gate) state = value; }
        }

        public Action<ClientGoalHandle<TGoal, TResult, TFeedback>> OnTransitionCallback { get; set; }
        public Action<ClientGoalHandle<TGoal, TResult, TFeedback>, FeedbackActionMessage<TFeedback>> OnFeedbackCallback { get; set; }

        private bool active;
        public bool Active
        {
            get { lock (gate) return active; }
            set { lock (gate) active = value; }
        }

        private GoalStatus latestGoalStatus;
        public GoalStatus LatestGoalStatus
        {
            get { lock (gate) return latestGoalStatus; }
            set { lock (gate) latestGoalStatus = value; }
        }

        private ResultActionMessage<TResult> latestResultAction;
        public ResultActionMessage<TResult> LatestResultAction
        {
            get { lock (gate) return latestResultAction; }
            set { lock (gate) latestResultAction = value; }
        }

        public GoalID GoaldId =>
            this.Goal.GoalId;

        public Task<TResult> GoalTask =>
            tcs.Task;

        public TResult Result
        {
            get
            {
                if (!Active)
                {
                    ROS.Error()("actionlib", "Trying to getResult on an inactive ClientGoalHandle.");
                }

                if (LatestResultAction != null)
                {
                    return LatestResultAction.Result;
                }

                return null;
            }
        }

        public ClientGoalHandle(
            IActionClient<TGoal, TResult, TFeedback> actionClient,
            GoalActionMessage<TGoal> goalAction,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>> onTransitionCallback,
            Action<ClientGoalHandle<TGoal, TResult, TFeedback>, FeedbackActionMessage<TFeedback>> onFeedbackCallback
        )
        {
            this.actionClient = actionClient;
            Id = goalAction.GoalId.id;
            Goal = goalAction;
            State = CommunicationState.WAITING_FOR_GOAL_ACK;
            this.OnTransitionCallback = onTransitionCallback;
            this.OnFeedbackCallback = onFeedbackCallback;
            Active = true;
        }

        internal void FireTransitionCallback(CommunicationState nextState)
        {
            GoalStatus goalStatus;

            lock (gate)
            {
                this.State = nextState;
                goalStatus = this.LatestGoalStatus;
                statusMissing = 0;
            }

            // set result on task completion source when we enter a terminal communication state
            if (nextState == CommunicationState.DONE && !tcs.Task.IsCompleted)
            {
                if (goalStatus?.status == GoalStatus.SUCCEEDED)
                {
                    var result = this.Result;
                    tcs.SetResult(result);
                }
                else if (goalStatus?.status == GoalStatus.PREEMPTED)
                {
                    tcs.SetCanceled();
                }
                else
                {
                    tcs.SetException(new ActionFailedExeption(this.actionClient.Name, goalStatus));
                }
            }

            this.OnTransitionCallback?.Invoke(this);
        }

        internal void FireFeedback(ClientGoalHandle<TGoal, TResult, TFeedback> goalHandle, FeedbackActionMessage<TFeedback> feedback)
        {
            OnFeedbackCallback?.Invoke(goalHandle, feedback);
        }

        public void Cancel()
        {
            if (!Active)
            {
                ROS.Error()("actionlib", "Trying to cancel() on an inactive goal handle.");
            }

            if (State == CommunicationState.WAITING_FOR_RESULT
                || State == CommunicationState.RECALLING
                || State == CommunicationState.PREEMPTING
                || State == CommunicationState.DONE)
            {
                ROS.Debug()("actionlib", $"Got a cancel() request while in state {State}, so ignoring it");
                return;
            }
            else if (!(State == CommunicationState.WAITING_FOR_GOAL_ACK
                || State == CommunicationState.PENDING
                || State == CommunicationState.ACTIVE
                || State == CommunicationState.WAITING_FOR_CANCEL_ACK))
            {
                ROS.Debug()("actionlib", $"BUG: Unhandled CommState: {State}");
                return;
            }

            var cancelMessage = new GoalID { id = Id };
            actionClient.CancelPublisher.Publish(cancelMessage);
            actionClient.TransitionToState(this, CommunicationState.WAITING_FOR_CANCEL_ACK);

            CheckDoneAsync();
        }


        private async void CheckDoneAsync()
        {
            await Task.Delay(this.actionClient.PreemptTimeout ?? 3000).ConfigureAwait(false);
            if (this.State != CommunicationState.DONE)
            {
                ROS.Warn()("actionlib", $"Did not receive cancel acknowledgement for canceled goal id {this.Id}. Assuming that action server has been shutdown.");
                this.actionClient.ProcessLost(this);
            }
        }


        public void Resend()
        {
            if (!this.Active)
            {
                ROS.Error()("actionlib", "Trying to resend() on an inactive goal handle.");
            }
            actionClient.GoalPublisher.Publish(Goal);
        }


        public void Reset()
        {
            lock (gate)
            {
                OnTransitionCallback = null;
                OnFeedbackCallback = null;
                Active = false;
            }
        }
    }
}
