using System;
using System.Collections.Generic;
using System.Text;

namespace BankTransfertLibrarySolid
{
    public enum Severity
    {
        Info,
        Warning,
        Error,
    }

    interface ILogger
    {
    }

    public class Logger : ILogger
    {
        public virtual void Log(Severity severity, string message) { }
    }

    public class ConsoleLogger : Logger
    {
        override public void Log(Severity severity, string message)
        {
            Console.WriteLine($"{severity.ToString()} - {message}");
        }
    }

    public class FileLogger : Logger
    {
        public override void Log(Severity severity, string message)
        {
            System.IO.File.WriteAllText(@"c:\YoloFolder", $"{severity.ToString()} - {message}");
        }
    }
}
