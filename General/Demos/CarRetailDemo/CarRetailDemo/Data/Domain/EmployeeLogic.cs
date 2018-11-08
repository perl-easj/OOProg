using System;
using CarRetailDemo.Data.Base;
using CarRetailDemo.Models.App;

namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Employee : DomainClassAppBase
    {
        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            FullName = "(not set)";
            Phone = "(not set)";
            Email = "(not set)";
            Title = "(not set)";
            EmployedDate = DateTimeOffset.Now.Date;
        }

        public override int Key
        {
            get { return Id; }
            set { Id = value; }
        }

        public int CarsSold()
        {
            return DomainModel.Instance.CarsSoldByEmployee(Key);
        }
    }
}