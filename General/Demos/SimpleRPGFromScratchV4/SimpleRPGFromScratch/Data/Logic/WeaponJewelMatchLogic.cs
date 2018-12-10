using System.Collections.Generic;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponJewelMatch : DomainClassBase<WeaponJewelMatch>
    {
        public static List<double> LegalMatchFactors = new List<double>
            { 0.3, 0.4, 0.5, 0.6, 0.8,
              1.0, 1.1, 1.2, 1.3, 1.5, 1.8,
              2.0, 2.2, 2.5, 2.8, 3.0 };

        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(WeaponJewelMatch obj)
        {
            JewelModelId = obj.JewelModelId;
            WeaponModelId = obj.WeaponModelId;
            Factor = obj.Factor;
        }
    }
}