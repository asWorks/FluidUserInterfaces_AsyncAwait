using System;
using System.Windows.Input;

namespace FluidUserInterfaces_AsyncAwait.Commands
{
    internal class DelegateCommand : ICommand
    {

        private readonly Action<object> _execute;
        private readonly Func<object,bool> _canExecute;



        public DelegateCommand(Action<object> execute,Func<object,bool> canExecute)
        {
            _execute = execute;
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

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}