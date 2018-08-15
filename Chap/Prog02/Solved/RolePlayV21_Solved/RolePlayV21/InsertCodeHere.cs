using System;

namespace RolePlayV21
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            NumberGenerator generator = new NumberGenerator();
            BattleLog log = new BattleLog();

            // Original battle logic (1-on-1)
            #region 1-on-1 battle logic
            Hero theHero = new Hero(generator, log, "Olafur", 100, 10, 30);
            Beast theBeast = new Beast(generator, log, "Zakhial", 90, 10, 25);

            //while (!theHero.Dead && !theBeast.Dead)
            //{
            //    int damageByHero = theHero.DealDamage();
            //    theBeast.ReceiveDamage(damageByHero);

            //    if (!theBeast.Dead)
            //    {
            //        int damageByBeast = theBeast.DealDamage();
            //        theHero.ReceiveDamage(damageByBeast);
            //    }
            //}

            //log.PrintLog();
            //Console.WriteLine();
            //if (theBeast.Dead)
            //{
            //    Console.WriteLine($"The Hero {theHero.Name} was Victorious!!");
            //}
            //else
            //{
            //    Console.WriteLine($"The Beast {theBeast.Name} won... ;-(");
            //}
            #endregion


            // New battle logic (1-on-many)
            #region 1-on-many battle logic
            theHero.Reset();
            log.Reset();

            BeastArmy theArmy = new BeastArmy();
            Beast beast1 = new Beast(generator, log, "Alazaar", 40, 10, 25);
            Beast beast2 = new Beast(generator, log, "Bixuil", 20, 5, 15);
            Beast beast3 = new Beast(generator, log, "Carezhan", 30, 8, 12);

            theArmy.AddBeast(beast1);
            theArmy.AddBeast(beast2);
            theArmy.AddBeast(beast3);

            while (!theHero.Dead && !theArmy.Dead)
            {
                int damageByHero = theHero.DealDamage();
                theArmy.ReceiveDamage(damageByHero);

                if (!theArmy.Dead)
                {
                    int damageByArmy = theArmy.DealDamage();
                    theHero.ReceiveDamage(damageByArmy);
                }
            }

            log.PrintLog();
            Console.WriteLine();
            if (theArmy.Dead)
            {
                Console.WriteLine($"The Hero {theHero.Name} was Victorious!!");
            }
            else
            {
                Console.WriteLine($"The Beast Army won... ;-(");
                Console.WriteLine("Beasts alive: ");
                foreach (var beastName in theArmy.BeastsAlive)
                {
                    Console.WriteLine(beastName);
                }
            }
            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}