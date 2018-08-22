using System.Collections.Generic;

namespace Commands.Interfaces
{
    /// <summary>
    /// The ICommandManager interface exposes methods for adding 
    /// command objects (identified by a key) to a manager of commands,
    /// to retrieve the set of registered commands, and to notify 
    /// all registered commands to re-evaluate the CanExecute predicate.
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Add a command object to the set of registered commands.
        /// </summary>
        /// <param name="key">
        /// Command identifier
        /// </param>
        /// <param name="command">
        /// Command object
        /// </param>
        void AddCommand(string key, INotifiableCommand command);

        /// <summary>
        /// Retrieve the entire set of registered commands.
        /// </summary>
        Dictionary<string, INotifiableCommand> Commands { get; }

        /// <summary>
        /// Ask all registered commands to re-evaluate the CanExecute predicate.
        /// </summary>
        void Notify();
    }
}