// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

namespace SimpleRPGFromScratch
{
    public partial class WeaponModel
    {
        public override string ToString()
        {
            return $"This weapon model has id = {Id}";
        }
    }
}