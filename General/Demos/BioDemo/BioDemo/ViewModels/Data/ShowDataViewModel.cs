using System;
using System.Collections.ObjectModel;
using System.Linq;
using BioDemo.Data.Domain;
using BioDemo.ViewModels.Base;
using BioDemo.ViewModels.Page;
using Data.InMemory.Interfaces;

namespace BioDemo.ViewModels.Data
{
    /// <summary>
    /// Data view model class for Show objects. Mainly provides
    /// properties for single-object Data Binding in the Show view.
    /// This class is a bit more complex, due to the use of combo-boxes
    /// in the Show view, to display lists of movies and theaters.
    /// These lists are retrieved from Page View Model objects for
    /// Movie and Theater, respectively.
    /// </summary>
    public class ShowDataViewModel : DataViewModelAppBase<Show>
    {
        #region Instance fields
        private MoviePageViewModel _moviePVM;
        private TheaterPageViewModel _theaterPVM;
        #endregion

        #region Constructor
        public ShowDataViewModel(Show obj) : base(obj)
        {
            _moviePVM = new MoviePageViewModel();
            _theaterPVM = new TheaterPageViewModel();
            SelectedMovie = _moviePVM.ItemCollection.FirstOrDefault(e => e.DataObject.Key == obj.MovieKey);
            SelectedTheater = _theaterPVM.ItemCollection.FirstOrDefault(e => e.DataObject.Key == obj.TheaterKey);
        }
        #endregion

        #region Properties
        public ObservableCollection<IDataWrapper<Movie>> Movies
        {
            get { return _moviePVM.ItemCollection; }
        }

        public ObservableCollection<IDataWrapper<Theater>> Theaters
        {
            get { return _theaterPVM.ItemCollection; }
        }

        public IDataWrapper<Movie> SelectedMovie
        {
            get { return _moviePVM.ItemSelected; }
            set
            {
                _moviePVM.ItemSelected = value;

                if (_moviePVM.ItemSelected != null)
                {
                    DataObject.MovieKey = _moviePVM.ItemSelected.DataObject.Key;
                    OnPropertyChanged();
                }
            }
        }

        public IDataWrapper<Theater> SelectedTheater
        {
            get { return _theaterPVM.ItemSelected; }
            set
            {
                _theaterPVM.ItemSelected = value;

                if (_theaterPVM.ItemSelected != null)
                {
                    DataObject.TheaterKey = _theaterPVM.ItemSelected.DataObject.Key;
                    OnPropertyChanged();
                }
            }
        }

        public DateTimeOffset DateForShow
        {
            get { return DataObject.DateForShow; }
            set
            {
                DataObject.DateForShow = value.Date;
                OnPropertyChanged();
            }
        }

        public TimeSpan TimeForShow
        {
            get { return DataObject.TimeForShow; }
            set
            {
                DataObject.TimeForShow = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return $"{DataObject.MovieForShow?.Title} in {DataObject.TheaterForShow?.Description}"; }
        }

        public override string ContentText
        {
            get { return $"{DateForShow.Date.ToLongDateString()} @ {TimeForShow.Hours:00}:{TimeForShow.Minutes:00}"; }
        }
        #endregion
    }
}