using System.Threading;

namespace UnitTestingExample.Common
{
    public interface ILogger
    {
        void Log(params object[] values);
    }

    public class Logger : ILogger
    {
        public void Log(params object[] values)
        {
            Thread.Sleep(10000);
        }
    }
}
