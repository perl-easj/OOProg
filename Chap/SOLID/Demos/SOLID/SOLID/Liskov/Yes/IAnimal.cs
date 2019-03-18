namespace SOLID.Liskov.Yes
{
    public interface IAnimal
    {
        /// <summary>
        /// Contract: will return a string. 
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Contract: will throw an exception if called before
        /// weight has been set.
        /// </summary>
        double WeightInKg { get; }
    }
}