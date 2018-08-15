using System;

namespace Fight1v1
{
    /// <summary>
    /// Factory class for producing a fight manager object,
    /// according to the specified fight type.
    /// </summary>
    public class Fight1v1ManagerFactory
    {
        public static IFight1v1Manager Create(FightType type, Player playerA, Player playerB, int noOfFights)
        {
            switch (type)
            {
                case FightType.Fair:
                    return new Fight1v1ManagerFair(playerA, playerB, noOfFights);
                case FightType.BiasedA:
                    return new Fight1v1ManagerBiasedA(playerA, playerB, noOfFights);
                default:
                    throw new ArgumentException($"No class corresponding to fight type {type} is available.");
            }
        }
    }
}