using Bogus;
using Source.Models;
using System.Collections.Generic;

namespace Source.Services
{
    public class EmployeeService:IEmployeeService
    {
        private static List<Employee> EmployeesList;

        public EmployeeService()
        {
            var employeeFaker = new Faker<Employee>()
                 .RuleForType(typeof(int), e => e.Random.Int(0, 99))
                .RuleForType(typeof(string),e=>e.Person.FullName)
                .RuleForType(typeof(int),e=>e.Random.Int(18,56))
               ;
            EmployeesList = employeeFaker.Generate(12);
        }

        public List<Employee> GetEmployees()
        {
            return EmployeesList;
        }
    }
}
