using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CMDL.Core
{
    public class Command : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public Command(Func<Task> task, Predicate<object> canExecute)
        {
            _execute = async (obj) => await task();
            _canExecute = canExecute;
        }

        public Command(Func<Task> task)
        {
            _execute = async (obj) => await task();
        }

        public Command(Action<object> execute)
           : this(execute, null)
        {
            _execute = execute;
        }

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        private event EventHandler CanExecuteChangedInternal;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChangedInternal.Raise(this);
        }
    }
}
