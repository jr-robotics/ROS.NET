using System;
using System.Threading;
using Messages.actionlib_tutorials;
using Uml.Robotics.Ros;
using Uml.Robotics.Ros.ActionLib;
using Messages.control_msgs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ActionServerSample
{
    class Program
    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Start ROS");
//            ROS.Init(new string[0], "ActionServer");
//            var asyncSpinner = new AsyncSpinner();
//            asyncSpinner.Start();
//            NodeHandle serverNodeHandle = new NodeHandle();
//            Console.WriteLine("Create server");
//            var actionServer = new ActionServer<Messages.actionlib.TestGoal, Messages.actionlib.TestResult,
//                Messages.actionlib.TestFeedback>(serverNodeHandle, "test_action");
//            Console.WriteLine("Start Server");
//            actionServer.Start();
//
//            actionServer.RegisterGoalCallback((goalHandle) =>
//            {
//                Console.WriteLine($"Goal registered callback. Goal: {goalHandle.Goal.goal}");
//                var fb = new Messages.actionlib.TestFeedback();
//                fb.feedback = 10;
//                goalHandle.PublishFeedback(fb);
//                Thread.Sleep(100);
//                var result = new Messages.actionlib.TestResult();
//                result.result = 123;
//                goalHandle.SetGoalStatus(Messages.actionlib_msgs.GoalStatus.SUCCEEDED, "done");
//                actionServer.PublishResult(goalHandle.GoalStatus, result);
//            });
//
//
//            while (!Console.KeyAvailable)
//            {
//                Thread.Sleep(1);
//            }
//            actionServer.Shutdown();
//            serverNodeHandle.Shutdown();
//            ROS.Shutdown();
//        }

        static void Main(string[] args)
        {
            Console.WriteLine("Start ROS");
            ApplicationLogging.ConsoleLogLevel = LogLevel.Debug;
//            ApplicationLogging.LoggerFactory.AddProvider(
//                new ConsoleLoggerProvider((string text, LogLevel logLevel) =>
//                {
//                    Console.WriteLine(text);
//                    return true;
//                }, true));
            ROS.ROS_MASTER_URI = "http://localhost:11311";
            
            ROS.Init(new string[0], "ActionServer");
            var asyncSpinner = new AsyncSpinner();
            asyncSpinner.Start();
            NodeHandle serverNodeHandle = new NodeHandle();
            Console.WriteLine("Create server");
            var actionServer = new ActionServer<AveragingGoal, AveragingResult,
                AveragingFeedback>(serverNodeHandle, "/averaging");
            Console.WriteLine("Start Server");
            actionServer.Start();

            actionServer.RegisterGoalCallback((goalHandle) =>
            {
                Console.WriteLine($"Goal registered callback. Goal: {goalHandle.Goal.samples}");
                var fb=new AveragingFeedback();
                
                goalHandle.PublishFeedback(fb);
                Thread.Sleep(100);
                var result = new AveragingResult();
                result.mean = 2;
                goalHandle.SetGoalStatus(Messages.actionlib_msgs.GoalStatus.SUCCEEDED, "done");
                actionServer.PublishResult(goalHandle.GoalStatus, result);
            });


            Console.ReadLine();
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