namespace SOLID.Liskov.Composition
{
    public class Animal : IAnimal
    {
        private IAnimalDescription _animalDescription { get; }
        private IAnimalHuntedBy _animalHuntedBy { get; }
        private IAnimalWeight _animalWeight { get; }

        public Animal(
            IAnimalDescription animalDescription, 
            IAnimalHuntedBy animalHuntedBy,
            IAnimalWeight animalWeight)
        {
            _animalDescription = animalDescription;
            _animalHuntedBy = animalHuntedBy;
            _animalWeight = animalWeight;
        }

        public Animal(
            IAnimalHuntedBy animalHuntedBy,
            IAnimalWeight animalWeight)
        {
            _animalDescription = new AnimalDescriptionImpl(GetType().Name);
            _animalHuntedBy = animalHuntedBy;
            _animalWeight = animalWeight;
        }

        public string Description
        {
            get { return _animalDescription.Description; }
        }

        public double WeightInKg
        {
            get { return _animalWeight.WeightInKg; }
            set { _animalWeight.WeightInKg = value; }
        }

        public IAnimal IsHuntedBy
        {
            get { return _animalHuntedBy.IsHuntedBy; }
            set { _animalHuntedBy.IsHuntedBy = value; }
        }

        public override string ToString()
        {
            string huntedDesc = IsHuntedBy == null ?
                "not hunted." :
                $"hunted by a {IsHuntedBy.Description}";

            return $"{Description}, weighing {WeightInKg} kg., is {huntedDesc}";
        }
    }
}