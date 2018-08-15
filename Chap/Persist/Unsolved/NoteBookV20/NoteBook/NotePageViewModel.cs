using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Popups;

namespace NoteBook
{
    public class NotePageViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private NoteModel _model;
        private NoteDataViewModel _dataViewModelSelected;

        private RelayCommand _addCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _loadCommand;
        private RelayCommand _saveCommand;
        #endregion

        #region Constructor
        public NotePageViewModel()
        {
            _model = new NoteModel();
            _dataViewModelSelected = null;

            _addCommand = new RelayCommand(Add, CanAdd);
            _deleteCommand = new RelayCommand(Delete, CanDelete);
            _loadCommand = new RelayCommand(Load, CanLoad);
            _saveCommand = new RelayCommand(Save, CanSave);
        }
        #endregion

        #region Properties for Data Binding (ListView)
        public ObservableCollection<NoteDataViewModel> DataViewModelCollection
        {
            get { return CreateDataViewModelCollection(_model); }
        }

        public NoteDataViewModel DataViewModelSelected
        {
            get { return _dataViewModelSelected; }
            set
            {
                _dataViewModelSelected = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(EditEnabled));
                NotifyCommands();
            }
        }
        #endregion

        #region Properties for Data Binding (Commands)
        public ICommand AddCommand
        {
            get { return _addCommand; }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }

        public ICommand LoadCommand
        {
            get { return _loadCommand; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }
        #endregion

        #region Properties for Data Binding (TextBox)
        public bool EditEnabled
        {
            get { return _dataViewModelSelected != null; }
        }
        #endregion

        #region Command implementations
        private void Add()
        {
            AddNote(new Note());
            NotifyCommands();
        }

        private void Delete()
        {
            DeleteNote(_dataViewModelSelected.DomainObject.Title);
            NotifyCommands();
        }

        private bool CanAdd()
        {
            return !_model.ContainsTitle(Note.DefaultTitle);
        }

        private bool CanDelete()
        {
            return _dataViewModelSelected != null;
        }

        private bool CanLoad()
        {
            return true;
        }

        private bool CanSave()
        {
            return _model.All.Count > 0;
        }

        private void Load()
        {
            _model.LoadAsync();
            OnPropertyChanged(nameof(DataViewModelCollection));
        }

        private void Save()
        {
            _model.SaveAsync();
        }
        #endregion

        #region Helper methods
        public ObservableCollection<NoteDataViewModel> CreateDataViewModelCollection(NoteModel model)
        {
            ObservableCollection<NoteDataViewModel> items = new ObservableCollection<NoteDataViewModel>();

            foreach (Note aNote in model.All)
            {
                items.Add(new NoteDataViewModel(aNote, this, _model));
            }

            return items;
        }

        public void OnDataViewModelCollectionChanged()
        {
            OnPropertyChanged(nameof(DataViewModelCollection));
        }

        public void NotifyCommands()
        {
            _addCommand.RaiseCanExecuteChanged();
            _deleteCommand.RaiseCanExecuteChanged();
            _loadCommand.RaiseCanExecuteChanged();
            _saveCommand.RaiseCanExecuteChanged();
        }

        public bool ValidateTitle(string title)
        {
            if (_model.ContainsTitle(title))
            {
                ReportExistingTitle(title);
                return false;
            }

            return true;
        }

        public void UpdateTitle(string newTitle)
        {
            try
            {
                // Update title, and invoke re-read of item collectiom
                _model.UpdateTitle(DataViewModelSelected.DomainObject.Title, newTitle);
                OnPropertyChanged(nameof(DataViewModelCollection));

                // Set item selection to item with updated title
                SetItemViewModelSelectedByTitle(newTitle);

                NotifyCommands();
            }
            catch (TitleExistsException e)
            {
                NoteErrorPresenter.ReportExistingTitle(e.Message, () => { OnPropertyChanged(nameof(DataViewModelSelected)); });
            }
        }

        private void SetItemViewModelSelectedByTitle(string title)
        {
            foreach (NoteDataViewModel item in DataViewModelCollection)
            {
                if (item.DomainObject.Title == title)
                {
                    DataViewModelSelected = item;
                    return;
                }
            }
        }

        private void ReportExistingTitle(string name)
        {
            var messageDialog = new MessageDialog("Add Note");
            messageDialog.Content = "A note with the title " + name + " already exists!\n" + "Please use a different title.";
            messageDialog.Commands.Add(new UICommand("OK", command => { OnPropertyChanged(nameof(DataViewModelSelected)); }));
            messageDialog.ShowAsync();
        }

        private void AddNote(Note aNote)
        {
            _model.Add(aNote);
            OnPropertyChanged(nameof(DataViewModelCollection));
        }

        private void DeleteNote(string title)
        {
            _model.Delete(title);
            OnPropertyChanged(nameof(DataViewModelCollection));
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