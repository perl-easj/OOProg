using Data.InMemory.Implementation;

namespace CarRetailDemo.Data.Base
{
    public abstract class DomainClassAppBase : DomainClassBase
    {
        public override int Key { get; set; }
        public int ImageKey { get; set; }

        public int Id
        {
            get { return Key; }
            set { Key = value; }
        }

        protected DomainClassAppBase(int imageKey) : base()
        {
            ImageKey = imageKey;
        }
    }
}