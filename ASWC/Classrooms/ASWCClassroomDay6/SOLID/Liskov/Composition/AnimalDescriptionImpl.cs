namespace SOLID.Liskov.Composition
{
    public class AnimalDescriptionImpl : IAnimalDescription
    {
        public AnimalDescriptionImpl(string desc)
        {
            Description = desc;
        }
        public string Description { get; private set; }
    }
}