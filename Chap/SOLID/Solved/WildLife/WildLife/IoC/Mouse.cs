using WildLife.Common;

namespace WildLife.IoC
{
    public class Mouse : SmallAnimalBaseIoC
    {
        public Mouse(AnimalGender gender) : base(AnimalKind.mouse, gender)
        {
        }

        protected override bool Priority1Condition()
        {
            return TheWorld.NearBy(AnimalKind.fox) || TheWorld.NearBy(AnimalKind.rabbit);
        }

        protected override void Priority1Behavior()
        {
            Flee();
        }

        protected override bool Priority2Condition()
        {
            return TheWorld.NearBy(AnimalKind.mouse) && TheWorld.GenderOfNearBy(AnimalKind.mouse) != Gender;
        }

        protected override void Priority2Behavior()
        {
            Mate();
        }
    }
}