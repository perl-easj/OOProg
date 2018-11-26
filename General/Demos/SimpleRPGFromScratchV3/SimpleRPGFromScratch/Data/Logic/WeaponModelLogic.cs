// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponModel : DomainClassBase
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