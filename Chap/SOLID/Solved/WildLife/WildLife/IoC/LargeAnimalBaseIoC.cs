using WildLife.Common;

namespace WildLife.IoC
{
    public abstract class LargeAnimalBaseIoC : AnimalBaseIoC
    {
        protected LargeAnimalBaseIoC(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
        }

        protected override void Priority1Behavior()
        {
            Hunt();
            Eat();
        }

        protected override void Priority3Behavior()
        {
            Flee();
        }
    }
}