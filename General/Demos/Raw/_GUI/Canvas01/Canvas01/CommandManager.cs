using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Canvas01
{
    public class CommandManager : ICommand
    {
        private Dictionary<string, ICommand> _commands;

        public CommandManager()
        {
            _commands = new Dictionary<string, ICommand>();
        }

        public void AddCommand(string key, ICommand command)
        {
            _commands[key] = command;
        }

        public bool CanExecute(object parameter)
        {
            return _commands.ContainsKey(GetKey(parameter)) && _commands[GetKey(parameter)].CanExecute(null);
        }

        public void Execute(object parameter)
        {
            if (_commands.ContainsKey(GetKey(parameter)))
            {
                _commands[GetKey(parameter)].Execute(null);
            }
        }

        private string GetKey(object parameter)
        {
            return parameter.ToString();
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}