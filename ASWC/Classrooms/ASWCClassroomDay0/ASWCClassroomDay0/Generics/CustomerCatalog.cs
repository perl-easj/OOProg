using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay0.Generics
{
    public class CustomerCatalog
    {
        private List<Customer> _customers;

        public CustomerCatalog()
        {
            _customers = new List<Customer>();
        }

        public List<Customer> All
        {
            get { return _customers; }
        }

        public void Create(Customer aCustomer)
        {
            _customers.Add(aCustomer);
        }

        public Customer Read(int id)
        {
            return _customers.FirstOrDefault(o => o.Id == id);
        }

        public void Delete(int id)
        {
            _customers.RemoveAll(o => o.Id == id);
        }
    }
}