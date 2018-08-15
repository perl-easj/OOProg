using System.Collections.Generic;
using WesternStrike.Characters.Base;
using WesternStrike.Inventory.Types;
using WesternStrike.Weapons.Types.Guns;
using WesternStrike.Weapons.Types.Knives;
using WesternStrike.Weapons.Types.Rifles;

namespace WesternStrike.Characters.Types.PaleFace
{
    public class PaleFaceGroup : Group<PaleFace>
    {
        public PaleFaceGroup() : base("Palefaces")
        {
            #region PaleFace Weapon setup
            PaleFaceInventory wi_p1 = new PaleFaceInventory();
            wi_p1.AddWeapon(new Krieghoff(true));
            wi_p1.AddWeapon(new Colt());
            wi_p1.AddWeapon(new SmithWesson());
            wi_p1.AddWeapon(new DundeeKnife());

            PaleFaceInventory wi_p2 = new PaleFaceInventory();
            wi_p2.AddWeapon(new Winchester());
            wi_p2.AddWeapon(new RugerRevolver());
            wi_p2.AddWeapon(new SmithWesson());
            wi_p2.AddWeapon(new BowieKnife());

            PaleFaceInventory wi_p3 = new PaleFaceInventory();
            wi_p3.AddWeapon(new Winchester());
            wi_p3.AddWeapon(new Colt());
            wi_p3.AddWeapon(new BowieKnife());
            wi_p3.AddWeapon(new GutterKnife());
            #endregion

            #region PaleFace Expertice setup
            Dictionary<string, double> exp_p1 = new Dictionary<string, double>();
            exp_p1.Add(Gun.Colt, 1.4);
            exp_p1.Add(Gun.SmithWesson, 1.2);

            Dictionary<string, double> exp_p2 = new Dictionary<string, double>();
            exp_p2.Add(Rifle.Winchester, 1.25);

            Dictionary<string, double> exp_p3 = new Dictionary<string, double>();
            exp_p3.Add(Gun.Colt, 1.3);
            exp_p3.Add(Knife.Gutter, 1.5);
            #endregion

            #region PaleFace Member setup
            AddMember(new PaleFace("Sven", 280, wi_p1, exp_p1));
            AddMember(new PaleFace("Oluf", 240, wi_p2, exp_p2));
            AddMember(new PaleFace("Bjarke", 270, wi_p3, exp_p3));
            #endregion
        }
    }
}