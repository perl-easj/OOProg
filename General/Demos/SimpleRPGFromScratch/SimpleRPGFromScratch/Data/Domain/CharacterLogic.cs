// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

namespace SimpleRPGFromScratch
{
    public partial class Character
    {
        public override string ToString()
        {
            return $"This Character has id = {Id}";
        }
    }
}