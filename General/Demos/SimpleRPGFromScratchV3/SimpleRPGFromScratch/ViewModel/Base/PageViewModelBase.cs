// HISTORIK:
// v.1.0 : Oprettet, implementerer relevante interfaces for
//         PageViewModel-klasser
//

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// 4) Kunne være i en af tre tilstande: Read/Delete, Create eller Update
    /// De klasse-specifikke PVM-klasser - som arver fra denne klasse - vil blive
    /// Data Context for de klasse-specifikke views.
    /// </summary>
    /// <typeparam name="T">Typen for de domæne-objekter, der findes i det Catalog-objekt, der refereres til.</typeparam>
    /// <typeparam name="TDataViewModel">DVM-klasse svarende til klassen T.</typeparam>
    public abstract class PageViewModelBase<T, TDataViewModel> : IPageViewModel<TDataViewModel>, INotifyPropertyChanged 
        where TDataViewModel : class, IDataViewModel<T>, new() 
        where T : IDomainClass, new()
    {
        protected ICatalog<T> _catalog;
        protected PageViewModelState _state;
        protected event Action<PageViewModelState> _viewStateChanged;

        private TDataViewModel _itemSelected;
        private TDataViewModel _itemDetails;

        /// <summary>
        /// I constructoren sker to ting:
        /// 1) Vi sætter _catalog til at referere til et Catalog-objekt, ved hjælp
        ///    af den abstrake metode GenerateCatalog().
        /// 2) Vi beder om at blive notificeret, hvis der sker ændringer i det
        ///    underliggende Catalog-objekt.
        /// </summary>
        protected PageViewModelBase()
        {
            _catalog = GetCatalog();
            _catalog.CatalogChanged += OnCatalogHasChanged;
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
        /// 1) Sætte den nye værdi for _itemSelected, idet den afhænger af den
        ///    tilstand viewet p.t. er i.
        /// 2) Sætte den nye værdi for _itemDetails, idet den afhænger af den
        ///    tilstand viewet p.t. er i.
        /// 3) Fortælle alle som har en Data Binding til ItemSelected om ændringen,
        ///    ved at kalde OnPropertyChanged()
        /// 4) Fortælle alle som har en Data Binding til ItemDetails om ændringen,
        ///    ved at kalde OnPropertyChanged(nameof(ItemDetails))
        /// 5) Fortælle alle Commands, at de skal gen-evaluere om de må udføres,
        ///    ved at kalde den (abstrakte) metode NotifyCommands
        /// </summary>
        public TDataViewModel ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                // I Read/Delete-tilstand skal Details blot følges med Selected 
                if (_state == PageViewModelState.ReadDelete)
                {
                    _itemSelected = value;
                    _itemDetails = _itemSelected;
                }

                // I Create-tilstand skal Details sættes til et nyt "tomt" objekt.
                if (_state == PageViewModelState.Create)
                {
                    _itemSelected = null;
                    _itemDetails = CreateDataViewModel(new T());
                }

                // I Update-tilstand skal Details sættes til en kopi af det objekt,
                // Selected nu peger på.
                if (_state == PageViewModelState.Update)
                {
                    _itemSelected = value;
                    _itemDetails = _itemSelected != null ? CreateDataViewModel((T)_itemSelected.DataObject().Copy()) : null;
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(ItemDetails));

                NotifyCommands();
            }
        }

        /// <summary>
        /// Returnerer blot den aktuelle værdi af _itemDetails. Bemærk at værdien
        /// kun kan opdateres fra set-delen af ItemSelected.
        /// </summary>
        public TDataViewModel ItemDetails
        {
            get { return _itemDetails; }
        }

        /// <summary>
        /// Returnerer hvorvidt den kontrol, som rummer en collection af objekter,
        /// skal være enablet eller disablet.
        /// P.t. altid enablet, undtagen for Create-tilstand.
        /// </summary>
        public bool EnabledStateCollection
        {
            get { return _state != PageViewModelState.Create; }
        }

        /// <summary>
        /// Returnerer hvorvidt de kontroller, som viser detaljer om et enkelt objekt,
        /// skal være enablet eller disablet.
        /// P.t. altid enablet, undtagen for Read/Delete-tilstand.
        /// </summary>
        public bool EnabledStateDetails
        {
            get { return _state != PageViewModelState.ReadDelete; }
        }

        /// <summary>
        /// Tilstanden for et view kan ændres ved at kalde denne metode.
        /// Dette vil typisk ske fra et Command-objekt.
        /// </summary>
        /// <param name="newState">Viewets nye tilstand.</param>
        public void SetState(PageViewModelState newState)
        {
            _state = newState;
            ItemSelected = null;

            OnPropertyChanged(nameof(EnabledStateDetails));
            OnPropertyChanged(nameof(EnabledStateCollection));

            // Orientér andre interessenter om ændringen.
            OnViewStateChanged(newState);
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
        /// Denne metode skal overrides i nedarvede klasser, hvor man
        /// implementerer konkrete Commands for viewet.
        /// </summary>
        protected abstract void NotifyCommands();

        /// <summary>
        /// Denne metode bliver kaldt, når noget ændrer sig i det
        /// underliggende Catalog-objekt. Her genindlæses hele
        /// collection påny.
        /// </summary>
        private void OnCatalogHasChanged(int obj)
        {
            OnPropertyChanged(nameof(ItemCollection));
        }

        protected virtual void OnViewStateChanged(PageViewModelState obj)
        {
            _viewStateChanged?.Invoke(obj);
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