using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfTemplate.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;

        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            if (methodToExecute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecuteEvaluator == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }
    }
}
