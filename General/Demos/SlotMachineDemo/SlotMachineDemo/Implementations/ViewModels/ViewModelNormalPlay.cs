using System.Collections.Generic;
using SlotMachineDemo.Configuration;
using SlotMachineDemo.Implementations.Properties;
using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Models;
using SlotMachineDemo.Interfaces.Properties;
using SlotMachineDemo.Interfaces.ViewModels;

namespace SlotMachineDemo.Implementations.ViewModels
{
    /// <summary>
    /// View model for interacting with the normal-play model
    /// </summary>
    public class ViewModelNormalPlay : PropertySourceSink, IViewModelNormalPlay
    {
        private IModelNormalPlay _modelNormalPlay;

        #region Constructor
        public ViewModelNormalPlay(List<IPropertySource> propertySources, IModelNormalPlay modelNormalPlay)
            : base(propertySources)
        {
            _modelNormalPlay = modelNormalPlay;

            AddPropertyDependency(nameof(IModelNormalPlay.NoOfCredits), nameof(IViewModelNormalPlay.NoOfCreditsText));
            AddPropertyDependency(nameof(IModelNormalPlay.WheelSymbols), nameof(IViewModelNormalPlay.WheelSource));
            AddPropertyDependency(nameof(IModelNormalPlay.CreditsWon), nameof(IViewModelNormalPlay.StatusText));
            AddPropertyDependency(nameof(IModelNormalPlay.CurrentNormalPlayState), nameof(IViewModelNormalPlay.StatusText));          
        }
        #endregion

        #region Public properties
        /// <summary>
        /// Text to display on the control 
        /// for starting a single game.
        /// </summary>
        public string PlayButtonText
        {
            get { return Setup.RunTimeSettings.Messages.GenerateText(
                Types.Enums.MessageType.Play, 
                Types.Enums.MessagePostProcessing.AllCaps); } 
        }

        /// <summary>
        /// Text for displaying the header for the 
        /// Credits section
        /// </summary>
        public string CreditsText
        {
            get { return Setup.RunTimeSettings.Messages.GenerateText(
                Types.Enums.MessageType.Credits, 
                Types.Enums.MessagePostProcessing.InitialCaps); }
        }

        /// <summary>
        /// Text for displaying the number of credits available
        /// </summary>
        public string NoOfCreditsText
        {
            get { return _modelNormalPlay.NoOfCredits.ToString(); }
        }

        /// <summary>
        /// Text for the current status of the game
        /// </summary>
        public string StatusText
        {
            get
            {
                if (_modelNormalPlay.CurrentNormalPlayState == Types.Enums.NormalPlayState.BeforeFirstInteraction)
                {
                    return Setup.RunTimeSettings.Messages.GenerateText(
                        Types.Enums.MessageType.Ready, 
                        Types.Enums.MessagePostProcessing.InitialCaps);
                }
                else if (_modelNormalPlay.CurrentNormalPlayState == Types.Enums.NormalPlayState.Spinning)
                {
                    List<Types.Enums.MessagePostProcessing> postProcessings = new List<Types.Enums.MessagePostProcessing>
                    {
                        Types.Enums.MessagePostProcessing.InitialCaps,
                        Types.Enums.MessagePostProcessing.AddEllipsis
                    };
                    return Setup.RunTimeSettings.Messages.GenerateText(Types.Enums.MessageType.SpinningWheels, postProcessings);
                }
                else if (_modelNormalPlay.CreditsWon > 0)
                {
                    string youwonText = Setup.RunTimeSettings.Messages.GenerateText(
                        Types.Enums.MessageType.YouWon, 
                        Types.Enums.MessagePostProcessing.InitialCaps);
                    string creditText = Setup.RunTimeSettings.Messages.GenerateText(
                        Types.Enums.MessageType.Credit, 
                        Types.Enums.MessagePostProcessing.AddExclamationMark);
                    string creditsText = Setup.RunTimeSettings.Messages.GenerateText(
                        Types.Enums.MessageType.Credits, 
                        Types.Enums.MessagePostProcessing.AddExclamationMark);

                    return string.Format("{0} {1} {2}", youwonText, _modelNormalPlay.CreditsWon, _modelNormalPlay.CreditsWon == 1 ? creditText : creditsText);
                }

                return "";
            }
        }

        /// <summary>
        /// Retrieves the image sources for the currently 
        /// active set of wheel symbol images.
        /// </summary>
        public Dictionary<int, string> WheelSource
        {
            get
            {
                Dictionary<int, string> imageSources = new Dictionary<int, string>();
                for (int index = 0; index < _modelNormalPlay.WheelSymbols.Count; index++)
                {
                    imageSources.Add(index, Configuration.Setup.RunTimeSettings.WheelImage.GetImageSource(_modelNormalPlay.WheelSymbols[index]));
                }

                return imageSources;
            }
        }

        /// <summary>
        /// Property for initiating a single game (a "spin")
        /// </summary>
        public ICommandExtended SpinCommand
        {
            get { return _modelNormalPlay.SpinCommand; }
        }

        /// <summary>
        /// Property for adding a single credit to
        /// the player's balance
        /// </summary>
        public ICommandExtended AddCreditCommand
        {
            get { return _modelNormalPlay.AddCreditCommand; }
        }
        #endregion
    }
}
