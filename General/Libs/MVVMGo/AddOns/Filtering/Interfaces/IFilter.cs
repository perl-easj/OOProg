namespace AddOns.Filtering.Interfaces
{
    /// <summary>
    /// Interface for a Filter. A Filter is essentially 
    /// a method, taking an object of type T as input, 
    /// and returning a boolean.
    /// </summary>
    /// <typeparam name="T">
    /// Type of object to which the filter is applied.
    /// </typeparam>
    public interface IFilter<in T>
    {
        /// <summary>
        /// Identifier for the Filter
        /// </summary>
        string ID { get; }

        /// <summary>
        /// A "switch" by which the filter can be 
        /// turned on or off. If a filter is "off", 
        /// it will always return true.
        /// </summary>
        bool On { get; set; }

        /// <summary>
        /// Toggles the on/off state of the filter
        /// </summary>
        void Toggle();

        /// <summary>
        /// The method acting as the actual filter: 
        /// should return true if the given object 
        /// "passes" the filter, otherwise false.
        /// </summary>
        /// <param name="obj">
        /// Object to which the filter condition is applied.
        /// </param>
        bool Condition(T obj);
    }
}