using WildLife.Common;

namespace WildLife.Original
{
    public class Tiger : AnimalBaseOriginal
    {
        public Tiger(AnimalGender gender) : base(AnimalKind.tiger, gender)
        {
        }

        public override void Act()
        {
            // 1.priority: Eating
            if (Hungry && (TheWorld.NearBy(AnimalKind.fox) || TheWorld.NearBy(AnimalKind.mouse) || TheWorld.NearBy(AnimalKind.rabbit)))
            {
                Hunt();
                Eat();
            }

            // 2.priority: Sleeping
            else if (Sleepy)
            {
                Sleep();
            }

            // 3.priority: Fleeing (from same-gender Tigers)
            else if (TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.fox) == Gender)
            {
                Flee();
            }

            // 4.priority: Mating (with opposite-gender Tigers)
            // Thi is why Tigers are almost extinct...
            else if (TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender)
            {
                Mate();
            }

            else
            {
                Idle();
            }
        }
    }
}