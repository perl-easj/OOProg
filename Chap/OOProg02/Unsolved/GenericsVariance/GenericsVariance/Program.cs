using System;
using GenericsVariance.Animals;
using GenericsVariance.Collections;

namespace GenericsVariance
{
    class Program
    {
        static void Main(string[] args)
        {
            // No problem, since Collection implements 
            // ICollectionGet and ICollectionSet
            Collection<Bird> birds = new Collection<Bird>();
            ICollectionGet<Bird> birdsGet = birds;
            ICollectionSet<Bird> birdsSet = birds;

            // No problem, since Collection implements 
            // ICollectionGet and ICollectionSet
            Collection<Animal> animals = new Collection<Animal>();
            ICollectionGet<Animal> animalsGet = animals;
            ICollectionSet<Animal> animalsSet = animals;


            AnimalProcessor processor = new AnimalProcessor();

            // How many of these work...?
            //
            //processor.ProcessAnimals(birdsGet);   // Case A
            //processor.ProcessAnimals(animalsGet); // Case B

            //processor.ProcessBirds(birdsGet);     // Case C
            //processor.ProcessBirds(animalsGet);   // Case D

            //processor.InsertAnimals(birdsSet);    // Case E
            //processor.InsertAnimals(animalsSet);  // Case F

            //processor.InsertBirds(birdsSet);      // Case G
            //processor.InsertBirds(animalsSet);    // Case H

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
