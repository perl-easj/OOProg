using System.ComponentModel;
using System.Runtime.CompilerServices;
using SimpleRPGFromScratch.Data.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Implementation af de generelle dele af en Data View Model (DVM) - klasse.
    /// Alle DVM-klasser skal:
    /// 1) Implementere IDataViewModel.
    /// 2) Implementere INotifyPropertyChanged.
    /// 3) Have en reference til et domæne-objekt af typen T.
    /// 4) Have en parameterløs constructor.
    /// </summary>
    /// <typeparam name="T">Typen for det domæne-objekt, der refereres til.</typeparam>
    public abstract class DataViewModelBase<T> : IDataViewModel<T>, INotifyPropertyChanged 
        where T : class, IDomainClass, new()
    {
        private T _obj { get; set; }

        protected DataViewModelBase()
        {
            _obj = null;
        }

        public T DataObject()
        {
            return _obj;
        }

        public void SetDataObject(T obj)
        {
            _obj = obj;
            Initialise();
        }

        public abstract void Initialise();

        public bool IsDataObjectValid
        {
            get { return DataObject().IsValid; }
        }

        #region Kode for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}