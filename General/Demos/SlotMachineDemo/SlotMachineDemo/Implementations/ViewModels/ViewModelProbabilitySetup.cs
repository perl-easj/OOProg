using System.Collections.Generic;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Logic;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.ViewModels;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// View model for the probability part of the 
    /// setup. The properties will just relay values
    /// to/from the probability setup logic.
    /// </summary>
    public class ViewModelProbabilitySetup : PropertySourceSink, IViewModelProbabilitySetup
    {
        private ILogicProbabilitySetup _logicProbabilitySetup;

        #region Constructor
        public ViewModelProbabilitySetup(List<IPropertySource> propertySources, ILogicProbabilitySetup logicProbabilitySetup)
            : base(propertySources)
        {
            _logicProbabilitySetup = logicProbabilitySetup;

            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbCherry));
            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbClover));
            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbBell));
            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbMelon));
            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbSeven));
            AddPropertyDependency(nameof(ILogicProbabilitySetup.ProbabilitySettings), nameof(IViewModelProbabilitySetup.ProbShoe));
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Probability for generating the Bell symbol.        
        /// </summary>
        public int ProbBell
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Bell); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Bell, value); }
        }

        /// <summary>
        /// Probability for generating the Cherry symbol.        
        /// </summary>
        public int ProbCherry
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Cherry); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Cherry, value); }
        }

        /// <summary>
        /// Probability for generating the Clover symbol.        
        /// </summary>
        public int ProbClover
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Clover); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Clover, value); }
        }

        /// <summary>
        /// Probability for generating the Melon symbol.        
        /// </summary>
        public int ProbMelon
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Melon); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Melon, value); }
        }

        /// <summary>
        /// Probability for generating the Seven symbol.       
        /// </summary>
        public int ProbSeven
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Seven); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Seven, value); }
        }

        /// <summary>
        /// Probability for generating the Shoe symbol.        
        /// </summary>
        public int ProbShoe
        {
            get { return _logicProbabilitySetup.GetProbability(Types.Enums.WheelSymbol.Shoe); }
            set { _logicProbabilitySetup.SetProbability(Types.Enums.WheelSymbol.Shoe, value); }
        }

        /// <summary>
        /// Retrieves the currently active set of wheel symbol images.
        /// </summary>
        public Dictionary<string, string> WheelSymbolImages
        {
            get { return Configuration.Setup.RunTimeSettings.WheelImage.GetAllImageSources(); }
        } 
        #endregion
    }
}
