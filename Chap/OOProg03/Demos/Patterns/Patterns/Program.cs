using System;
using System.Collections.Generic;
using Patterns.Composite.Interface;
using Patterns.Composite.Items;
using Patterns.Composite.Simple;
using Patterns.Flyweight;
// ReSharper disable CollectionNeverQueried.Local

//using Patterns.Visitor.Collections;
//using Patterns.Visitor.Interfaces;
//using Patterns.Visitor.Items;
//using Patterns.Visitor.Visitors;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //FightFactoryImpl fsFac = new FightFactoryImpl();
            //fsFac.AddStrategy(Affinity.sun, FightTactic.defensive, new SunFightDefensive());
            //fsFac.AddStrategy(Affinity.sun, FightTactic.offensive, new SunFightOffensive());
            //fsFac.AddStrategy(Affinity.moon, FightTactic.defensive, new MoonFightDefensive());
            //fsFac.AddStrategy(Affinity.moon, FightTactic.offensive, new MoonFightOffensive());
            //fsFac.AddStrategy(Affinity.stars, FightTactic.defensive, new StarsFightDefensive());
            //fsFac.AddStrategy(Affinity.stars, FightTactic.offensive, new StarsFightOffensive());

            //IPlayer playerA = new Player("Alex", 200, Affinity.moon, fsFac);
            //IPlayer playerB = new Player("Bran", 180, Affinity.stars, fsFac);

            //playerA.DoCombat(playerB);

            //Goods someGoods = new Goods(new List<IVisitable>
            //{
            //    new Beer(),
            //    new Beer(),
            //    new Cheese(),
            //    new Shirt(),
            //    new Beer(),
            //    new Cheese()
            //});

            //IsHeavyVisitor ihV = new IsHeavyVisitor();
            //TaxVisitor tV = new TaxVisitor();

            //someGoods.ApplyVisitor(ihV);
            //someGoods.ApplyVisitor(tV);

            //Console.WriteLine($"The goods contain {ihV.TotalHeavyItems} heavy items");
            //Console.WriteLine($"The total tax is {tV.TotalTax} kr.");

            //List<ICompositable> items = new List<ICompositable>();
            //items.Add(new Beer());
            //items.Add(new Shirt());
            //items.Add(new Goods(new List<ICompositable>
            //{
            //    new Beer(), new Cheese(), new Beer()
            //}));
            //items.Add(new Beer());
            //items.Add(new Goods(new List<ICompositable>
            //{
            //    new Shirt(), new Cheese(), new Cheese()
            //}));

            //Goods someGoods = new Goods(items);

            //Console.WriteLine($"The total price of goods is {someGoods.Price} kr.");
            //Console.WriteLine($"The total weight of goods is {someGoods.Weight} kg.");

            //int noOfMembers = 5000;
            //List<IProfile> profiles = new List<IProfile>();
            //ProfileFactory profileFac = new ProfileFactory();

            //for (int i = 0; i < noOfMembers; i++)
            //{
            //    int imageId = i % 20;
            //    string userId = $"userNo#{i}";
            //    profiles.Add(new Profile(userId, imageId));
            //    // profiles.Add(profileFac.Create(userId, imageId));
            //}

            //Console.WriteLine();
            //Console.WriteLine("Done...");
            //Console.ReadKey();

            Client aClient = new Client();
            aClient.PlayWithLego();
        }
    }
}
