using System;
using System.Collections.Generic;
using FateV10.GameClasses;
using FateV10.GearClasses;

namespace FateV10
{
    public class Tester
    {
        public void Run()
        {
            // Create a hero and a Gear Generator
            GearGenerator gearGen = new GearGenerator();
            Hero heroA = new Hero("Andrus");

            // Give 50 pieces of Gear to our Hero.
            for (int i = 0; i < 50; i++)
            {
                heroA.AddGear(gearGen.Generate());
            }

            // Let's see what our Hero looks like:
            Console.WriteLine(heroA);
            Console.WriteLine();

            // Get the list of best Gear for Sun affinity.
            List<Gear> gearSun = heroA.BestGear(AffinityType.Sun);
            Console.WriteLine("Best Gear for Sun affinity");
            foreach (Gear g in gearSun)
            {
                Console.WriteLine(g);
            }
            Console.WriteLine();

            // Get the best GearBuild for Moon affinity.
            Console.WriteLine(heroA.BestGearBuild(AffinityType.Moon));
        }
    }
}