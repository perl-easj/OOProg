using System;

namespace GenericsDogsAndCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Dog objects
            Dog dog1 = new Dog("King", 70, 55);
            Dog dog2 = new Dog("Spot", 30, 10);
            Dog dog3 = new Dog("Rufus", 80, 40);
            #endregion

            #region Circle objects
            Circle c1 = new Circle(10, 2, 3);
            Circle c2 = new Circle(15, 6, 0);
            Circle c3 = new Circle(8, 12, 7);
            #endregion

            #region ObjectComparer test
            ObjectComparer comparer = new ObjectComparer();
            Console.WriteLine(comparer.LargestDog(dog1, dog2, dog3));
            Console.WriteLine(comparer.LargestCircle(c1, c2, c3)); 
            #endregion

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
