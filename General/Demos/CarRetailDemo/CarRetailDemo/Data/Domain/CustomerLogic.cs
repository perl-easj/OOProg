using CarRetailDemo.Data.Base;

namespace MVVMStarterDemoA.Data.Domain
{
    public partial class Customer : DomainClassAppBase
    {
        public override void SetDefaultValues()
        {
            Key = NullKey;
            ImageKey = NullKey;
            FullName = "(not set)";
            Phone = "(not set)";
            Email = "(not set)";
            Address = "(not set)";
            ZipCode = 0;
            City = "(not set)";
            MinPrice = 0;
            MaxPrice = 0;
            NewsLetter = false;
        }

        public override int Key
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
