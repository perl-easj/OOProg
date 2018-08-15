using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteBook
{
    public class NoteDataViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        public Note DomainObject;
        private NotePageViewModel _viewModel;
        #endregion

        #region Constructor
        public NoteDataViewModel(Note obj, NotePageViewModel viewModel)
        {
            DomainObject = obj;
            _viewModel = viewModel;
        }
        #endregion

        #region Properties for Data Binding
        public string Title
        {
            get { return DomainObject.Title; }
            set
            {
                _viewModel.UpdateTitle(value);
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