using Xunit;
using Uml.Robotics.Ros;

namespace Uml.Robotics.Ros.UnitTests
{
    public class ActionMessages
    {
        [Fact]
        public void Should_ProduceCorrectMd5SumsForActionMessageClasses()
        {
            var inner = new Messages.control_msgs.FollowJointTrajectoryGoal();
            var outer = new GoalActionMessage<Messages.control_msgs.FollowJointTrajectoryGoal> ();
            var innerMd5 = inner.MD5Sum();
            var outerMd5 = outer.MD5Sum();

            var definition = outer.MessageDefinition();

            Assert.Equal("69636787b6ecbde4d61d711979bc7ecb", innerMd5);
            Assert.Equal("cff5c1d533bf2f82dd0138d57f4304bb", outerMd5);

            var inner2 = new Messages.control_msgs.FollowJointTrajectoryResult();
            var outer2 = new ResultActionMessage<Messages.control_msgs.FollowJointTrajectoryResult>();
            var innerMd52 = inner2.MD5Sum();
            var outerMd52 = outer2.MD5Sum();

            var definition2 = outer2.MessageDefinition();

            Assert.Equal("493383b18409bfb604b4e26c676401d2", innerMd52);
            Assert.Equal("c4fb3b000dc9da4fd99699380efcc5d9", outerMd52);

            var inner3 = new Messages.control_msgs.FollowJointTrajectoryFeedback();
            var outer3 = new FeedbackActionMessage<Messages.control_msgs.FollowJointTrajectoryFeedback>();
            var innerMd53 = inner3.MD5Sum();
            var outerMd53 = outer3.MD5Sum();

            var definition3 = outer3.MessageDefinition();

            Assert.Equal("10817c60c2486ef6b33e97dcd87f4474", innerMd53);
            Assert.Equal("d8920dc4eae9fc107e00999cce4be641", outerMd53);

            var inner4 = new Messages.control_msgs.SingleJointPositionResult();
            var outer4 = new ResultActionMessage<Messages.control_msgs.SingleJointPositionResult>();
            var innerMd54 = inner4.MD5Sum();
            var outerMd54 = outer4.MD5Sum();

            var definition4 = outer4.MessageDefinition();

            Assert.Equal("d41d8cd98f00b204e9800998ecf8427e", innerMd54);
            Assert.Equal("1eb06eeff08fa7ea874431638cb52332", outerMd54);
        }
    }
}
