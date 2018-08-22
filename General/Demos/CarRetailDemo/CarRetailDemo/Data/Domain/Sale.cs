using System;
using CarRetailDemo.Data.Base;

namespace CarRetailDemo.Data.Domain
{
    public class Sale : DomainClassAppBase
    {
        public Sale(int key, int carKey, int customerKey, int employeeKey, DateTime salesDate, int finalPrice) : base(NullKey)
        {
            Key = key;
            CarKey = carKey;
            CustomerKey = customerKey;
            EmployeeKey = employeeKey;

            SalesDate = salesDate;
            FinalPrice = finalPrice;
        }

        public Sale() : base(NullKey)
        {
        }

        public int CarKey { get; set; }
        public int CustomerKey { get; set; }
        public int EmployeeKey { get; set; }
        public DateTime SalesDate { get; set; }
        public int FinalPrice { get; set; }

        public override void SetDefaultValues()
        {
            Key = NullKey;
            CarKey = NullKey;
            CustomerKey = NullKey;
            EmployeeKey = NullKey;

            SalesDate = DateTimeOffset.Now.Date;
            FinalPrice = 0;
        }
    }
}