using SimpleRPGFromScratch.ViewModel.Base;
using SimpleRPGFromScratch.ViewModel.Control;

namespace SimpleRPGFromScratch.ViewModel.Data
{
    public class CharacterDataViewModel : DataViewModelAppBase<Character>
    {
        private const int HPScaleFactor = 10;

        private IntSliderDataViewModel _levelSliderDVM;
        private IntSliderDataViewModel _hpSliderDVM;

        public CharacterDataViewModel() : this(null)
        {
        }

        public CharacterDataViewModel(Character dataObject) : base(dataObject)
        {
            _hpSliderDVM = new IntSliderDataViewModel(
                Character.MaxHealthPoints, 
                HPScaleFactor, 
                () => DataObject().HealthPoints,
                val =>
                {
                    DataObject().HealthPoints = val;
                    OnPropertyChanged(nameof(HealthPointsIndex));
                    OnPropertyChanged(nameof(HealthPoints));
                });

            _levelSliderDVM = new IntSliderDataViewModel(
                Character.MaxLevel, 
                () => DataObject().Level,
                val =>
                {
                    DataObject().Level = val;
                    OnPropertyChanged(nameof(LevelIndex));
                    OnPropertyChanged(nameof(Level));
                });
        }

        public string Name
        {
            get { return DataObject().Name; }
            set
            {
                DataObject().Name = value;
                OnPropertyChanged();
            }
        }

        public int HealthPointsIndex
        {
            get { return _hpSliderDVM.SliderIndex; }
            set { _hpSliderDVM.SliderIndex = value; }
        }

        public string HealthPoints
        {
            get { return _hpSliderDVM.SliderText; }
        }

        public int HealthPointsScaleMax
        {
            get { return _hpSliderDVM.SliderScaleMax; }
        }

        public int LevelIndex
        {
            get { return _levelSliderDVM.SliderIndex; }
            set { _levelSliderDVM.SliderIndex = value; }
        }

        public string Level
        {
            get { return _levelSliderDVM.SliderText; }
        }

        public int LevelScaleMax
        {
            get { return _levelSliderDVM.SliderScaleMax; }
        }

        protected override string ItemDescription
        {
            get { return $"{Name}"; }
        }
    }
}