using System.Collections.Generic;
using WesternStrike.Characters.Base;
using WesternStrike.Inventory.Types;
using WesternStrike.Weapons.Types.Axes;
using WesternStrike.Weapons.Types.Bows;
using WesternStrike.Weapons.Types.Guns;
using WesternStrike.Weapons.Types.Rifles;

namespace WesternStrike.Characters.Types.Indian
{
    public class IndianGroup : Group<Indian>
    {
        public IndianGroup() : base("Indians")
        {
            #region Indian Weapon setup
            IndianInventory wi_i1 = new IndianInventory();
            wi_i1.AddWeapon(new Krieghoff());
            wi_i1.AddWeapon(new JuniorBow());
            wi_i1.AddWeapon(new StrikerBow());
            wi_i1.AddWeapon(new DoubleAxe());
            wi_i1.AddWeapon(new Tomahawk());

            IndianInventory wi_i2 = new IndianInventory();
            wi_i2.AddWeapon(new Remington());
            wi_i2.AddWeapon(new LongBow());
            wi_i2.AddWeapon(new StrikerBow());
            wi_i2.AddWeapon(new Damascus());

            IndianInventory wi_i3 = new IndianInventory();
            wi_i3.AddWeapon(new Colt());
            wi_i3.AddWeapon(new JuniorBow());
            wi_i3.AddWeapon(new StrikerBow());
            wi_i3.AddWeapon(new DoubleAxe());
            wi_i3.AddWeapon(new Tomahawk());

            IndianInventory wi_i4 = new IndianInventory();
            wi_i4.AddWeapon(new Remington());
            wi_i4.AddWeapon(new StrikerBow());
            wi_i4.AddWeapon(new Tomahawk());
            #endregion

            #region Indian Expertice setup
            Dictionary<string, double> exp_i1 = new Dictionary<string, double>();
            exp_i1.Add(Rifle.Krieghoff, 1.2);
            exp_i1.Add(Axe.Tomahawk, 1.4);

            Dictionary<string, double> exp_i2 = new Dictionary<string, double>();
            exp_i2.Add(Axe.Damascus, 1.5);

            Dictionary<string, double> exp_i3 = new Dictionary<string, double>();
            exp_i3.Add(Gun.Colt, 0.75);
            exp_i3.Add(Bow.Striker, 1.4);
            exp_i3.Add(Axe.DoubleAxe, 1.5);

            Dictionary<string, double> exp_i4 = new Dictionary<string, double>();
            exp_i4.Add(Rifle.Remington, 1.35);
            #endregion

            #region Indian Member setup
            AddMember(new Indian("Dances with Conditions", 250, wi_i1, exp_i1));
            AddMember(new Indian("Brown Exception", 240, wi_i2, exp_i2));
            AddMember(new Indian("Constructor of Spirits", 270, wi_i3, exp_i3));
            AddMember(new Indian("<T>", 230, wi_i4, exp_i4));
            #endregion
        }
    }
}