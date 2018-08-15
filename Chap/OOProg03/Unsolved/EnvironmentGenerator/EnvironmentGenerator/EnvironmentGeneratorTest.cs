using System;
using EnvironmentGenerator.Environment;
using EnvironmentGenerator.ImplFuture;
using EnvironmentGenerator.ImplMedieval;
using EnvironmentGenerator.Interfaces;

namespace EnvironmentGenerator
{
    /// <summary>
    /// Class for invoking a test of the environment generator.
    /// </summary>
    public class EnvironmentGeneratorTest
    {
        public static void Run()
        {
            RunExisting();
            RunImproved();
        }

        private static void RunExisting()
        {
            Console.WriteLine("Test of EnvironmentGeneratorBase (flawed...)");
            IBuildingFactory bf = new BuildingFactoryFuture();
            ICreatureFactory cf = new CreatureFactoryMedieval();
            IWeaponFactory wf = new WeaponFactoryFuture();

            IEnvironmentGenerator generator = new EnvironmentGeneratorBase(bf, cf, wf);
            Generate(generator, 2, 3, 4);
            Console.WriteLine();
        }

        private static void RunImproved()
        {
            // UNCOMMENT THE BELOW LINES TO TEST YOUR IMPLEMENTATION OF
            // EnvironmentGeneratorMedival AND EnvironmentGeneratorFuture

            //Console.WriteLine("Test of EnvironmentGeneratorMedival");
            //IEnvironmentGenerator medievalFac = EnvironmentGeneratorFactory.Create(EnvironmentTypes.Medieval);
            //Generate(medievalFac, 2, 3, 4);
            //Console.WriteLine();

            //Console.WriteLine("Test of EnvironmentGeneratorFuture");
            //IEnvironmentGenerator futureFac = EnvironmentGeneratorFactory.Create(EnvironmentTypes.Future);
            //Generate(futureFac, 2, 3, 4);
            //Console.WriteLine();
        }

        /// <summary>
        /// Generate some objects of the three environment 
        /// element types: Buildings, Creatures and Weapons.
        /// </summary>
        private static void Generate(IEnvironmentGenerator generator, int noOfBuildings, int noOfCreatures, int noOfWeapons)
        {
            for (int i = 0; i < noOfBuildings; i++)
            {
                Console.WriteLine($"Generated building: {generator.GenerateBuilding().ElementDescription}");
            }

            for (int i = 0; i < noOfCreatures; i++)
            {
                Console.WriteLine($"Generated creature: {generator.GenerateCreature().ElementDescription}");
            }

            for (int i = 0; i < noOfWeapons; i++)
            {
                Console.WriteLine($"Generated weapon: {generator.GenerateWeapon().ElementDescription}");
            }
        }
    }
}