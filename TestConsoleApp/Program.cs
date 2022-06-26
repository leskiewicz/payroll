using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestConsoleApp
{
    //TODO: Implement new Employment type: "Intern"			X
    //TODO: Import new employee file: employees2.csv		X
    //TODO: Intern employee is payed fixed rate 1000$		X
    //TODO: Implement logging errors to file "c:\log.txt"	X
    //TODO: Implement exporting payroll .txt file to folder "c:\payrolls\"		X
    class Program
    {
        static void Main(string[] args)
        {
            Logger l = new ConsoleLogger();
			Logger fl = new FileLogger();

            var list = new List<Employee>();
			string readText = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "employees.csv"));
			List<string> listStrLineElements = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
			List<string> rowList = listStrLineElements.SelectMany(s => s.Split(';')).ToList();

			string readText2 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "employees2.csv"));
			List<string> listStrLineElements2 = readText2.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
			List<string> rowList2 = listStrLineElements2.SelectMany(s => s.Split(';')).ToList();

			for (int i = 10; i < rowList.Count - 10; i += 10)
			{
				list.Add(new Employee()
				{
					Id = int.Parse(rowList[i + 0]),
					FirstName = rowList[i + 1],
					LastName = rowList[i + 2],
					JobType = rowList[i + 4],
					Email = rowList[i + 6],
					Gender = (Gender)Enum.Parse(typeof(Gender), rowList[i + 7], true),
					HourlyRate = decimal.Parse(rowList[i + 8]),
					EmploymentType = (EmploymentType)Enum.Parse(typeof(EmploymentType), rowList[i + 9], true)
				});
			}

			for (int i = 8; i < rowList2.Count - 8; i += 8)
			{
				list.Add(new Employee()
				{
					Id = int.Parse(rowList2[i + 0]),
					FirstName = rowList2[i + 1],
					LastName = rowList2[i + 2],
					JobType = rowList2[i + 3],
					Email = rowList2[i + 4],
					Gender = (Gender)Enum.Parse(typeof(Gender), rowList2[i + 5], true),
					HourlyRate = decimal.Parse(rowList2[i + 6]),
					EmploymentType = (EmploymentType)Enum.Parse(typeof(EmploymentType), rowList2[i + 7], true)
				});
			}

			l.Log("## Payroll:");
			fl.Log("## Payroll:");
			foreach (var item in list)
            {
                item.CalculateSalary(new DateTime(2019, 10, 1), new DateTime(2019, 10, 31));
            }
        }
    }
}
