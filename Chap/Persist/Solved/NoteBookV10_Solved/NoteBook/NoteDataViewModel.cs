using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteBook
{
    public class NoteDataViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        public Note DomainObject;
        private NotePageViewModel _viewModel;
        private NoteModel _model;
        #endregion

        #region Constructor
        public NoteDataViewModel(Note obj, NotePageViewModel viewModel, NoteModel model)
        {
            DomainObject = obj;
            _viewModel = viewModel;
            _model = model;
        }
        #endregion

        #region Properties for Data Binding
        public string Title
        {
            get { return DomainObject.Title; }
            set
            {
                // Need to validate new title against existing titles
                if (_viewModel.ValidateTitle(value))
                {
                    // Get note with existing title
                    if (_viewModel.DataViewModelSelected != null)
                    {
                        Note aNote = _model.Read(_viewModel.DataViewModelSelected.DomainObject.Title);
                        if (aNote != null)
                        {
                            // Create a new Note with changed Title
                            string content = aNote.Content;
                            _model.Delete(aNote.Title);
                            _model.Add(new Note(value, content));

                            OnPropertyChanged();
                            _viewModel.OnDataViewModelCollectionChanged();

                            foreach (var item in _viewModel.DataViewModelCollection)
                            {
                                if (item.DomainObject.Title == value)
                                {
                                    _viewModel.DataViewModelSelected = item;
                                }
                            }

                            _viewModel.NotifyCommands();
                        }
                    }
                }

                OnPropertyChanged();
            }
        }

        public string Content
        {
            get { return DomainObject.Content; }
            set
            {
                DomainObject.Content = value;
                OnPropertyChanged();
            }
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