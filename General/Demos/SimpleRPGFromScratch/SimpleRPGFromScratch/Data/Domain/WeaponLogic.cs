// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

namespace SimpleRPGFromScratch
{
    public partial class Weapon
    {
        public override string ToString()
        {
            return $"This Weapon has id = {Id}";
        }
    }
}