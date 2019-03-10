using WildLife.Common;

namespace WildLife.IoC
{
    public abstract class SmallAnimalBaseIoC : AnimalBaseIoC
    {
        protected SmallAnimalBaseIoC(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
        }

        protected override bool Priority3Condition()
        {
            return Hungry;
        }

        protected override void Priority3Behavior()
        {
            Scavenge();
            Eat();
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