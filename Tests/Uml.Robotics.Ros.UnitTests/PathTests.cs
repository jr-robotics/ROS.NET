using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Uml.Robotics.Ros.UnitTests
{
    public class PathTests
    {
        private ITestOutputHelper _output;

        public PathTests(ITestOutputHelper output)
        {
            _output = output;
        }
        
        [Fact]
        public void GetFullPath_1()
        {
            const string p = "my/relative/path.xml";

            var actual = Path.GetFullPath(p);
            
            
            _output.WriteLine(actual);
        }
        
        [Fact]
        public void GetFullPath_2()
        {
            const string p = "/my/relative/path.xml";

            var actual = Path.GetFullPath(p);
            
            
            _output.WriteLine(actual);
        }
        
        [Fact]
        public void GetFullPath_3()
        {
            const string p = "C:/my/qualified/path.xml";

            var actual = Path.GetFullPath(p);
            
            
            _output.WriteLine(actual);
        }
    }
}