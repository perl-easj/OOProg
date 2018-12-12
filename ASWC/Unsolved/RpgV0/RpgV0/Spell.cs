using System.Collections.Generic;

namespace RpgV0
{
    public class Spell
    {
        public string Description { get; }
        public int BenefitPercent { get; }
        public List<RoleType> Beneficiaries { get; }

        public Spell(string description, int benefitPercent, List<RoleType> beneficiaries)
        {
            Description = description;
            BenefitPercent = benefitPercent;
            Beneficiaries = beneficiaries;
        }
    }
}