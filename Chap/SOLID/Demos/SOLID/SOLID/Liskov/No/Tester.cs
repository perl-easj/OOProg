using System;
using System.Collections.Generic;

namespace SOLID.Liskov.No
{
    public class Tester
    {
        public void Run()
        {
            List<AnimalType> animalTypes = new List<AnimalType>
            {
                AnimalType.cat,
                AnimalType.dog,
                AnimalType.tiger
            };

            animalTypes.ForEach(UseAnimalObject);            
        }

        private void UseAnimalObject(AnimalType animalType)
        {
            Dog aDog = new Dog(25);

            // Make and use small animal
            Animal smallAnimal = AnimalFactory.CreateIAnimal(animalType, 0.2);
            Console.WriteLine(smallAnimal);

            smallAnimal.IsHuntedBy = aDog;
            Console.WriteLine(smallAnimal);

            // Make and use large animal
            Animal largeAnimal = AnimalFactory.CreateIAnimal(animalType, 10);
            Console.WriteLine(largeAnimal);

            largeAnimal.IsHuntedBy = aDog;
            Console.WriteLine(largeAnimal);
        }
    }
}