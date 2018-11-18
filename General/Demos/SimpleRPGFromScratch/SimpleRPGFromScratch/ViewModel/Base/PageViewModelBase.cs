// HISTORIK:
// v.1.0 : Oprettet, implementerer relevante interfaces for
//         PageViewModel-klasser
//

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SimpleRPGFromScratch.Model.Base;

namespace SimpleRPGFromScratch.ViewModel.Base
{
    public abstract class PageViewModelBase<T, TDataViewModel> : IPageViewModel<TDataViewModel>, INotifyPropertyChanged 
        where TDataViewModel : class, new()
    {
        private ICatalog<T> _catalog;
        private TDataViewModel _itemSelected;

        protected PageViewModelBase()
        {
            _itemSelected = null;
            _catalog = GenerateCatalog();
        }

        public ObservableCollection<TDataViewModel> ItemCollection
        {
            get { return new ObservableCollection<TDataViewModel>(_catalog.All.Select(GenerateDataViewModel).ToList()); }
        }


        public TDataViewModel ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }

        // Denne metode skal implementeres i nedarvede,
        // domæne-specifikke klasser.
        protected abstract TDataViewModel GenerateDataViewModel(T obj);

        // Denne metode skal implementeres i nedarvede,
        // domæne-specifikke klasser. Skal ikke nødvendigvis
        // skabe et nyt Catalog-objekt, men blot tilvejebringe
        // en reference til et sådant objekt.
        protected abstract ICatalog<T> GenerateCatalog();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}