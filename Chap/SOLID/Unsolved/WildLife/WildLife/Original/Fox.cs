using WildLife.Common;

namespace WildLife.Original
{
    public class Fox : AnimalBaseOriginal
    {
        public Fox(AnimalGender gender) : base(AnimalKind.fox, gender)
        {
        }

        /// <summary>
        /// Implementation of Fox-specific behavior. Note that this class is in
        /// control w.r.t. how the behavior is implemented. The implementation
        /// uses methods from the base class in a library-like manner.
        /// </summary>
        public override void Act()
        {
            // 1.priority: Eating
            if (Hungry && (TheWorld.NearBy(AnimalKind.rabbit) || TheWorld.NearBy(AnimalKind.mouse)))
            {
                Hunt();
                Eat();
            }

            // 2.priority: Mating (with Fox of opposite gender)
            else if (TheWorld.NearBy(AnimalKind.fox) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender)
            {
                Mate();
            }

            // 3.priority: Fleeing
            else if (TheWorld.NearBy(AnimalKind.tiger))
            {
                Flee();
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