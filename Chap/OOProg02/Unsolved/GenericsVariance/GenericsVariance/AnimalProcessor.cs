using System;
using GenericsVariance.Animals;
using GenericsVariance.Collections;

namespace GenericsVariance
{
    public class AnimalProcessor
    {
        public void ProcessAnimals(ICollectionGet<Animal> animals)
        {
            for (int index = 0; index < animals.Count; index++)
            {
                Console.WriteLine(animals.Get(index).Sound());
                // animals.GetAnimal(index).FlapWings(); // Why does this NOT work...?
            }
        }

        public void ProcessBirds(ICollectionGet<Bird> birds)
        {
            for (int index = 0; index < birds.Count; index++)
            {
                Console.WriteLine(birds.Get(index).Sound());
                birds.Get(index).FlapWings(); // Why does this work..?
            }
        }

        public void InsertAnimals(ICollectionSet<Animal> animals)
        {
            for (int index = 0; index < 5; index++)
            {
                Bird b = new Bird("Tweety");
                b.FlapWings();
                animals.Set(b); // Why does this work..?

                Cat c = new Cat("Spot");
                c.Purr();
                animals.Set(c); // Why does this work..?
            }
        }

        public void InsertBirds(ICollectionSet<Bird> birds)
        {
            for (int index = 0; index < 5; index++)
            {
                Bird b = new Bird("Tweety");
                b.FlapWings();
                birds.Set(b);

                Cat c = new Cat("Spot");
                c.Purr();
                // birds.SetAnimal(c); // Why does this NOT work...?
            }
        }
    }
}