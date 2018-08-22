using System.Collections.Generic;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.Settings;
using SlotMachineDemo.Interfaces.ViewModels;

namespace SlotMachineDemo.Configuration
{
    /// <summary>
    /// This class provides as access point for settings determined
    /// at run-time. It also kicks off the initial dependency injection.
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Ensures that dependency injection has been completed
        /// before accessing any of the properties.
        /// </summary>
        static Setup()
        {
            _dependencyInjector = new DependencyInjector();
            _dependencyInjector.SetDependencies();
        }

        #region Static instance fields
        private static DependencyInjector _dependencyInjector;
        private static IRunTimeSettings _runTimeSettings;

        private static IViewModelMachineSettings _viewModelMachineSettings;
        private static IViewModelWinningsSetup _viewModelWinningsSetup;
        private static IViewModelProbabilitySetup _viewModelProbabilitySetup;
        private static IViewModelAnalyticalCalculation _viewModelAnalyticalCalculation;
        private static IViewModelAutoPlay _viewModelAutoPlay;
        private static IViewModelNormalPlay _viewModelNormalPlay;
        private static List<IPropertySource> _viewModelFacadePropertySources;
        #endregion

        #region Settings properties
        public static IRunTimeSettings RunTimeSettings
        {
            get { return _runTimeSettings; }
            set { _runTimeSettings = value; }
        }
        #endregion

        #region View model properties
        public static IViewModelMachineSettings ViewModelMachineSettings
        {
            get { return _viewModelMachineSettings; }
            set { _viewModelMachineSettings = value; }
        }

        public static IViewModelWinningsSetup ViewModelWinningsSetup
        {
            get { return _viewModelWinningsSetup; }
            set { _viewModelWinningsSetup = value; }
        }

        public static IViewModelProbabilitySetup ViewModelProbabilitySetup
        {
            get { return _viewModelProbabilitySetup; }
            set { _viewModelProbabilitySetup = value; }
        }

        public static IViewModelAnalyticalCalculation ViewModelAnalyticalCalculation
        {
            get { return _viewModelAnalyticalCalculation; }
            set { _viewModelAnalyticalCalculation = value; }
        }

        public static IViewModelAutoPlay ViewModelAutoPlay
        {
            get { return _viewModelAutoPlay; }
            set { _viewModelAutoPlay = value; }
        }

        public static IViewModelNormalPlay ViewModelNormalPlay
        {
            get { return _viewModelNormalPlay; }
            set { _viewModelNormalPlay = value; }
        }

        public static List<IPropertySource> ViewModelFacadePropertySources
        {
            get { return _viewModelFacadePropertySources; }
            set { _viewModelFacadePropertySources = value; }
        }
        #endregion
    }
}