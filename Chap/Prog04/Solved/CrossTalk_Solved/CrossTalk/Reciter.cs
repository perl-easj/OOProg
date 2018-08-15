using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CrossTalk
{
    public class Reciter
    {
        private static Random _rng = new Random();

        /// <summary>
        /// Recites a set of lists of words
        /// </summary>
        public static void ReciteAllTheWords()
        {
            List<string> danish = new List<string> {"En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte" };
            List<string> english = new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight" };
            List<string> german = new List<string> { "Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht" };

            // Wrap each call of Recite into a separate Task object.
            Task t1 = new Task(() => { Recite(danish); });
            Task t2 = new Task(() => { Recite(english); });
            Task t3 = new Task(() => { Recite(german); });

            // Start the tasks. The tasks will now execute in parallel.
            t1.Start();
            t2.Start();
            t3.Start();
        }

        /// <summary>
        /// Recites (i.e. prints on screen with a bit of delay
        /// between each line) the provided list of strings.
        /// </summary>
        public static void Recite(List<string> words)
        {
            foreach (string s in words)
            {
                Console.WriteLine(s);
                Thread.Sleep(_rng.Next(1000) + 50);
            }
        }
    }
}