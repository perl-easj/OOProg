using SlotMachineDemo.Interfaces.Controllers;
using SlotMachineDemo.Interfaces.Models;

namespace SlotMachineDemo.Implementations.Controllers
{
    /// <summary>
    /// Invokes logic for adding a single credit to a Slot Machine
    /// </summary>
    public class AddCreditsControllerCommand : ICommandExtended
    {
        private IModelNormalPlay _modelNormalPlay;

        public AddCreditsControllerCommand(IModelNormalPlay modelNormalPlay)
        {
            _modelNormalPlay = modelNormalPlay;
        }

        /// <summary>
        /// Credits can only be added when the machine is idle
        /// (or before the first play)
        /// </summary>
        public override bool CanExecute(object parameter)
        {
            return (_modelNormalPlay != null) && 
                   (_modelNormalPlay.CurrentNormalPlayState == Types.Enums.NormalPlayState.Idle ||
                    _modelNormalPlay.CurrentNormalPlayState == Types.Enums.NormalPlayState.BeforeFirstInteraction);
        }

        public override void Execute(object parameter)
        {
            _modelNormalPlay.NoOfCredits++;
        }
    }
}
