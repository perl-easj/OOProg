using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class RarityTier : DomainClassBase<RarityTier>
    {
        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(RarityTier obj)
        {
            Description = obj.Description;
        }
    }
}