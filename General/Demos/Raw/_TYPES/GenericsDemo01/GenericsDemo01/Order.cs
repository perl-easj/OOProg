using System;

namespace GenericsDemo01
{
    public class Order : IKey<string>
    {
        public Order(string orderId, DateTime date, string contactPerson)
        {
            OrderId = orderId;
            Date = date;
            ContactPerson = contactPerson;
        }

        public string OrderId { get; }
        public DateTime Date { get; }
        public string ContactPerson { get; }

        public string Key
        {
            get { return OrderId; }
        }
    }
}