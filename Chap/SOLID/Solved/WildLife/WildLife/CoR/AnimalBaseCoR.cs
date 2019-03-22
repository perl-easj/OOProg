using WildLife.Common;

namespace WildLife.CoR
{
    public class AnimalBaseCoR : AnimalBase
    {
        protected IAnimalBehavior Behavior { get; set; }

        public AnimalBaseCoR(AnimalKind kind, AnimalGender gender, int ageLimit = 3) 
            : base(kind, gender, ageLimit)
        {
        }

        public override void Act()
        {
            Behavior.Act();
        }
    }
}