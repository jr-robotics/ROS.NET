using System.IO;
using System.Threading.Tasks;
using NuGet.Common;

namespace YAMLParser.NuGet
{
    public class ConsoleLogger : LoggerBase
    {
        private static readonly object _writerLock = new object();

        private TextWriter Out
        {
            get { return System.Console.Out; }
        }
        
        public void WriteLine(string format, params object[] args)
        {
            lock (_writerLock)
            {
                Out.WriteLine(format, args);
            }
        }
        
        public override void Log(ILogMessage message)
        {
            WriteLine(message.Message);
        }

        public override Task LogAsync(ILogMessage message)
        {
            Log(message);
            return Task.FromResult(0);
        }
    }
}