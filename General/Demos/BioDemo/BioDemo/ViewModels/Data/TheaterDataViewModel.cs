using BioDemo.Data.Domain;
using BioDemo.ViewModels.Base;

namespace BioDemo.ViewModels.Data
{
    /// <summary>
    /// Data view model class for Theater objects. Mainly provides
    /// properties for single-object Data Binding in the Theater view.
    /// </summary>
    public class TheaterDataViewModel : DataViewModelAppBase<Theater>
    {
        #region Constructor
        public TheaterDataViewModel(Theater obj) : base(obj)
        {
        }
        #endregion

        #region Properties
        public string Description
        {
            get { return DataObject.Description; }
            set
            {
                DataObject.Description = value;
                OnPropertyChanged();
            }
        }

        public int NoOfSeats
        {
            get { return DataObject.NoOfSeats; }
            set
            {
                DataObject.NoOfSeats = value;
                OnPropertyChanged();
            }
        }

        public bool Supports3D
        {
            get { return DataObject.Supports3D; }
            set
            {
                DataObject.Supports3D = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return Description; }
        }

        public override string ContentText
        {
            get { return $"{NoOfSeats} seats   3D: {(Supports3D ? "Yes" : "No")}"; }
        }
        #endregion
    }
}