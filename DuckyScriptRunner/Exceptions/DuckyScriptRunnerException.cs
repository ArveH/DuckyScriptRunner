using System;

namespace DuckyScriptRunner.Exceptions
{
    public class DuckyScriptRunnerException: Exception
    {
        public DuckyScriptRunnerException(string msg): base(msg)
        {
            
        }

        public DuckyScriptRunnerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}