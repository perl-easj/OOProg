using System;

namespace SOLID.Liskov.No
{
    public class AnimalFactory
    {
        public static Animal CreateIAnimal(AnimalType animalType, double weight)
        {
            if (animalType == AnimalType.cat) return new Cat(weight);
            if (animalType == AnimalType.dog) return new Dog(weight);
            if (animalType == AnimalType.tiger) return new Tiger(weight);

            throw new ArgumentException($"Unknown animal type {animalType}");
        }
    }
}