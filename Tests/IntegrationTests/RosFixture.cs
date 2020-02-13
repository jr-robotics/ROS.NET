using System;
using System.Collections.Generic;
using System.Text;
using Uml.Robotics.Ros;
using Xunit;

namespace Uml.Robotics.Ros.IntegrationTests
{
    /// <summary>
    /// This class contains a xUnit collection, which is created before any of the members of the collection and
    /// disposed after all tests of the members are finished.
    /// Compare: https://xunit.github.io/docs/shared-context.html#collection-fixture
    /// </summary>
    public class RosFixture : IDisposable
    {
        public const string ROS_COLLECTION = "ROS collection";


        public RosFixture()
        {
            Console.WriteLine("Init ROS");
            ROS.ROS_MASTER_URI = "http://localhost:11311";
            ROS.ROS_IP = "127.0.0.1";
            ROS.Init(new string[0], "RosFixture");
        }


        public void Dispose()
        {
            Console.WriteLine("Shutting down ROS");
            ROS.Shutdown();
        }
    }


    [CollectionDefinition(RosFixture.ROS_COLLECTION)]
    public class RosCollection : ICollectionFixture<RosFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
