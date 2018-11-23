// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponModel : IDomainClass
    {
        public int GetId()
        {
            return Id;
        }
    }
}