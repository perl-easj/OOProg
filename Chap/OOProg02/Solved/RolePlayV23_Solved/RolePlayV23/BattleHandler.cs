namespace RolePlayV23
{
    /// <summary>
    /// This class handles the general battle mechanics:
    /// Keep fighting until one group is dead.
    /// </summary>
    public class BattleHandler
    {
        public static void DoBattle(CharacterGroup groupA, CharacterGroup groupB)
        {
            while (!groupA.Dead && !groupB.Dead)
            {
                groupB.ReceiveDamage(groupA.DealDamage());

                if (!groupB.Dead)
                {
                    groupA.ReceiveDamage(groupB.DealDamage());
                }
            }

            BattleLog.Save("--------------- BATTLE IS OVER ------------");
            BattleLog.Save((groupA.Dead ? groupB.GroupName : groupA.GroupName) + " won! Status: ");
            groupA.LogSurvivor();
            groupB.LogSurvivor();

            BattleLog.PrintLog();
        }
    }
}
