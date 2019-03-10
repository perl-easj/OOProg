using WildLife.Common;

namespace WildLife.Original
{
    public class Rabbit : AnimalBaseOriginal
    {
        public Rabbit(AnimalGender gender) : base(AnimalKind.rabbit, gender)
        {
        }

        public override void Act()
        {
            // 1.priority: Mating
            // Rabbits, right...?
            if (TheWorld.NearBy(AnimalKind.rabbit))
            {
                Mate();
            }

            // 2.priority: Fleeing
            else if (TheWorld.NearBy(AnimalKind.tiger) || TheWorld.NearBy(AnimalKind.fox))
            {
                Flee();
            }

            // 3.priority: Eating
            else if (Hungry)
            {
                Scavenge();
                Eat();
            }

            // 4.priority: Sleeping
            else if (Sleepy)
            {
                Sleep();
            }

            else
            {
                Idle();
            }
        }
    }
}