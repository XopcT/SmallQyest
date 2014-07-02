using System;
using System.Windows.Input;

namespace SmallQyest
{
    /// <summary>
    /// Basic Implementation of a Command.
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="command">Action to execute.</param>
        public Command(Action<object> command)
            : this(command, arg => { return true; })
        {
        }

        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="command">Action to execute.</param>
        /// <param name="canExecute">Function retrieving whether the Command can be executed.</param>
        public Command(Action<object> command, Func<object, bool> canExecute)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (canExecute == null)
                throw new ArgumentNullException("canExecute");
            this.command = command;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Retrieves whether the Command can be executed.
        /// </summary>
        /// <param name="parameter">Parameter to check Command with.</param>
        /// <returns>True if Command can be executed, False otherwise.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        /// <summary>
        /// Executes the Command.
        /// </summary>
        /// <param name="parameter">Parameter to execute Command with.</param>
        public void Execute(object parameter)
        {
            if (this.CanExecute(parameter))
                this.command(parameter);
        }

        #region Events

        /// <summary>
        /// Occus when Command State changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Properties

        #endregion

        #region Fields
        private readonly Action<object> command = null;
        private readonly Func<object, bool> canExecute = null;

        #endregion
    }
}
