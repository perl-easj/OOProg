using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo01
{
    public class OrderData
    {
        public string OrderId { get; }
        public string Date { get; }
        public string ContactPerson { get; }

        public OrderData(string orderId, string date, string contactPerson)
        {
            OrderId = orderId;
            Date = date;
            ContactPerson = contactPerson;
        }
    }
}
