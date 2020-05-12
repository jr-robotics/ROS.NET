using System;
using System.Collections.Generic;
using System.Text;

namespace Uml.Robotics.Ros
{
    [IgnoreRosMessage]
    public class ResultActionMessage<TResult> : WrappedFeedbackMessage<TResult>
        where TResult : InnerActionMessage, new()
    {
        public TResult Result
        {
            get { return Content; }
            set { Content = value; }
        }

        public override string MessageType
        {
            get
            {
                // Create dummy instance and get message type.
                var dummyInstance = new TResult();
                var typeName = dummyInstance.MessageType;

                // Replace Result$ with ActionResult
                var front = typeName.Substring(0, typeName.Length - 6);
                var back = typeName.Substring(typeName.Length - 6);
                typeName = front + "Action" + back;
                return typeName;
            }
        }

        public ResultActionMessage()
            : base()
        {
        }

        public ResultActionMessage(byte[] serializedMessage)
            : base(serializedMessage)
        {
        }

        public ResultActionMessage(byte[] serializedMessage, ref int currentIndex)
            : base(serializedMessage, ref currentIndex)
        {
        }

        public bool Equals(ResultActionMessage<TResult> message)
        {
            return base.Equals(message);
        }

        public override void Randomize()
        {
            Result.Randomize();
            base.Randomize();
        }

        public override string MessageDefinition()
        {
            return $"Header header\nactionlib_msgs/GoalStatus status\n{this.MessageType} result";
        }

        public override string MD5Sum()
        {
            var messageDefinition = new List<string>
            {
                (new Messages.std_msgs.Header()).MD5Sum() + " header",
                (new Messages.actionlib_msgs.GoalStatus()).MD5Sum() + " status",
                (new TResult()).MD5Sum() + " result"
            };
            var hashText = string.Join("\n", messageDefinition);
            var md5sum = CalcMd5(hashText);
            return md5sum;
        }
    }
}