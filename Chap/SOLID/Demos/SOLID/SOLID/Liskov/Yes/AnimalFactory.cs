using System;

namespace SOLID.Liskov.Yes
{
    public class AnimalFactory
    {
        public static IAnimal CreateIAnimalObject(AnimalType animalType)
        {
            if (animalType == AnimalType.cat) return new Cat();
            if (animalType == AnimalType.dog) return new Dog();
            if (animalType == AnimalType.tiger) return new Tiger();
            if (animalType == AnimalType.siamese) return new Siamese();

            throw new ArgumentException($"Unknown or incompatible animal type {animalType}");
        }

        public static ILargeSizeAnimal CreateILargeSizeAnimalObject(AnimalType animalType)
        {
            // if (animalType == AnimalType.cat) return new Cat();
            if (animalType == AnimalType.dog) return new Dog();
            if (animalType == AnimalType.tiger) return new Tiger();

            throw new ArgumentException($"Unknown or incompatible animal type {animalType}");
        }

        public static INormalSizeAnimal CreateINormalSizeAnimalObject(AnimalType animalType)
        {
            if (animalType == AnimalType.cat) return new Cat();
            if (animalType == AnimalType.siamese) return new Siamese();
            // if (animalType == AnimalType.dog) return new Dog();
            // if (animalType == AnimalType.tiger) return new Tiger();

            throw new ArgumentException($"Unknown or incompatible animal type {animalType}");
        }

        public static IHuntedAnimal CreateIHuntedAnimalObject(AnimalType animalType)
        {
            if (animalType == AnimalType.cat) return new Cat();
            if (animalType == AnimalType.dog) return new Dog();
            if (animalType == AnimalType.siamese) return new Siamese();
            // if (animalType == AnimalType.tiger) return new Tiger();

            throw new ArgumentException($"Unknown or incompatible animal type {animalType}");
        }
    }
}