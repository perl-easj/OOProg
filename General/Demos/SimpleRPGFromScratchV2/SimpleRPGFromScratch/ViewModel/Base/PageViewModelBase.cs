// HISTORIK:
// v.1.0 : Oprettet, implementerer relevante interfaces for
//         PageViewModel-klasser
//

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SimpleRPGFromScratch.Command;
using SimpleRPGFromScratch.Data.Base;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    /// <summary>
    /// Implementation af de generelle dele af en Page View Model (PVM) - klasse.
    /// Alle PVM-klasser skal:
    /// 1) Implementere IPageViewModel.
    /// 2) Implementere INotifyPropertyChanged.
    /// 3) Have en reference til et Catalog-objekt, som rummer objekter af typen T.
    /// De klasse-specifikke PVM-klasser - som arver fra denne klasse - vil blive
    /// Data Context for de klasse-specifikke views.
    /// </summary>
    /// <typeparam name="T">Typen for de domæne-objekter, der findes i det Catalog-objekt, der refereres til.</typeparam>
    /// <typeparam name="TDataViewModel">DVM-klasse svarende til klassen T.</typeparam>
    public abstract class PageViewModelBase<T, TDataViewModel> : IPageViewModel<TDataViewModel>, INotifyPropertyChanged 
        where TDataViewModel : class, IDataViewModel<T>, new() 
        where T : IDomainClass
    {
        private ICatalog<T> _catalog;
        private TDataViewModel _itemSelected;
        private CommandBase _deleteCommandObj;

        /// <summary>
        /// I constructoren sker fire ting:
        /// 1) Vi sætter _itemSelected = null, d.v.s. vi antager, at der fra start
        ///    ikke er valgt noget i den kontrol, som viser vores collection frem.
        /// 2) Vi sætter _catalog til at referere til en Catalog-objekt, ved hjælp
        ///    af den abstrake metode GenerateCatalog().
        /// 3) Vi laver et nyt DeleteCommand objekt, som får en reference både til
        ///    Catalog-objektet samt PVM-objektet selv.
        /// 4) Vi beder om at blive notificeret, hvis der sker ændringer i det
        ///    underliggende Catalog-objekt.
        /// </summary>
        protected PageViewModelBase()
        {
            _itemSelected = null;
            _catalog = GetCatalog();
            _deleteCommandObj = new DeleteCommand<T, TDataViewModel>(_catalog, this);

            _catalog.CatalogChanged += OnCatalogChanged;
        }

        /// <summary>
        /// Denne property vil producere en ny collection af DVM-objekter, ved først
        /// at bede Catalog-objektet om at få en collection af alle domæne-objekter,
        /// og derefter "transformere" hvert domæne-objekt til det tilsvarende DVM-objekt,
        /// ved brug af metoden CreateDataViewModel.
        /// </summary>
        public ObservableCollection<TDataViewModel> ItemCollection
        {
            get { return new ObservableCollection<TDataViewModel>(_catalog.All.Select(CreateDataViewModel).ToList()); }
        }

        /// <summary>
        /// Denne property holder styr på, hvad der p.t. er valgt i den kontrol,
        /// som viser vores objekter. Hvis valget ændrer sig, skal vi
        /// 1) Fortælle alle som har en Data Binding til ItemSelected om det,
        ///    ved at kalde OnPropertyChanged()
        /// 2) Fortælle vores DeleteCommand-objekt om det, så den kan genoverveje,
        ///    om Execute må udføres. 
        /// </summary>
        public TDataViewModel ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
                _deleteCommandObj.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Denne property returnerer blot referencen til vores DeleteCommand-objekt.
        /// </summary>
        public ICommand DeleteCommandObj
        {
            get { return _deleteCommandObj; }
        }

        /// <summary>
        /// Denne metode Laver et nyt Data View Model (DVM) - objekt,
        /// ved brug af den parameterløse constructor + kald af SetDataObject.
        /// </summary>
        /// <param name="obj">Det domæne-objekt, som det nye DVM-objekt skal referere til</param>
        /// <returns></returns>
        private TDataViewModel CreateDataViewModel(T obj)
        {
            TDataViewModel dvmObj = new TDataViewModel();
            dvmObj.SetDataObject(obj);
            return dvmObj;
        }

        // Denne metode skal implementeres i nedarvede, domæne-specifikke klasser.
        // Skal ikke nødvendigvis skabe et nyt Catalog-objekt, men blot tilvejebringe
        // en reference til et sådant objekt.
        protected abstract ICatalog<T> GetCatalog();

        /// <summary>
        /// Denne metode bliver kaldt, når noget ændrer sig i det
        /// underliggende Catalog-objekt. Her genindlæses hele
        /// collection påny.
        /// </summary>
        private void OnCatalogChanged(int obj)
        {
            OnPropertyChanged(nameof(ItemCollection));
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