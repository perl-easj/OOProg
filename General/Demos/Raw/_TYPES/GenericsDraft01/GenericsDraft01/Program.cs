using System;
using System.Collections.Generic;

namespace GenericsDraft01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog self = new Dog("King", 70);
            Dog mom = new Dog("Spot", 30);
            Dog dad = new Dog("Rufus", 80);

            FamilyRelation<Dog> relations = new FamilyRelation<Dog>(self, mom, dad);
            relations.AddChild(new Dog("Lajka", 45));

            Cat aCat = new Cat("Stripe", 8);
            Cat bCat = new Cat("Socks", 5);
            Cat cCat = new Cat("Abby", 4);

            FamilyRelation<Cat> catRelations = new FamilyRelation<Cat>(aCat, bCat, cCat);

            Animal a = new Dog("Vigga", 10);

            ICGet<Animal> icsa = new C<Dog>();
            ICSet<Dog> icgd = new C<Animal>();

            List<Dog> animals = new List<Dog>();
            animals.Add(new Dog("King", 70));
            animals.Add(new Dog("Spot", 30));
            animals.Add(new Dog("Rufus", 80));

            IComparer<Animal> comparer = new AnimalComparerByWeight();
            animals.Sort(comparer);

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Weight);
            }

            A swapper = new A();
            int x = 12;
            int y = 21;
            swapper.Swap<int>(ref x, ref y);

            // ...and so on
            KeepConsoleWindowOpen();
        }


        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }

        private static void ComparerTests()
        {
            Dog dog1 = new Dog("King", 70);
            Dog dog2 = new Dog("Spot", 30);
            Dog dog3 = new Dog("Rufus", 80);

            Circle c1 = new Circle(10, 2, 3);
            Circle c2 = new Circle(15, 6, 0);
            Circle c3 = new Circle(8, 12, 7);


            ObjectComparer comparer = new ObjectComparer();

            Console.WriteLine(comparer.LargestDog(dog1, dog2, dog3));
            Console.WriteLine(comparer.LargestCircle(c1, c2, c3));


            BetterObjectComparer<Dog> dogObjectComparer = new BetterObjectComparer<Dog>();
            BetterObjectComparer<Circle> circleObjectComparer = new BetterObjectComparer<Circle>();

            Console.WriteLine(dogObjectComparer.Largest(dog1, dog2, dog3));
            Console.WriteLine(circleObjectComparer.Largest(c1, c2, c3));


            EvenBetterObjectComparer omniComparer = new EvenBetterObjectComparer();
            IComparer<Dog> dogCompare = new DogCompareByHeight();
            IComparer<Circle> circleComparer = new CircleCompareByX();

            Console.WriteLine(omniComparer.Largest(dog1, dog2, dog3, dogCompare));
            Console.WriteLine(omniComparer.Largest(c1, c2, c3, circleComparer));
        }

        private static void VarianceTests()
        {
            // No problem, obviously
            Bird b = new Bird("Olaf");
            Console.WriteLine(b.Sound());

            // No problem, since Bird inherits from Animal
            Animal a = new Bird("Piphans");
            Console.WriteLine(a.Sound());

            // No problem, since AnimalCollection implements 
            // ICollectionGet and ICollectionSet
            Collection<Bird> birds = new Collection<Bird>();
            ICollectionGet<Bird> birdsGet = birds;
            ICollectionSet<Bird> birdsSet = birds;

            // No problem, since AnimalCollection implements 
            // ICollectionGet and ICollectionSet
            Collection<Animal> animals = new Collection<Animal>();
            ICollectionGet<Animal> animalsGet = animals;
            ICollectionSet<Animal> animalsSet = animals;


            AnimalProcessor processor = new AnimalProcessor();

            // How many of these work...?
            ////
            //processor.ProcessAnimals(birdsGet);   // Case A
            //processor.ProcessAnimals(animalsGet); // Case B

            //processor.ProcessBirds(birdsGet);     // Case C
            //processor.ProcessBirds(animalsGet);   // Case D

            //processor.InsertAnimals(birdsSet);    // Case E
            //processor.InsertAnimals(animalsSet);  // Case F

            //processor.InsertBirds(birdsSet);      // Case G
            //processor.InsertBirds(animalsSet);    // Case H           
        }
    }
}
