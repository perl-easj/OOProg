using System;

namespace SimpleRPGFromScratch.Command.Base
{
    /// <summary>
    /// Basis-implementation af simple Command-klasser. Fjerner brugen af
    /// parametre til Execute og CanExecute.
    /// </summary>
    public abstract class CommandBase : INotifiableCommand
    {
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Som udgangspunkt kan Command-objektet altid udføre Execute.
        /// Dette kan om nødvendigt ændres i de nedarvede klasser.
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanExecute()
        {
            return true;
        }

        /// <summary>
        /// Execute er abstract, da det kun giver mening at implementere
        /// Execute i en nedarvet klasse.
        /// </summary>
        protected abstract void Execute();

        #region Kode for CanExecuteChanged
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        } 
        #endregion
    }
}