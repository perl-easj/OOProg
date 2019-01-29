using System;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            // I would like to be able to:
            // 1) Create a Beast object. (Done)
            Beast aBeast = new Beast("Dragon", 250);

            // 2) Create some Wizard and Hunter objects. (Done)
            Wizard w1 = new Wizard("Alumel", 200, 1.2, 30);
            Wizard w2 = new Wizard("Beritza", 180, 1.1, 40);
            Wizard w3 = new Wizard("Cerquin", 140, 1.25, 25);
            Hunter h1 = new Hunter("Daniela", 165, 0.95, 55);
            Hunter h2 = new Hunter("Eras", 175, 1.15, 40);

            // 3) Create a List object, into which I can insert Wizard and Hunter objects. (NOT Done)
            // In order to be able to do this, you probably need to define a base class, and let
            // Hunter and Wizard inherit from this class.


            // 4) Let each of the Wizard/Hunters in the List deal damage to the Beast. (NOT Done)


            // 5) Check if the Beast is dead or not, and announce the outcome. (Done)
            Console.WriteLine($"Beast {(aBeast.Dead ? "is dead" : "still has " + aBeast.HealthPoints + " HP left")}, " +
                              $"our heroes were {(aBeast.Dead ? "victorious!" : "weaklings...")}");

            WaitForKey();
        }

        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close Application...");
            Console.ReadKey();
        }
    }
}
