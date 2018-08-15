using System;
// ReSharper disable ConvertIfStatementToConditionalTernaryExpression

namespace RolePlayV21
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            NumberGenerator generator = new NumberGenerator();
            BattleLog log = new BattleLog();

            // Battle logic (1-on-1)
            #region 1-on-1 battle logic
            Hero theHero = new Hero(generator, log, "Olafur", 100, 10, 30);
            Beast theBeast = new Beast(generator, log, "Zakhial", 90, 10, 25);

            while (!theHero.Dead && !theBeast.Dead)
            {
                int damageByHero = theHero.DealDamage();
                theBeast.ReceiveDamage(damageByHero);

                if (!theBeast.Dead)
                {
                    int damageByBeast = theBeast.DealDamage();
                    theHero.ReceiveDamage(damageByBeast);
                }
            }

            log.PrintLog();
            Console.WriteLine();
            if (theBeast.Dead)
            {
                Console.WriteLine($"The Hero {theHero.Name} was Victorious!!");
            }
            else
            {
                Console.WriteLine($"The Beast {theBeast.Name} won... ;-(");
            }
            #endregion


            // New battle logic (1-on-many)
            #region 1-on-many battle logic

            // TODO - implement 1-on-many battle logic

            #endregion

            // The LAST line of code should be ABOVE this line
        }
    }
}