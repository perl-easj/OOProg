using System;

namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int CarKey { get; set; }
        public int CustomerKey { get; set; }
        public int EmployeeKey { get; set; }
        public DateTime SalesDate { get; set; }
        public int FinalPrice { get; set; }
    }
}
