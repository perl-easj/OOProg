using System;
using System.Collections.Generic;
using WildLife.Common;
using WildLife.Original;

namespace WildLife
{
    public class Tester
    {
        public void Run()
        {
            Fox aFox = new Fox(AnimalGender.female);
            Mouse aMouse = new Mouse(AnimalGender.male);
            Rabbit aRabbit = new Rabbit(AnimalGender.male);
            Tiger aTiger = new Tiger(AnimalGender.female);

            List<AnimalBase> animals = new List<AnimalBase> { aFox, aMouse, aRabbit, aTiger };
            foreach (AnimalBase anAnimal in animals)
            {
                anAnimal.Live(PreAct, PostAct);
                Console.WriteLine();
            }
        }

        private void PreAct(AnimalBase anAnimal)
        {
            Console.WriteLine();
            Console.WriteLine(World.Instance);
            Console.WriteLine(anAnimal);
        }

        private void PostAct(AnimalBase anAnimal)
        {
            World.Instance.UpdateState();
        }
    }
}