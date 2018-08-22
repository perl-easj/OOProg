using Commands.Interfaces;

namespace AddOns.PropertyDependency.Interfaces
{
    /// <summary>
    /// Interface to be implemented by classes 
    /// which are "property sinks", i.e. contains 
    /// properties which are dependent on properties 
    /// from other classes.
    /// </summary>
    public interface IPropertySink
    {
        /// <summary>
        /// Register a command that may be affected by 
        /// a change in the given property.
        /// </summary>
        /// <param name="propertyName">
        /// Name of property.
        /// </param>
        /// <param name="dependentCommand">
        /// Reference to dependent command object.
        /// </param>
        void AddCommandDependency(string propertyName, INotifiableCommand dependentCommand);

        /// <summary>
        /// Register a property that may be affected by 
        /// a change in the given property
        /// </summary>
        /// <param name="propertyName">
        /// Name of property.
        /// </param>
        /// <param name="dependentPropertyName">
        /// Name of dependent property.
        /// </param>
        void AddPropertyDependency(string propertyName, string dependentPropertyName);
    }
}