using System;
using System.Collections.Generic;
using SOLID.Liskov;
using SOLID.Liskov.Company;
using SOLID.Liskov.Composition;
using SOLID.Liskov.Yes;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWorld aWorld = new WorldManyAnimals();
            //IAnimalLibrary aLib = new AnimalLibrary();

            //DI.Cat diCat = new DI.Cat(aWorld);
            //SingleResp.Cat srCat = new SingleResp.Cat(aWorld, aLib);

            // Tester aTester = new Tester();
            // aTester.Run();

            //Liskov.Composition.Cat aCat = new Liskov.Composition.Cat(0.5);
            //Console.WriteLine(aCat);

            //Liskov.Composition.Dog aDog = new Liskov.Composition.Dog(2.5);
            //Console.WriteLine(aDog);

            //Liskov.Composition.Tiger aTiger = new Liskov.Composition.Tiger(200);
            //Console.WriteLine(aTiger);

            Client2 aClient = new Client2();
            aClient.Run();

            Console.ReadKey();
        }
    }
}
