using Windows.UI;
using Windows.UI.Xaml.Media;
using SimpleRPGFromScratch.ViewModel.Base;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class RarityTierDataViewModel : DataViewModelAppBase<RarityTier>
    {
        private Color _color;

        #region Initialise
        public override void Initialise()
        {
            _color = Colors.White;
        }
        #endregion

        #region Simple properties
        public string Description
        {
            get { return DataObject().Description; }
            set
            {
                DataObject().Description = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsDataObjectValid));
            }
        }

        public Color RarityColor
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }

        protected override string ItemDescription
        {
            get { return Description; }
        }
        #endregion
    }
}