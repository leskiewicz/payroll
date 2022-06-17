using Bogus;
using System;
using System.Collections.Generic;

namespace EmployeeGenerator
{
    public static class Generator
    {
       public static List<Employee> Run(int numberOfObjects)
        {
            Randomizer.Seed = new Random(65498);

            var userIds = 0;

            var testUsers = new Faker<Employee>()
                //.CustomInstantiator(f => new Employee()
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.EmploymentType, f => f.PickRandom<EmploymentType>())
                .RuleFor(u => u.Id, f => userIds++)
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(f.Person.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(f.Person.Gender))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.JobType, (f, u) => f.Name.JobType())
                .RuleFor(u => u.HourlyRate, (f, u) => (u.EmploymentType == EmploymentType.Intern) ? 0 : f.Random.Number(4, 20));

               return  testUsers.Generate(numberOfObjects);
        }

        public enum EmploymentType
        {
            FullTime,
            HalfTime,
            Intern,
        }

        public enum Gender
        {
            Male,
            Female
        }

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

        }
    }
}
