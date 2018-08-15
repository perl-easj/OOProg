using PvPSimulator.Model;

namespace PvPSimulator.Commands
{
    /// <summary>
    /// Command used for invoking a player attack.
    /// The command object is tied to a specific 
    /// player through a PlayerID
    /// </summary>
    public class AttackCommand : CommandBase
    {
        #region Instance fields
        private BattleModel.PlayerID _id;
        #endregion

        #region Constructor
        public AttackCommand(BattleModel model, BattleModel.PlayerID id) 
            : base(model)
        {
            _id = id;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Command can execute if the player is next for a turn,
        /// and the game has not finished yet.
        /// </summary>
        public override bool CanExecute()
        {
            return Model.PlayerTurn(_id) && !Model.GameOver;
        }

        public override void Execute()
        {
            Model.PlayerAct(_id);
        } 
        #endregion
    }
}