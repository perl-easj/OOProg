using WildLife.Common;

namespace WildLife.IoC
{
    /// <summary>
    /// Implementation of behavior for a specific animal (Fox).
    /// The behavior is made specific by implementing the four
    /// prioritised conditions and behaviors. The class can NOT
    /// change the general structure of the Act algorithm.
    /// </summary>
    public abstract class Fox : LargeAnimalBaseIoC
    {
        protected Fox(AnimalGender gender) : base(AnimalKind.fox, gender)
        {
        }

        protected override bool Priority1Condition()
        {
            return Hungry && (TheWorld.NearBy(AnimalKind.rabbit) || TheWorld.NearBy(AnimalKind.mouse));
        }

        protected override bool Priority2Condition()
        {
            return TheWorld.NearBy(AnimalKind.fox) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender;
        }

        protected override void Priority2Behavior()
        {
            Mate();
        }

        protected override bool Priority3Condition()
        {
            return TheWorld.NearBy(AnimalKind.tiger);
        }

        protected override bool Priority4Condition()
        {
            return Sleepy;
        }

        protected override void Priority4Behavior()
        {
            Sleep();
        }
    }
}