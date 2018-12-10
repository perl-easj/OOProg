// HISTORIK:
// v.1.0 : Oprettet, override af ToString.
//

using System.Collections.Generic;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch
{
    public partial class WeaponModel : DomainClassBase<WeaponModel>
    {
        public const int MaxNoOfJewelSockets = 5;

        public static List<int> LegalDamageValues = new List<int>
        {
            1, 2, 3, 5, 7,
            10, 15, 20, 25, 30, 35, 40, 50, 60, 70, 80, 90,
            100, 150, 200, 250, 300, 350, 400, 500, 600, 700, 800, 900,
            1000, 1500, 2000, 2500, 3000, 3500, 4000, 5000, 6000, 7000, 8000, 9000,
            10000
        };

        public override int GetId()
        {
            return Id;
        }

        public override void SetId(int id)
        {
            Id = id;
        }

        public override void CopyValuesFromObj(WeaponModel obj)
        {
            Description = obj.Description;
            WeaponTypeId = obj.WeaponTypeId;
            RarityTierId = obj.RarityTierId;
            JewelSockets = obj.JewelSockets;
            MinDamage = obj.MinDamage;
            MaxDamage = obj.MaxDamage;
        }

        public bool CheckMaxDamage(int valMaxDamage)
        {
            return valMaxDamage >= MinDamage;
        }

        public bool CheckMinDamage(int valMinDamage)
        {
            return valMinDamage <= MaxDamage;
        }
    }
}