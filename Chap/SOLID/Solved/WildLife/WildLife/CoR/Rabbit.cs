using WildLife.Common;

namespace WildLife.CoR
{
    public class Rabbit : AnimalBaseCoR, IAnimalBehavior
    {
        public Rabbit(AnimalGender gender) : base(AnimalKind.rabbit, gender)
        {
            IAnimalBehavior idleBehavior = new AnimalBehavior(this,
                Idle,
                () => true,
                null);

            IAnimalBehavior prio4Behavior = new AnimalBehavior(this,
                Sleep,
                () => Sleepy,
                idleBehavior);

            IAnimalBehavior prio3Behavior = new AnimalBehavior(this,
                () =>
                {
                    Scavenge();
                    Eat();
                },
                () => Hungry,
                prio4Behavior);

            IAnimalBehavior prio2Behavior = new AnimalBehavior(this,
                Flee,
                () => TheWorld.NearBy(AnimalKind.tiger) || 
                      TheWorld.NearBy(AnimalKind.fox),
                prio3Behavior);

            IAnimalBehavior prio1Behavior = new AnimalBehavior(this,
                Mate,
                () => TheWorld.NearBy(AnimalKind.rabbit),
                prio2Behavior);

            Behavior = prio1Behavior;
        }
    }
}