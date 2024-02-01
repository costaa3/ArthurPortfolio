using System;
using System.Windows.Input;

namespace LearningAsyncIcommand.ViewModel.Common
{
    internal class RelayCommand : ICommand

    {
        public event EventHandler CanExecuteChanged;
        private Action Action;
        private Func<bool> canExecuteAction;

        public RelayCommand(Action action)
        {
            Action = action;
        }

        public RelayCommand(Action action, Func<bool> canExecuteAction)
        {
            Action = action;
            this.canExecuteAction = canExecuteAction;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteAction?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }
}
