using System;

namespace EFCore20Demo.DomainClasses
{
    public class SaleClass
    {
        public int Id { get; set; }
        public int CarKey { get; set; }
        public int CustomerKey { get; set; }
        public int EmployeeKey { get; set; }
        public DateTime SalesDate { get; set; }
        public int FinalPrice { get; set; }

        public override string ToString()
        {
            return $"{SalesDate.ToString()}  ({FinalPrice} kr.)";
        }
    }
}