using System;
using System.Collections.Generic;
using NPCAnimationManager.Common.Interfaces;
using NPCAnimationManager.Original;
// ReSharper disable UnusedMember.Local

namespace NPCAnimationManager
{
    public class Tester
    {
        const int noOfNPCs = 5000;

        public void Run()
        {
            TestOriginal();
        }

        /// <summary>
        /// Test original NPC generation.
        /// NB: Will use about 0,1 MB per NPC.
        /// </summary>
        private void TestOriginal()
        {
            INPCFactory npcFac = new NPCFactory();
            List<INPC> allNPCs = CreateNPCs(npcFac);
            AnimateAll(allNPCs);
            DoneWithTest("(original)");
        }

        private List<INPC> CreateNPCs(INPCFactory npcFac)
        {
            List<INPC> all = new List<INPC>();
            for (int i = 0; i < noOfNPCs; i++)
            {
                all.Add(npcFac.Create());
            }
            return all;
        }

        private void AnimateAll(List<INPC> all)
        {
            foreach (INPC npc in all)
            {
                npc.Animate();
            }
        }

        private void DoneWithTest(string testDesc)
        {
            Console.WriteLine();
            Console.WriteLine($"Using {testDesc} creation strategy");
            Console.WriteLine($"Created and Animated {noOfNPCs} NPCs");
            Console.WriteLine();
        }
    }
}