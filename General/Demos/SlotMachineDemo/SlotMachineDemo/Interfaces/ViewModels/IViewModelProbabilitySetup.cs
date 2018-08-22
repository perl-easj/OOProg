using System.Collections.Generic;

namespace SlotMachineDemo.Interfaces.ViewModels
{
    /// TODO: It would seem more appropriate to use a Dictionary here, 
    /// TODO: but this is difficult to realise when we need two-way bindings...

    /// <summary>
    /// Interface for the view model for the probability part
    /// of the setup. The properties will just relay values
    /// to/from the probability setup logic.
    /// </summary>
    public interface IViewModelProbabilitySetup
    {
        /// <summary>
        /// Probability for generating the Bell symbol.        
        /// </summary>
        int ProbBell { get; set; }

        /// <summary>
        /// Probability for generating the Cherry symbol.       
        /// </summary>
        int ProbCherry { get; set; }

        /// <summary>
        /// Probability for generating the Clover symbol.        
        /// </summary>
        int ProbClover { get; set; }

        /// <summary>
        /// Probability for generating the Melon symbol.        
        /// </summary>
        int ProbMelon { get; set; }

        /// <summary>
        /// Probability for generating the Seven symbol.        
        /// </summary>
        int ProbSeven { get; set; }

        /// <summary>
        /// Probability for generating the Shoe symbol.    
        /// </summary>
        int ProbShoe { get; set; }

        /// <summary>
        /// Retrieves the currently active set of wheel symbol images.
        /// </summary>
        Dictionary <string, string> WheelSymbolImages { get;}
    }
}