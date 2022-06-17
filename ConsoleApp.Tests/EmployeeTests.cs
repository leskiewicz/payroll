using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsoleApp;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void CalculateSalaryTest()
        {
            //arrange
            var emp = new Employee()
            {
                FirstName = "fName",
                LastName = "lName",
                EmploymentType = EmploymentType.FullTime,
                HourlyRate = 10
            };

            //act
            emp.CalculateSalary(new DateTime(2019,9,1), new DateTime(2019,9,30));
            var result = emp.Salary;

            //assert
            Assert.AreEqual(21*10*8,result);
        }

    }
}
