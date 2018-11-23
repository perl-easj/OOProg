using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class RarityTier : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }
    }
}