using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using SlotMachineDemo.Configuration;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.ViewModels;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// This class acts as a facade for all view models, such that views can 
    /// use this class as their data context. In SOLID terms, this class acts
    /// as a Resolution Root.
    /// </summary>
    public class ViewModelFacade : PropertySink,
        IViewModelMachineSettings,
        IViewModelWinningsSetup,
        IViewModelProbabilitySetup,
        IViewModelAnalyticalCalculation,
        IViewModelAutoPlay,
        IViewModelNormalPlay        
    {
        #region Instance fields
        private IViewModelMachineSettings _viewModelMachineSettings;
        private IViewModelWinningsSetup _viewModelWinningsSetup;
        private IViewModelProbabilitySetup _viewModelProbabilitySetup;
        private IViewModelAnalyticalCalculation _viewModelAnalyticalCalculation;
        private IViewModelAutoPlay _viewModelAutoPlay;
        private IViewModelNormalPlay _viewModelNormalPlay; 
        #endregion

        #region Constructors
        public ViewModelFacade(
            IViewModelMachineSettings viewModelMachineSettings,
            IViewModelWinningsSetup viewModelWinningsSetup,
            IViewModelProbabilitySetup viewModelProbabilitySetup,
            IViewModelAnalyticalCalculation viewModelAnalyticalCalculation,
            IViewModelAutoPlay viewModelAutoPlay,
            IViewModelNormalPlay viewModelNormalPlay,
            List<IPropertySource> propertySources)
            : base(propertySources)
        {
            _viewModelMachineSettings = viewModelMachineSettings;
            _viewModelWinningsSetup = viewModelWinningsSetup;
            _viewModelProbabilitySetup = viewModelProbabilitySetup;
            _viewModelAnalyticalCalculation = viewModelAnalyticalCalculation;
            _viewModelAutoPlay = viewModelAutoPlay;
            _viewModelNormalPlay = viewModelNormalPlay;

            AddPropertyDependency(nameof(WinningsList), nameof(IViewModelWinningsSetup.WinningsList));
            AddPropertyDependency(nameof(WinningsAmount), nameof(IViewModelWinningsSetup.WinningsAmount));
            AddPropertyDependency(nameof(WinningsSelected), nameof(IViewModelWinningsSetup.WinningsSelected));
            AddPropertyDependency(nameof(WinningsTick), nameof(IViewModelWinningsSetup.WinningsTick));

            AddPropertyDependency(nameof(ProbBell), nameof(IViewModelProbabilitySetup.ProbBell));
            AddPropertyDependency(nameof(ProbCherry), nameof(IViewModelProbabilitySetup.ProbCherry));
            AddPropertyDependency(nameof(ProbClover), nameof(IViewModelProbabilitySetup.ProbClover));
            AddPropertyDependency(nameof(ProbMelon), nameof(IViewModelProbabilitySetup.ProbMelon));
            AddPropertyDependency(nameof(ProbSeven), nameof(IViewModelProbabilitySetup.ProbSeven));
            AddPropertyDependency(nameof(ProbShoe), nameof(IViewModelProbabilitySetup.ProbShoe));

            AddPropertyDependency(nameof(AutoPlayGoText), nameof(IViewModelAutoPlay.AutoPlayGoText));
            AddPropertyDependency(nameof(AutoPlayStatusText), nameof(IViewModelAutoPlay.AutoPlayStatusText));
            AddPropertyDependency(nameof(AutoPlayPercentCompleted), nameof(IViewModelAutoPlay.AutoPlayPercentCompleted));
            AddPropertyDependency(nameof(AutoPlayPercentCompleted), nameof(IViewModelAutoPlay.AutoRunDataText));
            AddPropertyDependency(nameof(AutoPlayProgressBarVisibility), nameof(IViewModelAutoPlay.AutoPlayProgressBarVisibility));
            AddPropertyDependency(nameof(NoOfRunsText), nameof(IViewModelAutoPlay.NoOfRunsText));
            AddPropertyDependency(nameof(NoOfRunsTick), nameof(IViewModelAutoPlay.NoOfRunsTick));
            AddPropertyDependency(nameof(NoOfRunsTick), nameof(IViewModelAutoPlay.AutoRunDataText));
            AddPropertyDependency(nameof(AutoRunDataText), nameof(IViewModelAutoPlay.AutoRunDataText));

            AddPropertyDependency(nameof(CreditsText), nameof(IViewModelNormalPlay.CreditsText));
            AddPropertyDependency(nameof(NoOfCreditsText), nameof(IViewModelNormalPlay.NoOfCreditsText));
            AddPropertyDependency(nameof(PlayButtonText), nameof(IViewModelNormalPlay.PlayButtonText));
            AddPropertyDependency(nameof(StatusText), nameof(IViewModelNormalPlay.StatusText));
            AddPropertyDependency(nameof(WheelSource), nameof(IViewModelNormalPlay.WheelSource));

            AddPropertyDependency(nameof(TheoreticalWinningsPercentageText), nameof(IViewModelAnalyticalCalculation.TheoreticalWinningsPercentageText));
        }

        /// <summary>
        /// Since ViewModelFacade acts as the Data Context for the View, we need a 
        /// parameterless default constructor for this class. View model implementations
        /// are retrieved from the Setup class.
        /// </summary>
        public ViewModelFacade()
            : this(Setup.ViewModelMachineSettings,
                   Setup.ViewModelWinningsSetup,
                   Setup.ViewModelProbabilitySetup,
                   Setup.ViewModelAnalyticalCalculation,
                   Setup.ViewModelAutoPlay,
                   Setup.ViewModelNormalPlay,
                   Setup.ViewModelFacadePropertySources)
        {
        }
        #endregion

        #region Machine Settings properties
        public bool UILanguage
        {
            get { return _viewModelMachineSettings.UILanguage; }
            set { _viewModelMachineSettings.UILanguage = value; }
        }

        public bool UIImageSet
        {
            get { return _viewModelMachineSettings.UIImageSet; }
            set
            {
                _viewModelMachineSettings.UIImageSet = value;
                OnPropertyChanged(nameof(WheelSymbolImages));
                OnPropertyChanged(nameof(WinningsList));
            }
        }

        public Dictionary<string, string> WheelSymbolImages
        {
            get { return Configuration.Setup.RunTimeSettings.WheelImage.GetAllImageSources(); }
        }
        #endregion

        #region Winnings properties
        public ObservableCollection<ItemViewModelWinningsEntry> WinningsList
        {
            get { return _viewModelWinningsSetup.WinningsList; }
        }

        public ObservableCollection<ItemViewModelWinningsEntry> WinningsListCopy
        {
            get { return _viewModelWinningsSetup.WinningsListCopy; }
        }

        public ItemViewModelWinningsEntry WinningsSelected
        {
            get { return _viewModelWinningsSetup.WinningsSelected; }
            set { _viewModelWinningsSetup.WinningsSelected = value; }
        }

        public int WinningsTick
        {
            get { return _viewModelWinningsSetup.WinningsTick; }
            set
            {
                _viewModelWinningsSetup.WinningsTick = value;
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int WinningsAmount
        {
            get { return _viewModelWinningsSetup.WinningsAmount; }
        }
        #endregion

        #region Probability properties
        public int ProbCherry
        {
            get { return _viewModelProbabilitySetup.ProbCherry; }
            set
            {
                _viewModelProbabilitySetup.ProbCherry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int ProbClover
        {
            get { return _viewModelProbabilitySetup.ProbClover; }
            set
            {
                _viewModelProbabilitySetup.ProbClover = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int ProbBell
        {
            get { return _viewModelProbabilitySetup.ProbBell; }
            set
            {
                _viewModelProbabilitySetup.ProbBell = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int ProbMelon
        {
            get { return _viewModelProbabilitySetup.ProbMelon; }
            set
            {
                _viewModelProbabilitySetup.ProbMelon = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int ProbSeven
        {
            get { return _viewModelProbabilitySetup.ProbSeven; }
            set
            {
                _viewModelProbabilitySetup.ProbSeven = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }

        public int ProbShoe
        {
            get { return _viewModelProbabilitySetup.ProbShoe; }
            set
            {
                _viewModelProbabilitySetup.ProbShoe = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TheoreticalWinningsPercentageText));
            }
        }
        #endregion

        #region Calculation properties
        public string TheoreticalWinningsPercentageText
        {
            get { return _viewModelAnalyticalCalculation.TheoreticalWinningsPercentageText; }
        }
        #endregion

        #region Auto Play properties
        public string AutoPlayGoText
        {
            get { return _viewModelAutoPlay.AutoPlayGoText; }
        }

        public string AutoPlayStatusText
        {
            get { return _viewModelAutoPlay.AutoPlayStatusText; }
        }

        public int AutoPlayPercentCompleted
        {
            get { return _viewModelAutoPlay.AutoPlayPercentCompleted; }
        }

        public Visibility AutoPlayProgressBarVisibility
        {
            get { return _viewModelAutoPlay.AutoPlayProgressBarVisibility; }
        }

        public string NoOfRunsText
        {
            get { return _viewModelAutoPlay.NoOfRunsText; }
        }

        public int NoOfRunsTick
        {
            get { return _viewModelAutoPlay.NoOfRunsTick; }
            set
            {
                _viewModelAutoPlay.NoOfRunsTick = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, string> AutoRunDataText
        {
            get { return _viewModelAutoPlay.AutoRunDataText; }
        }
        #endregion

        #region Normal Play properties
        public Dictionary<int, string> WheelSource
        {
            get { return _viewModelNormalPlay.WheelSource; }
        }

        public string PlayButtonText
        {
            get { return _viewModelNormalPlay.PlayButtonText; }
        }

        public string CreditsText
        {
            get { return _viewModelNormalPlay.CreditsText; }
        }

        public string NoOfCreditsText
        {
            get { return _viewModelNormalPlay.NoOfCreditsText; }
        }

        public string StatusText
        {
            get { return _viewModelNormalPlay.StatusText; }
        }
        #endregion

        #region Command properties
        public ICommandExtended SpinCommand
        {
            get { return _viewModelNormalPlay.SpinCommand; }
        }

        public ICommandExtended AddCreditCommand
        {
            get { return _viewModelNormalPlay.AddCreditCommand; }
        }

        public ICommandExtended AutoCommand
        {
            get { return _viewModelAutoPlay.AutoCommand; }
        }
        #endregion
    }
}
