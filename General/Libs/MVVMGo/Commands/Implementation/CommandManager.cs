using System;
using System.Collections.Generic;
using Commands.Interfaces;

namespace Commands.Implementation
{
    /// <summary>
    /// Implementation of ICommandManager interface
    /// </summary>
    public class CommandManager : ICommandManager
    {
        private Dictionary<string, INotifiableCommand> _commands;

        public CommandManager()
        {
            _commands = new Dictionary<string, INotifiableCommand>();
        }

        /// <summary>
        /// Retrieve the entire set of registered commands.
        /// </summary>
        public Dictionary<string, INotifiableCommand> Commands
        {
            get { return _commands; }
        }

        /// <summary>
        /// Add a command object to the set of registered commands.
        /// </summary>
        /// <param name="key">
        /// Command identifier (duplicates are not accepted)
        /// </param>
        /// <param name="command">
        /// Command object (Nulls are not accepted)
        /// </param>
        public void AddCommand(string key, INotifiableCommand command)
        {
            if (_commands.ContainsKey(key) || command == null)
            {
                throw new ArgumentException(nameof(AddCommand));
            }

            _commands.Add(key, command);
        }

        /// <summary>
        /// Ask all registered commands to re-evaluate the CanExecute predicate.
        /// </summary>
        public void Notify()
        {
            foreach (INotifiableCommand command in _commands.Values)
            {
                command.RaiseCanExecuteChanged();
            }
        }
    }
}