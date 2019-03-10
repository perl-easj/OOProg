using WildLife.Common;

namespace WildLife.Extended
{
    public class Mouse : AnimalBaseExtended
    {
        public Mouse(AnimalGender gender) : base(AnimalKind.mouse, gender)
        {
            AddBehavior(
                1, 
                () => TheWorld.NearBy(AnimalKind.fox) || TheWorld.NearBy(AnimalKind.rabbit),
                Flee);

            AddBehavior(
                2,
                () => TheWorld.NearBy(AnimalKind.mouse) && TheWorld.GenderOfNearBy(AnimalKind.mouse) != Gender,
                Mate);

            AddBehavior(
                3,
                () => Hungry,
                () =>
                {
                    Scavenge();
                    Eat();
                });

            AddBehavior(
                4,
                () => Sleepy,
                Sleep);
        }
    }
}