using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponType : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }
    }
}