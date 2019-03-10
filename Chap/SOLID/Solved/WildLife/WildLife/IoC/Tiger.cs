using WildLife.Common;

namespace WildLife.IoC
{
    public abstract class Tiger : LargeAnimalBaseIoC
    {
        public Tiger(AnimalGender gender) : base(AnimalKind.tiger, gender)
        {
        }

        protected override bool Priority1Condition()
        {
            return Hungry && (TheWorld.NearBy(AnimalKind.fox) || TheWorld.NearBy(AnimalKind.mouse) || TheWorld.NearBy(AnimalKind.rabbit));
        }

        protected override bool Priority2Condition()
        {
            return Sleepy;
        }

        protected override void Priority2Behavior()
        {
            Sleep();
        }

        protected override bool Priority3Condition()
        {
            return TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.fox) == Gender;
        }

        protected override bool Priority4Condition()
        {
            return TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender;
        }

        protected override void Priority4Behavior()
        {
            Idle();
        }
    }
}