using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class JewelModel : DomainClassBase
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }
    }
}