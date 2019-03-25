namespace AnimalBehavior.Interfaces
{
    public interface IAnimalBehavior
    {
        /// <summary>
        /// Calling this method should result in some kind of
        /// "response" from the animal, e.g. printing a message
        /// on the screen.
        /// The method may also throw an exception.
        /// </summary>
        void Act();
    }
}