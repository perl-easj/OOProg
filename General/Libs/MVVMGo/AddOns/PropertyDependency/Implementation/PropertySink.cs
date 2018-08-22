using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddOns.PropertyDependency.Interfaces;
using Commands.Interfaces;

namespace AddOns.PropertyDependency.Implementation
{
    /// <summary>
    /// Contains functionality for classes which 
    /// are "property sinks", i.e. contains 
    /// properties/commands which are dependent on 
    /// properties from other classes. These dependencies 
    /// can in general be many-to-many, so lists of 
    /// dependencies are maintained for each property.
    /// 
    /// A property sink object can:
    /// 1) Specifiy properties in other objects on 
    ///    which properties in the object depends.
    /// 2) Specifiy properties in other objects on 
    ///    which commands in the object depends.
    /// 3) Register its own handler for property 
    ///    changes in the property sources on which 
    ///    the object depends.
    /// </summary>
    public class PropertySink : IPropertySink, INotifyPropertyChanged
    {
        #region Instance fields
        private Dictionary<string, List<INotifiableCommand>> _commandDependencies;
        private Dictionary<string, List<string>> _propertyDependencies;
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor registers the object at all 
        /// of the specified property sources.
        /// </summary>
        public PropertySink(List<IPropertySource> propertySources)
        {
            _commandDependencies = new Dictionary<string, List<INotifiableCommand>>();
            _propertyDependencies = new Dictionary<string, List<string>>();

            RegisterSelfAtPropertySources(propertySources);
        }

        /// <inheritdoc />
        public PropertySink(IPropertySource propertySource)
            : this(new List<IPropertySource> { propertySource })
        {
        }
        #endregion

        #region Public methods
        /// <inheritdoc />
        public void AddPropertyDependency(string propertyName, string dependentPropertyName)
        {
            if (!_propertyDependencies.ContainsKey(propertyName))
            {
                _propertyDependencies.Add(propertyName, new List<string>());
            }

            _propertyDependencies[propertyName].Add(dependentPropertyName);
        }

        /// <inheritdoc />
        public void AddCommandDependency(string propertyName, INotifiableCommand dependentCommand)
        {
            if (!_commandDependencies.ContainsKey(propertyName))
            {
                _commandDependencies.Add(propertyName, new List<INotifiableCommand>());
            }

            _commandDependencies[propertyName].Add(dependentCommand);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Registers the object at all of the specified property 
        /// sources, such that the OnSourcePropertyChanged 
        /// method will be called whenever one of the properties 
        /// in the property sources are changed.
        /// </summary>
        private void RegisterSelfAtPropertySources(List<IPropertySource> propertySources)
        {
            foreach (IPropertySource propertySource in propertySources)
            {
                propertySource.SetPropertyChangedHandler(OnSourcePropertyChanged);
            }
        }

        /// <summary>
        /// Handler for changes to source properties. 
        /// Property source objects will call
        /// this method when their properties change.
        /// </summary>
        private void OnSourcePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (_propertyDependencies.ContainsKey(args.PropertyName))
            {
                // Call OnPropertyChanged on all dependent properties.
                foreach (string dependentProperty in _propertyDependencies[args.PropertyName])
                {
                    OnPropertyChanged(dependentProperty);
                }
            }
        }

        /// <summary>
        /// Handler for notifying command objects 
        /// that depend on other properties.
        /// </summary>
        private void NotifyCommands([CallerMemberName] string propertyName = null)
        {
            if (_commandDependencies.ContainsKey(propertyName))
            {
                // Call RaiseCanExecuteChanged on all dependent commands.
                foreach (INotifiableCommand command in _commandDependencies[propertyName])
                {
                    command.RaiseCanExecuteChanged();
                }
            }
        }
        #endregion

        #region OnPropertyChanged code (extended with call to NotifyCommands)
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            NotifyCommands(propertyName);
        }
        #endregion
    }
}