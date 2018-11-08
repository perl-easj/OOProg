using CarRetailDemo.Data.Base;

namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Car : DomainClassAppBase
    {
        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            LicensePlate = "(not set)";
            Brand = "(not set)";
            Model = "(not set)";
            Year = 2000;
            EngineSize = 0;
            HorsePower = 0;
            Seats = 0;
            Price = 0;
        }

        public override int Key
        {
            get { return Id;}
            set { Id = value; }
        }
    }
}