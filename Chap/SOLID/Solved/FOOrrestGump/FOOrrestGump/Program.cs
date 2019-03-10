using System;
using FOOrrestGump.FGScenario;
using FOOrrestGump.Implementation;
using FOOrrestGump.Interfaces;
// ReSharper disable UnusedParameter.Local

namespace FOOrrestGump
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSpecificScenario();
            RunGeneralizedScenarioWithChanged();
            RunGeneralizedScenarioWithAdapters();
            Wait();
        }

        private static void RunSpecificScenario()
        {
            ForrestGumpGenerator fgGenerator = new ForrestGumpGenerator();
            ChocolateBoxGenerator cbGenerator = new ChocolateBoxGenerator();

            ForrestGump gump = fgGenerator.GenerateForrestGump();
            ChocolateBox box = cbGenerator.GenerateChocolateBox();

            gump.SayFavoriteProverb();
            while (box.ChocolateLeft)
            {
                gump.Eat(box.TakeAChocolate());
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private static void RunGeneralizedScenarioWithChanged()
        {
            RunGeneralizedScenario(new ForrestGumpScenarioFactoryChanged());
        }

        private static void RunGeneralizedScenarioWithAdapters()
        {
            RunGeneralizedScenario(new ForrestGumpScenarioFactoryAdapters());
        }

        private static void RunGeneralizedScenario<T>(IScenarioFactory<T> factory) where T : IConsumable
        {
            IConsumer<T> aConsumer = factory.CreateConsumer();
            IConsumableContainer<T> aContainer = factory.CreateContainer();

            aConsumer.PreConsumeAction();
            while (!aContainer.Empty)
            {
                aConsumer.Consume(aContainer.TakeNext());
            }
            aConsumer.PostConsumeAction();
        }

        private static void Wait()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Done, press any key to close application");
            Console.ReadKey();
        }
    }
}
