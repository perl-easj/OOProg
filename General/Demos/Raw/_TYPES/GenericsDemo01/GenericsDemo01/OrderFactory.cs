using System;

namespace GenericsDemo01
{
    public class OrderFactory : IFactory<Order, OrderData>
    {
        public Order Convert(OrderData obj)
        {
            return new Order(
                obj.OrderId, 
                DateTime.Parse(obj.Date), 
                obj.ContactPerson);
        }
    }
}