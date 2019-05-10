using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RPG30NOV
{
    public class CharacterPageViewModel : INotifyPropertyChanged
    {
        private CharacterCatalog _catalog;
        private CharacterDataViewModel _characterSelected;
        private string _searchText;
        private DeleteCommand _deleteCommand;

        public CharacterPageViewModel()
        {
            _catalog = new CharacterCatalog();
            _characterSelected = null;
            _deleteCommand = new DeleteCommand(_catalog, this);
            _searchText = "";
        }

        public List<CharacterDataViewModel> CharacterCollection
        {
            get { return _catalog
                .All
                .Where(ch => ch.Name.ToLower().Contains(_searchText.ToLower()))
                .Select(ch => new CharacterDataViewModel(ch))
                .ToList(); }
        }

        public CharacterDataViewModel CharacterSelected
        {
            get { return _characterSelected; }
            set
            {
                _characterSelected = value;
                OnPropertyChanged();
                _deleteCommand.OnCanExecuteChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CharacterCollection));
            }
        }

        public ICommand DeleteCommandObj
        {
            get { return _deleteCommand; }
        }

        public void Refresh()
        {
            CharacterSelected = null;
            OnPropertyChanged(nameof(CharacterCollection));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}