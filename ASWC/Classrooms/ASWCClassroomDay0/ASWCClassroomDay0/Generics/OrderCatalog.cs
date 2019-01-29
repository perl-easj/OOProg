using System.Collections.Generic;
using System.Linq;

namespace ASWCClassroomDay0.Generics
{
    public class OrderCatalog
    {
        private List<Order> _orders;

        public OrderCatalog()
        {
            _orders = new List<Order>();
        }

        public List<Order> All
        {
            get { return _orders; }
        }

        public void Create(Order anOrder)
        {
            _orders.Add(anOrder);
        }

        public Order Read(int id)
        {
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        public void Delete(int id)
        {
            _orders.RemoveAll(o => o.Id == id);
        }
    }
}