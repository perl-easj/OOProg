using System;

namespace Fight1v1
{
    /// <summary>
    /// Class for invoking a test of fighting managers.
    /// The specific kind of fighting manager is in each 
    /// case specified as a parameter to the call of Create.
    /// </summary>
    public class Fight1v1ManagerTest
    {
        public static void Run()
        {
            Console.WriteLine("Testing fair strategy...");
            Fight1v1ManagerTest.NowFight(FightType.Fair);

            Console.WriteLine("Testing biased strategy...");
            Fight1v1ManagerTest.NowFight(FightType.BiasedA);
        }

        public static void NowFight(FightType type, int noOfFights = 100000)
        {
            // Feel free to try out a different pair of Players...
            Player playerA = new Player("Adolf", 100, 30);
            Player playerB = new Player("Josef", 120, 25);

            IFight1v1Manager fightManager = Fight1v1ManagerFactory.Create(type, playerA, playerB, noOfFights);
            fightManager.Fight();
        }
    }
}