using BioDemo.Data.Domain;
using BioDemo.ViewModels.Base;

namespace BioDemo.ViewModels.Data
{
    /// <summary>
    /// Data view model class for Movie objects. Mainly provides
    /// properties for single-object Data Binding in the Movie view.
    /// </summary>
    public class MovieDataViewModel : DataViewModelAppBase<Movie>
    {
        #region Constructor
        public MovieDataViewModel(Movie obj) : base(obj)
        {
        } 
        #endregion

        #region Properties
        public string Title
        {
            get { return DataObject.Title; }
            set
            {
                DataObject.Title = value;
                OnPropertyChanged();
            }
        }

        public int LengthInMins
        {
            get { return DataObject.LengthInMins; }
            set
            {
                DataObject.LengthInMins = value;
                OnPropertyChanged();
            }
        }

        public int AgeLimit
        {
            get { return DataObject.AgeLimit; }
            set
            {
                DataObject.AgeLimit = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return Title; }
        }

        public override string ContentText
        {
            get { return $"{LengthInMins} mins.   Age {AgeLimit}+"; }
        }
        #endregion
    }
}