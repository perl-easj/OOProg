using PvPSimulator.Model;

namespace PvPSimulator.Commands
{
    /// <summary>
    /// Command used for resetting the entire game.
    /// </summary>
    public class ResetCommand : CommandBase
    {
        #region Constructor
        public ResetCommand(BattleModel model) : base(model)
        {
        }
        #endregion

        #region Methods
        public override bool CanExecute()
        {
            return true;
        }

        public override void Execute()
        {
            Model.Reset();
        } 
        #endregion
    }
}