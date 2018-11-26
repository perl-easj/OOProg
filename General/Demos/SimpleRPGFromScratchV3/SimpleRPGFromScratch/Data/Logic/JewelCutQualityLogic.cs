using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class JewelCutQuality : DomainClassBase
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