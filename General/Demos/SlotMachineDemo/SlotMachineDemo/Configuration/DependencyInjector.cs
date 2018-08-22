using System.Collections.Generic;
using SlotMachineDemo.Implementations.Logic;
using SlotMachineDemo.Implementations.Models;
using SlotMachineDemo.Implementations.Settings;
using SlotMachineDemo.Implementations.ViewModels;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.Settings;

namespace SlotMachineDemo.Configuration
{
    /// <summary>
    /// This class chooses specific implementations of interfaces, and establishes
    /// dependencies between implementations. In SOLID terms, this class acts as
    /// the Composition Root.
    /// </summary>
    public class DependencyInjector
    {
        /// <summary>
        /// Chooses specific implementations of all interfaces,
        /// as well as specific values for numeric settings.
        /// </summary>
        public void SetDependencies()
        {
            #region Settings setup
            DefaultSettings defaultSettings = new DefaultSettings();
            ICompileTimeSettings compileTimeSettings = new CompileTimeSettings(defaultSettings);
            Setup.RunTimeSettings = new RunTimeSettings(defaultSettings);
            #endregion

            #region Logic setup
            LogicWinningsSetup logicWinningsSetup = new LogicWinningsSetup(compileTimeSettings);
            LogicProbabilitySetup logicProbabilitySetup = new LogicProbabilitySetup(compileTimeSettings);
            LogicSymbolGenerator logicSymbolGenerator = new LogicSymbolGenerator(logicProbabilitySetup);
            LogicCalculateWinnings logicCalculateWinnings = new LogicCalculateWinnings(logicWinningsSetup);
            LogicAnalyticalCalculation logicAnalyticalCalculation = new LogicAnalyticalCalculation(logicWinningsSetup, logicProbabilitySetup);
            #endregion

            #region Model setup
            ModelAutoPlay modelAutoPlay = new ModelAutoPlay(logicCalculateWinnings, logicSymbolGenerator,
                compileTimeSettings.NoOfRunsInAutoPlay,
                compileTimeSettings.AutoPlayUpdateThreshold);
            ModelNormalPlay modelNormalPlay = new ModelNormalPlay(logicCalculateWinnings, logicSymbolGenerator,
                compileTimeSettings.InitialCredits,
                compileTimeSettings.NoOfRotationsPerSpin,
                compileTimeSettings.RotationDelayMilliSecs);
            #endregion

            #region Property sources setup
            List<IPropertySource> winningsSetupPS = new List<IPropertySource> { logicWinningsSetup };
            List<IPropertySource> probabilitySetupPS = new List<IPropertySource> { logicProbabilitySetup };
            List<IPropertySource> autoPlayPS = new List<IPropertySource> { modelAutoPlay };
            List<IPropertySource> normalPlayPS = new List<IPropertySource> { modelNormalPlay };
            #endregion

            #region ViewModel setup
            ViewModelMachineSettings vmMachineSettings = new ViewModelMachineSettings();
            ViewModelWinningsSetup vmWinningsSetup = new ViewModelWinningsSetup(winningsSetupPS, logicWinningsSetup, 
                compileTimeSettings.TickScaleWinnings);
            ViewModelProbabilitySetup vmProbabilitySetup = new ViewModelProbabilitySetup(probabilitySetupPS, logicProbabilitySetup);
            ViewModelAnalyticalCalculation vmAnalyticalCalculation = new ViewModelAnalyticalCalculation(logicAnalyticalCalculation);
            ViewModelAutoPlay vmAutoPlay = new ViewModelAutoPlay(autoPlayPS, modelAutoPlay, logicAnalyticalCalculation,
                compileTimeSettings.TickScaleAutoPlay);
            ViewModelNormalPlay vmNormalPlay = new ViewModelNormalPlay(normalPlayPS, modelNormalPlay);
            #endregion

            #region ViewModel Proxy setup
            Setup.ViewModelMachineSettings = vmMachineSettings;
            Setup.ViewModelWinningsSetup = vmWinningsSetup;
            Setup.ViewModelProbabilitySetup = vmProbabilitySetup;
            Setup.ViewModelAnalyticalCalculation = vmAnalyticalCalculation;
            Setup.ViewModelAutoPlay = vmAutoPlay;
            Setup.ViewModelNormalPlay = vmNormalPlay;

            List<IPropertySource> vmProxyPropertySources = new List<IPropertySource>
            {
                vmMachineSettings,
                vmWinningsSetup,
                vmProbabilitySetup,
                vmAnalyticalCalculation,
                vmAutoPlay,
                vmNormalPlay
            };

            Setup.ViewModelFacadePropertySources = vmProxyPropertySources; 
            #endregion
        }
    }
}