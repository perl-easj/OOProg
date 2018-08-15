using System.Collections.Generic;
using WesternStrike.Axes;
using WesternStrike.Bows;
using WesternStrike.Characters;
using WesternStrike.Guns;
using WesternStrike.Knives;
using WesternStrike.Rifles;

namespace WesternStrike.Combat
{
    public class CombatManager
    {
        public static void Execute()
        {
            Dictionary<string, double> exp_i1 = new Dictionary<string, double>();
            exp_i1.Add("Krieghoff", 1.2);
            exp_i1.Add("Tomahawk", 1.4);

            Dictionary<string, double> exp_i2 = new Dictionary<string, double>();
            exp_i2.Add("Damascus", 1.5);

            Dictionary<string, double> exp_i3 = new Dictionary<string, double>();
            exp_i3.Add("StrikerBow", 1.4);
            exp_i3.Add("DoubleAxe", 1.5);

            Dictionary<string, double> exp_i4 = new Dictionary<string, double>();
            exp_i4.Add("Remington", 1.35);

            Indian i1 = new Indian("Dances with Conditions", 250, exp_i1, 
                new Krieghoff(), 
                null, 
                null, 
                new JuniorBow(), 
                null, 
                new StrikerBow(), 
                null, 
                new DoubleAxe(), 
                new Tomahawk());

            Indian i2 = new Indian("Brown Exception", 240, exp_i2, 
                null, 
                new Remington(), 
                null, 
                null, 
                new LongBow(), 
                new StrikerBow(), 
                new Damascus(), 
                null, 
                null);

            Indian i3 = new Indian("Constructor of Spirits", 270, exp_i3, 
                null, 
                null, 
                null, 
                new JuniorBow(), 
                null, 
                new StrikerBow(), 
                null, 
                new DoubleAxe(), 
                new Tomahawk());

            Indian i4 = new Indian("<T>", 230, exp_i4,
                null,
                new Remington(), 
                null,
                null,
                null,
                new StrikerBow(),
                null,
                null,
                new Tomahawk());

            Dictionary<string, double> exp_p1 = new Dictionary<string, double>();
            exp_p1.Add("Colt", 1.4);
            exp_p1.Add("SmithWesson", 1.2);

            Dictionary<string, double> exp_p2 = new Dictionary<string, double>();
            exp_p2.Add("Winchester", 1.25);

            Dictionary<string, double> exp_p3 = new Dictionary<string, double>();
            exp_p3.Add("Colt", 1.3);
            exp_p3.Add("GutterKnife", 1.5);

            PaleFace p1 = new PaleFace("Sven", 280, exp_p1, 
                new Krieghoff(), 
                null, 
                null, 
                new Colt(), 
                null, 
                new SmithWesson(), 
                null, 
                new DundeeKnife(), 
                null);

            PaleFace p2 = new PaleFace("Oluf", 240, exp_p2, 
                null, 
                null, 
                new Winchester(), 
                null, 
                new RugerRevolver(), 
                new SmithWesson(), 
                new BowieKnife(), 
                null, 
                null);

            PaleFace p3 = new PaleFace("Bjarke", 270, exp_p3, 
                null, 
                null, 
                new Winchester(), 
                new Colt(),
                null, 
                null, 
                new BowieKnife(), 
                null, 
                new GutterKnife());

            List<Indian> indians = new List<Indian>();
            indians.Add(i1);
            indians.Add(i2);
            indians.Add(i3);
            indians.Add(i4);
            IndianGroup ig = new IndianGroup(indians);

            List<PaleFace> paleFaces = new List<PaleFace>();
            paleFaces.Add(p1);
            paleFaces.Add(p2);
            paleFaces.Add(p3);
            PaleFaceGroup pg = new PaleFaceGroup(paleFaces);

            DoCombat(ig, pg);
        }


        public static void DoCombat(IndianGroup ig, PaleFaceGroup pg)
        {
            while (!ig.Dead && !pg.Dead)
            {
                int coin = NumberGenerator.Next(0, 1);

                if (coin == 0) // Indians strike first
                {
                    Indian i1 = ig.SelectRandomIndian();
                    if (i1 != null)
                    {
                        PaleFace p1 = pg.SelectRandomPaleFace();
                        if (p1 != null)
                        {
                            p1.ReceiveDamage(i1.DealDamage());
                        }
                    }

                    PaleFace p2 = pg.SelectRandomPaleFace();
                    if (p2 != null)
                    {
                        Indian i2 = ig.SelectRandomIndian();
                        if (i2 != null)
                        {
                            i2.ReceiveDamage(p2.DealDamage());
                        }
                    }
                }
                else  // PaleFaces strike first
                {
                    PaleFace p2 = pg.SelectRandomPaleFace();
                    if (p2 != null)
                    {
                        Indian i2 = ig.SelectRandomIndian();
                        if (i2 != null)
                        {
                            i2.ReceiveDamage(p2.DealDamage());
                        }
                    }

                    Indian i1 = ig.SelectRandomIndian();
                    if (i1 != null)
                    {
                        PaleFace p1 = pg.SelectRandomPaleFace();
                        if (p1 != null)
                        {
                            p1.ReceiveDamage(i1.DealDamage());
                        }
                    }
                }
            }

            CombatLog.Save("--------------- BATTLE IS OVER ------------");
            CombatLog.Save((ig.Dead ? "Palefaces" : "Indians") + " won! Status: ");
            ig.LogSurvivors();
            pg.LogSurvivors();

            CombatLog.PrintLog();
        }
    }
}