using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Models;

namespace SlotMachineDemo.Implementations.Controllers
{
    /// <summary>
    /// Invokes logic for starting (or cancelling) Auto-play
    /// </summary>
    public class AutoPlayControllerCommand : ICommandExtended
    {
        private IModelAutoPlay _modelAutoPlay;

        public AutoPlayControllerCommand(IModelAutoPlay modelAutoPlay)
        {
            _modelAutoPlay = modelAutoPlay;
        }

        public override bool CanExecute(object parameter)
        {
            return _modelAutoPlay != null;
        }

        /// <summary>
        /// The command effectively toggles the state of the auto-play; if an auto-play
        /// session is already running, the command will cancel the session.
        /// </summary>
        public override void Execute(object parameter)
        {
            if (_modelAutoPlay.CurrentAutoPlayState == Types.Enums.AutoPlayState.Running)
            {
                _modelAutoPlay.Cancel();
            }
            else
            {
                _modelAutoPlay.Run(_modelAutoPlay.NoOfRuns);
            }
        }
    }
}
