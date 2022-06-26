using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
	public class ConsoleLogger : Logger
	{
		public override void ChangeOutputColor(ConsoleColor color)
		{
			Console.ForegroundColor = color;
		}

		public override void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}
