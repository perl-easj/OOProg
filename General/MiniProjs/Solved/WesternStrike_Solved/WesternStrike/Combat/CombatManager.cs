using WesternStrike.Characters;
using WesternStrike.Characters.Base;

namespace WesternStrike.Combat
{
    public class CombatManager
    {
        public static void DoCombat<T,V>(Group<T> gA, Group<V> gB) 
            where T : Character
            where V : Character
        {
            while (!gA.Dead && !gB.Dead)
            {
                int coin = NumberGenerator.Next(0, 1);

                if (coin == 0) // Group A strikes first
                {
                    Do1on1Combat(gA.SelectRandomMember(), gB.SelectRandomMember());
                }
                else // Group B strikes first
                {
                    Do1on1Combat(gB.SelectRandomMember(), gA.SelectRandomMember());
                }
            }

            CombatLog.Save("--------------- BATTLE IS OVER ------------");
            CombatLog.Save((gA.Dead ? gB.ID : gA.ID) + " won! Status: ");
            gA.LogSurvivors();
            gB.LogSurvivors();

            CombatLog.PrintLog();
        }

        private static void Do1on1Combat(Character cA, Character cB)
        {
            if (cA != null && !cA.Dead)
            {
                cB?.ReceiveDamage(cA.DealDamage());
            }

            if (cB != null && !cB.Dead)
            {
                cA?.ReceiveDamage(cB.DealDamage());
            }
        }
    }
}