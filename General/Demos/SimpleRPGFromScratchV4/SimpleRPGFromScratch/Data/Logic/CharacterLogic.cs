// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class Character : DomainClassBase<Character>
    {
        public const int MaxLevel = 20;
        public const int MaxHealthPoints = 2000;

        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(Character obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            HealthPoints = obj.HealthPoints;
            Level = obj.Level;
        }

        public override bool IsValid
        {
            get
            {
                return 
                    (Name != null) &&
                    (Name.Length > 2) && 
                    (HealthPoints > 0) && 
                    (Level > 0) &&
                    (Level < 100);
            }
        }
    }
}