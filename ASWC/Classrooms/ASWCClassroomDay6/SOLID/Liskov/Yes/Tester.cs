using System;
using System.Collections.Generic;

namespace SOLID.Liskov.Yes
{
    public class Tester
    {
        public void Run()
        {
            List<AnimalType> animalTypesIAnimal = new List<AnimalType>
            {
                AnimalType.cat, AnimalType.dog, AnimalType.tiger, AnimalType.siamese
            };

            List<AnimalType> animalTypesILargeSizeAnimal = new List<AnimalType>
            {
                AnimalType.dog, AnimalType.tiger
            };

            List<AnimalType> animalTypesINormalSizeAnimal = new List<AnimalType>
            {
                AnimalType.cat, AnimalType.siamese
            };

            List<AnimalType> animalTypesIHuntedAnimal = new List<AnimalType>
            {
                AnimalType.cat, AnimalType.dog, AnimalType.siamese
            };

            Console.WriteLine("UseIAnimalObject");
            animalTypesIAnimal.ForEach(UseIAnimalObject);
            Console.WriteLine();

            Console.WriteLine("UseILargeSizeAnimalObject");
            animalTypesILargeSizeAnimal.ForEach(UseILargeSizeAnimalObject);
            Console.WriteLine();

            Console.WriteLine("UseINormalSizeAnimalObject");
            animalTypesINormalSizeAnimal.ForEach(UseINormalSizeAnimalObject);
            Console.WriteLine();

            Console.WriteLine("UseIHuntedAnimalObject");
            animalTypesIHuntedAnimal.ForEach(UseIHuntedAnimalObject);
            Console.WriteLine();
        }

        private void UseIAnimalObject(AnimalType animalType)
        {
            try
            {
                // Make and use animal
                IAnimal anAnimal = AnimalFactory.CreateIAnimalObject(animalType);
                Console.WriteLine(anAnimal.Description);
                Console.WriteLine(anAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when calling anAnimal.WeightInKg");
            }
        }

        private void UseILargeSizeAnimalObject(AnimalType animalType)
        {
            try
            {
                ILargeSizeAnimal largeAnimal = AnimalFactory.CreateILargeSizeAnimalObject(animalType);
                largeAnimal.WeightInKg = 10;
                Console.WriteLine(largeAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using largeAnimal");
            }

            try
            {
                ILargeSizeAnimal tooSmallAnimal = AnimalFactory.CreateILargeSizeAnimalObject(animalType);
                tooSmallAnimal.WeightInKg = 0.2;
                Console.WriteLine(tooSmallAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using tooSmallAnimal");
            }
        }

        private void UseINormalSizeAnimalObject(AnimalType animalType)
        {
            try
            {
                INormalSizeAnimal largeAnimal = AnimalFactory.CreateINormalSizeAnimalObject(animalType);
                largeAnimal.WeightInKg = 10;
                Console.WriteLine(largeAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using largeAnimal");
            }

            try
            {
                INormalSizeAnimal smallAnimal = AnimalFactory.CreateINormalSizeAnimalObject(animalType);
                smallAnimal.WeightInKg = 0.2;
                Console.WriteLine(smallAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using smallAnimal");
            }

            try
            {
                INormalSizeAnimal tooSmallAnimal = AnimalFactory.CreateINormalSizeAnimalObject(animalType);
                tooSmallAnimal.WeightInKg = 0.00002;
                Console.WriteLine(tooSmallAnimal.WeightInKg);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using tooSmallAnimal");
            }
        }

        private void UseIHuntedAnimalObject(AnimalType animalType)
        {
            try
            {
                IHuntedAnimal huntedAnimal = AnimalFactory.CreateIHuntedAnimalObject(animalType);
                huntedAnimal.IsHuntedBy = new Tiger();
                Console.WriteLine(huntedAnimal.IsHuntedBy.Description);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got exception {e.Message} when using huntedAnimal");
            }
        }
    }
}