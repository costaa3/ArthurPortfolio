using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LearningAsyncIcommand
{
    internal class AsyncExecutionCommand : ICommand
    {
        private readonly Func<Task> _command;
        private readonly Func<bool> canExecuteCommand;

        public AsyncExecutionCommand(Func<Task> command)
        {
            _command = command;
        }

        public AsyncExecutionCommand(Func<Task> command, Func<bool> canExecuteCommand)
        {
            _command = command;
            this.canExecuteCommand = canExecuteCommand;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter = null)
        {
            return canExecuteCommand?.Invoke() ?? true;
        }

        public async void Execute(object parameter = null)
        {
            await ExecuteAsync();
        }

        private async Task ExecuteAsync()
        {

            if (CanExecute())
            {
                await _command();
            }
        }
    }
}
