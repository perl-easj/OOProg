using WildLife.Common;

namespace WildLife.IoC
{
    public class Rabbit : SmallAnimalBaseIoC
    {
        public Rabbit(AnimalGender gender) : base(AnimalKind.rabbit, gender)
        {
        }

        protected override bool Priority1Condition()
        {
            return TheWorld.NearBy(AnimalKind.rabbit);
        }

        protected override void Priority1Behavior()
        {
            Mate();
        }

        protected override bool Priority2Condition()
        {
            return TheWorld.NearBy(AnimalKind.tiger) || TheWorld.NearBy(AnimalKind.fox);
        }

        protected override void Priority2Behavior()
        {
            Flee();
        }
    }
}