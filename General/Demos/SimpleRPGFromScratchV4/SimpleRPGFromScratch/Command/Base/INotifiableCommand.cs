using System.Windows.Input;

namespace SimpleRPGFromScratch.Command.Base
{
    /// <summary>
    /// Dette interface tilføjer blot den typiske RaiseCanExecuteChanged
    /// metode til ICommand-interfacet.
    /// </summary>
    public interface INotifiableCommand : ICommand
    {
        /// <summary>
        /// Hvis noget ændres, som bør få et Command-objekt til at gen-evaluere
        /// CanExecute, kan denne metode kaldes på Command-objektet.
        /// </summary>
        void RaiseCanExecuteChanged();
    }
}