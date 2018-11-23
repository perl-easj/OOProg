using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class JewelModel : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }
    }
}