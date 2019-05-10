using System;
using System.Collections.Generic;

#pragma warning disable 4014

namespace FunctionsAsParameters01
{
    class Program
    {
        static void Main()
        {
            #region Stock test
            //// [GIVEN] Create a Pulsar object
            //Pulsar thePulsar = new Pulsar();

            //// Create some Stock objects
            //Stock msft = new Stock("MSFT", 50, 150);
            //Stock gogl = new Stock("GOGL", 200, 600);
            //Stock tsla = new Stock("TSLA", 20, 100);

            //// Create some StockTrader objects
            //StockTrader traderA = new StockTrader("Alan", "MSFT", 110, true);
            //StockTrader traderB = new StockTrader("Alan", "GOGL", 450, false);
            //StockTrader traderC = new StockTrader("Bill", "MSFT", 75, false);
            //StockTrader traderD = new StockTrader("Bill", "TSLA", 45, true);

            //// Make sure StockTrader object are notified when
            //// the price of a stock changes
            //msft.PriceChanged += traderA.DoTrade;
            //msft.PriceChanged += traderC.DoTrade;
            //gogl.PriceChanged += traderB.DoTrade;
            //tsla.PriceChanged += traderD.DoTrade;

            //// Update stock prices on every Pulse event
            //thePulsar.Pulse += msft.GenerateNewPrice;
            //thePulsar.Pulse += gogl.GenerateNewPrice;
            //thePulsar.Pulse += tsla.GenerateNewPrice;

            //// Print out current stock prices on every Pulse event
            //thePulsar.Pulse += () =>
            //{
            //    Console.SetCursorPosition(0, 0);
            //    Console.WriteLine("----- Current stock prices -----");
            //    Console.WriteLine(msft);
            //    Console.WriteLine(gogl);
            //    Console.WriteLine(tsla);
            //    Console.WriteLine();
            //};

            //// Print out the entire Trade log on the LastPulse event
            //thePulsar.LastPulse += () =>
            //{
            //    Console.WriteLine("----- All stock trades -----");
            //    foreach (var entry in TradeLog.Log)
            //    {
            //        Console.WriteLine(entry);
            //    }
            //};

            //// [GIVEN] Start the Pulsar
            //thePulsar.Start(200, 100); 
            #endregion

            #region Animal test
            //Animal animal1 = new Animal(() => { return "Dog"; }, () => { return "Vuf"; });
            //Animal animal2 = new Animal(() => { return "Cat"; }, () => { return "Meow"; });
            //Animal animal3 = new Animal(() => { return "Cat"; }, () => { return "Meow"; });
            //Animal animal4 = new Animal(() => { return "Dog"; }, () => { return "Vuf"; });

            //List<Animal> animals = new List<Animal>();
            //animals.Add(animal1);
            //animals.Add(animal2);
            //animals.Add(animal3);
            //animals.Add(animal4);

            //foreach (var animal in animals.FindAll(a => a.AnimalType == "Dog"))
            //{
            //    Console.WriteLine(animal);
            //} 
            #endregion

            #region Music Pulsar test
            Pulsar thePulsar = new Pulsar();
            int beats = 0;

            System.Media.SoundPlayer bass = new System.Media.SoundPlayer(@"..\..\Sounds\BassDrum.wav");
            System.Media.SoundPlayer hiHat = new System.Media.SoundPlayer(@"..\..\Sounds\HiHat.wav");
            System.Media.SoundPlayer snare = new System.Media.SoundPlayer(@"..\..\Sounds\Snare.wav");

            bass.Load();
            hiHat.Load();
            snare.Load();

            thePulsar.Pulse += () =>
            {
                beats++;
                Console.WriteLine(beats);
            };

            thePulsar.Pulse += () =>
            {
                if (beats % 4 == 0)
                {
                    bass.Play();
                }
            };


            //thePulsar.Pulse += () =>
            //{
            //    if ((beats - 2) % 4 == 0 && beats > 64)
            //    {
            //        hiHat.Play();
            //    }
            //};

            //thePulsar.Pulse += () =>
            //{
            //    if ((beats - 0) % 8 == 0 && beats > 32)
            //    {
            //        snare.Play();
            //    }
            //};

            thePulsar.Start(110);
            #endregion

            Console.ReadKey();
        }
    }
}
