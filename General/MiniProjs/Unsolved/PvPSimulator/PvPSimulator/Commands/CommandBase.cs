using System;
using System.Windows.Input;
using PvPSimulator.Model;

namespace PvPSimulator.Commands
{
    /// <summary>
    /// Base class for all commands. Contains a reference
    /// to a BattleModel object.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        #region Instance fields
        protected BattleModel Model; 
        #endregion

        #region Constructor
        protected CommandBase(BattleModel model)
        {
            Model = model;
        } 
        #endregion

        #region Methods
        /// <summary>
        /// A derived command class should override
        /// this method.
        /// </summary>
        public abstract bool CanExecute();

        /// <summary>
        /// A derived command class should override
        /// this method.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Forward call to parameterless version.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// Forward call to parameterless version.
        /// </summary>
        public void Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Standard implementation of RaiseCanExecuteChanged.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        } 
        #endregion
    }
}