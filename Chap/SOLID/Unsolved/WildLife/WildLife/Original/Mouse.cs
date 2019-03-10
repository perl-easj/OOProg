using WildLife.Common;

namespace WildLife.Original
{
    public class Mouse : AnimalBaseOriginal
    {
        public Mouse(AnimalGender gender) : base(AnimalKind.mouse, gender)
        {
        }

        public override void Act()
        {
            // 1.priority: Fleeing
            if (TheWorld.NearBy(AnimalKind.fox) || TheWorld.NearBy(AnimalKind.rabbit))
            {
                Flee();
            }

            // 2.priority: Mating
            else if (TheWorld.NearBy(AnimalKind.mouse) && TheWorld.GenderOfNearBy(AnimalKind.mouse) != Gender)
            {
                Mate();
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