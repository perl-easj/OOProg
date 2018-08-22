using SlotMachineDemo.Interfaces.Controllers;

namespace SlotMachineDemo.Interfaces.Properties
{
    /// <summary>
    /// Interface to be implemented by classes which are "property sinks",
    /// i.e. contains properties which are dependent on properties from 
    /// other classes.
    /// </summary>
    public interface IPropertySink
    {
        /// <summary>
        /// Register a Command that may be affected by a change
        /// in the specified property
        /// </summary>
        void AddCommandDependency(string propertyName, ICommandExtended dependentCommand);

        /// <summary>
        /// Register a property that may be affected by a change
        /// in the specified property
        /// </summary>
        void AddPropertyDependency(string propertyName, string dependentPropertyName);
    }
}