using System;

namespace SOLID.Liskov.Composition
{
    public class AnimalHuntedByExceptionImpl : IAnimalHuntedBy
    {
        public IAnimal IsHuntedBy
        {
            get { return null; }
            set { throw new NotImplementedException("Tigers are not hunted!"); }
        }
    }
}