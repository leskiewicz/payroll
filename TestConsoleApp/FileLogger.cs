using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
	public class FileLogger : Logger
	{
		static bool x = false;
		static bool y = false;
		public override void Log(string message)
		{
			if (!System.IO.Directory.Exists(@"d:\payrolls"))
			{
				System.IO.Directory.CreateDirectory(@"d:\payrolls");
			}

			if (y == false)
			{
				y = true;
				System.IO.File.WriteAllText(@"d:\payrolls\payroll.txt", message + Environment.NewLine);
			}
			else
				System.IO.File.AppendAllText(@"d:\payrolls\payroll.txt", message + Environment.NewLine);
		}
		public void LogError(string message)
		{
			if (x == false)
			{
				x = true;
				System.IO.File.WriteAllText(@"d:\log.txt", message + Environment.NewLine);
			}
			else
				System.IO.File.AppendAllText(@"d:\log.txt", message + Environment.NewLine);
		}

		//Liskov substitution principle
		public override void ChangeOutputColor(ConsoleColor color)
		{
			throw new NotImplementedException();
		}


	}
}
