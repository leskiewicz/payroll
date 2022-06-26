using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsoleApp
{
	public class Employee
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string JobType { get; set; }
		public string Email { get; set; }
		public Gender Gender { get; set; }
		public decimal HourlyRate { get; set; }
		public EmploymentType EmploymentType { get; set; }
		private Logger Logger { get; set; }
		private FileLogger FLogger { get; set; }

		public decimal Salary { get; set; }

		public void CalculateSalary(DateTime from, DateTime to)
		{
			Logger = new ConsoleLogger();
			FLogger = new FileLogger();

			var d = 0;

			//calculate how many working days in given period
			for (int i = 0; i < (to - from).Days + 1; i++)
			{
				var x = from.AddDays(i);
				if (x.DayOfWeek == DayOfWeek.Saturday) continue;
				if (x.DayOfWeek == DayOfWeek.Sunday) continue;
				d++;
			}

			switch (EmploymentType)
			{
				case EmploymentType.FullTime:
					Salary += HourlyRate * 8 * d;
					break;
				case EmploymentType.HalfTime:
					Salary += HourlyRate * 8 * d / 2;
					break;
				case EmploymentType.Intern:
					Salary = 1000;
					break;
				default:
					Logger.ChangeOutputColor(ConsoleColor.Red);
					Logger.Log(EmploymentType.ToString() + " is not supported");
					FLogger.LogError(Id.ToString() + " " + EmploymentType.ToString() + " is not supported");
					Logger.ChangeOutputColor(ConsoleColor.White);
					break;
			}

			Logger.Log(FirstName + " " + LastName + "[" + JobType + "] Salary: " + Salary);
			FLogger.Log(FirstName + " " + LastName + "[" + JobType + "] Salary: " + Salary);
		}
	}

	public enum EmploymentType
	{
		FullTime,
		HalfTime,
		Intern
	}

	public enum Gender
	{
		Male,
		Female
	}
}
