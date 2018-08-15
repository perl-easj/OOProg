using System.Collections.Generic;
using System.Linq;

namespace GenericCatalog
{
    public class EmployeeCatalog
    {
        private Dictionary<string, Employee> _employees;

        public EmployeeCatalog()
        {
            _employees = new Dictionary<string, Employee>();
        }

        public List<Employee> All
        {
            get { return _employees.Values.ToList(); }
        }

        public void Insert(string name, Employee anEmployee)
        {
            if (!_employees.ContainsKey(name))
            {
                _employees.Add(name, anEmployee);
            }
        }

        public void Delete(string name)
        {
            _employees.Remove(name);
        }
    }
}