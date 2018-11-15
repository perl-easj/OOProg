using Data.InMemory.Implementation;

namespace SimpleRPGDemo.Data.Base
{
    public abstract class DomainClassAppBase : DomainClassBase, IHasID
    {
        public override int Key
        {
            get { return Id;}
            set { Id = value; }
        }

        public abstract int Id { get; set; }
    }
}