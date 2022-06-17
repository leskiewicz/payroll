using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
    public abstract class Logger
    {
        public abstract void Log(string message);
        public abstract void ChangeOutputColor(ConsoleColor color);

    }
}
