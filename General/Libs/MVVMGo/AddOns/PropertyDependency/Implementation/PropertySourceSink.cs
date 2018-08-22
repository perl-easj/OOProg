using System.Collections.Generic;
using System.ComponentModel;
using AddOns.PropertyDependency.Interfaces;

namespace AddOns.PropertyDependency.Implementation
{
    /// <summary>
    /// Some classes are both property sources 
    /// and property sinks. This class just extends 
    /// the PropertySink class with PropertySource 
    /// functionality. Classes which are both source 
    /// and sink can inherit from this class.
    /// </summary>
    public class PropertySourceSink : PropertySink, IPropertySource
    {
        #region Constructors
        public PropertySourceSink(List<IPropertySource> propertySources) : base(propertySources)
        {
        }

        public PropertySourceSink(IPropertySource propertySource) : base(propertySource)
        {
        }
        #endregion

        /// <inheritdoc />
        public void SetPropertyChangedHandler(PropertyChangedEventHandler handler)
        {
            PropertyChanged += handler;
        }
    }
}