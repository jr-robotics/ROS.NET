using System;
using System.Threading;

using Uml.Robotics.Ros;
using Uml.Robotics.Ros.ActionLib;
using Messages.control_msgs;

namespace ActionServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start ROS");
            ROS.Init(new string[0], "ActionServer");
            var asyncSpinner = new AsyncSpinner();
            asyncSpinner.Start();
            NodeHandle serverNodeHandle = new NodeHandle();
            Console.WriteLine("Create server");
            var actionServer = new ActionServer<Messages.actionlib.TestGoal, Messages.actionlib.TestResult,
                Messages.actionlib.TestFeedback>(serverNodeHandle, "test_action");
            Console.WriteLine("Start Server");
            actionServer.Start();

            actionServer.RegisterGoalCallback((goalHandle) =>
            {
                Console.WriteLine($"Goal registered callback. Goal: {goalHandle.Goal.goal}");
                var fb = new Messages.actionlib.TestFeedback();
                fb.feedback = 10;
                goalHandle.PublishFeedback(fb);
                Thread.Sleep(100);
                var result = new Messages.actionlib.TestResult();
                result.result = 123;
                goalHandle.SetGoalStatus(Messages.actionlib_msgs.GoalStatus.SUCCEEDED, "done");
                actionServer.PublishResult(goalHandle.GoalStatus, result);
            });


            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1);
            }

            actionServer.Shutdown();
            serverNodeHandle.Shutdown();
            ROS.Shutdown();
        }
    }
}