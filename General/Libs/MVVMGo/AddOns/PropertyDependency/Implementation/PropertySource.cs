using System.ComponentModel;
using System.Runtime.CompilerServices;
using AddOns.PropertyDependency.Interfaces;

namespace AddOns.PropertyDependency.Implementation
{
    /// <summary>
    /// Contains functionality for classes which are
    /// "property sources", i.e. contains properties 
    /// on which properties/commands in other classes depend. 
    /// </summary>
    public class PropertySource : IPropertySource, INotifyPropertyChanged
    {
        #region Constructor
        public PropertySource()
        {
            PropertyChanged = null;
        }
        #endregion

        #region Methods
        /// <inheritdoc />
        public void SetPropertyChangedHandler(PropertyChangedEventHandler handler)
        {
            PropertyChanged += handler;
        }
        #endregion

        #region OnPropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}