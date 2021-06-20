using System;
using System.Windows.Input;

namespace SuricataLogViewer.ViewModels
{
    public class RelayCommand<T> : ICommand where T : class
    {
        private Action<T> execute;
        private Predicate<T> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            execute?.Invoke((T)parameter);
        }
    }
}
