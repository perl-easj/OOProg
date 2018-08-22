using System.ComponentModel;

namespace AddOns.PropertyDependency.Interfaces
{
    /// <summary>
    /// Interface to be implemented by classes 
    /// which are "property sources", i.e. contains 
    /// properties on which properties from other 
    /// classes depend.
    /// </summary>
    public interface IPropertySource
    {
        /// <summary>
        /// An object interested in being notified about 
        /// property changes occurring in this object, 
        /// may register a handler method by calling 
        /// this method.
        /// </summary>
        /// <param name="handler">
        /// Property change event handler.
        /// </param>
        void SetPropertyChangedHandler(PropertyChangedEventHandler handler);
    }
}