using System;
using System.Linq;
using RpgV1.Participants;
using RpgV1.Spells;

namespace RpgV1
{
    public class Tester
    {
        public void Run()
        {
            #region Create Players
            Player pA = new Player("Allux", 3);
            pA[SpellType.alphaBeam] = 50;
            pA[SpellType.iceStorm] = 30;
            pA[SpellType.sunLance] = 20;

            Player pB = new Player("Beatha", 5);
            pB[SpellType.alphaBeam] = 40;
            pB[SpellType.starBurst] = 30;
            pB[SpellType.sunLance] = 30;

            Player pC = new Player("Castor", 3);
            pC[SpellType.alphaBeam] = 75;
            pC[SpellType.iceStorm] = 10;
            pC[SpellType.lavaFlow] = 15;

            Player pD = new Player("Daruna", 6);
            pD[SpellType.steamSurge] = 45;
            pD[SpellType.iceStorm] = 30;
            pD[SpellType.sunLance] = 20;
            pD[SpellType.starBurst] = 5;

            Player pE = new Player("Erica", 5);
            pE[SpellType.alphaBeam] = 50;
            pE[SpellType.steamSurge] = 25;
            pE[SpellType.sunLance] = 10;
            pE[SpellType.lavaFlow] = 15;
            #endregion


            #region Adding and printing Players
            PrintParticipant(pA);
            PrintParticipant(pB);

            Player pAB = pA + pB;
            PrintParticipant(pAB);
            #endregion


            #region Create and print an Opponent
            Opponent oA = new Opponent("Zerxis", 7);
            oA[SpellType.alphaBeam] = 40;
            oA[SpellType.starBurst] = 25;
            oA[SpellType.iceStorm] = 75;
            oA[SpellType.sunLance] = 20;
            oA[SpellType.steamSurge] = 55;
            oA[SpellType.lavaFlow] = 55;

            PrintParticipant(oA);
            #endregion


            #region Calculate and print DPS (Two players vs. Opponent)
            double dps2 = pAB * oA;

            Console.WriteLine();
            Console.WriteLine($"DPS (two players) --> {dps2:F2}");
            #endregion


            #region Calculate and print DPS (Five players vs. Opponent)
            double dps5 = (pA + pB + pC + pD + pE) * oA;

            Console.WriteLine();
            Console.WriteLine($"DPS (five players) --> {dps5:F2}");
            #endregion
        }

        private void PrintParticipant(ParticipantBase aParticipant)
        {
            Console.WriteLine();
            Console.WriteLine(aParticipant.Name);

            // This foreach-loop uses the index operator to look up
            // values in the SpellVector
            Console.WriteLine("Original values in SpellVector");
            foreach (SpellType sp in Spell.SpellTypeList.OrderBy(p => p.ToString()))
            {
                Console.WriteLine($"{sp.ToString().PadRight(12)} -->   {aParticipant[sp]:F2}");
            }

            // This foreach-loop iterates directly over the aParticipant object
            Console.WriteLine("Modified values in SpellVector");
            foreach (var pair in aParticipant.OrderBy(p => p.Item1.ToString()))
            {
                Console.WriteLine($"{pair.Item1.ToString().PadRight(12)} -->   {pair.Item2:F2}");
            }

            Console.WriteLine();
        }
    }
}