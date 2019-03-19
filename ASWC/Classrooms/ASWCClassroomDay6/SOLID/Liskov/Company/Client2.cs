using System.Collections.Generic;

// ReSharper disable CollectionNeverUpdated.Local

namespace SOLID.Liskov.Company
{
    public class Client2
    {
        private List<List<IEmployee>> _employeesBySalaryBracket;

        public Client2()
        {
            _employeesBySalaryBracket = new List<List<IEmployee>>();
            for (int i = 0; i < 1000; i++)
            {
                _employeesBySalaryBracket.Add(new List<IEmployee>());
            }
        }

        public void Run()
        {
            List<IEmployee> employees = new List<IEmployee>();

            for (int i = 0; i < 10; i++) { employees.Add(new Employee()); }
            employees.Add(new AltruisticCEO());
            for (int i = 0; i < 10; i++) { employees.Add(new Employee()); }

            PutEmployeesIntoBrackets(employees);
        }

        public void PutEmployeesIntoBrackets(List<IEmployee> employees)
        {
            foreach (IEmployee e in employees)
            {
                int bracketIndex = (e.GetYearlySalary() - 10000) / 1000;
                _employeesBySalaryBracket[bracketIndex].Add(e);
            }
        }
    }
}