using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.App;

namespace SimpleRPGFromScratch
{
    public partial class WeaponJewelMatch : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }
    }
}