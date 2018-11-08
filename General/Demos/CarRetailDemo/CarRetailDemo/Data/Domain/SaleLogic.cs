using System;
using CarRetailDemo.Data.Base;

namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Sale : DomainClassAppBase
    {
        public override void SetDefaultValues()
        {
            Key = NullKey;
            CarKey = NullKey;
            CustomerKey = NullKey;
            EmployeeKey = NullKey;

            SalesDate = DateTimeOffset.Now.Date;
            FinalPrice = 0;
        }

        public override int Key
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}