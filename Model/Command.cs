using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FontIconViewer.Model
{
        /// <summary>
        /// Defines a synchronous action to invoke by <see cref="Command"/>
        /// </summary>
        /// <param name="item"></param>
        public delegate void SyncAction(Command item);

    /// <summary>
    /// Provides an <see cref="ICommand"/> implementation for synchronous and asynchronous commands.
    /// </summary>
    public class Command : ObservableObject, ICommand
    {
        readonly SyncAction _action;
        bool _enabled;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="action">The <see cref="SyncAction"/> to invoke to execute the action.</param>
        /// <param name="enabled">true the command can be executed; otherwise, false</param>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is a null reference.</exception>
        public Command(SyncAction action, bool enabled)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _enabled = enabled;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the value indicating if the item is enabled.
        /// </summary>
        /// <value>
        /// true if the item is enabled; otherwise, false.
        /// </value>
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (value != _enabled)
                {
                    _enabled = value;
                    OnPropertyChanged(EnabledChangedEventArgs);
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the parameter that was passed to <see cref="Execute(object)"/>
        /// </summary>
        /// <value>
        /// The parameter passed to <see cref="Execute(object)"/>; otherwise, a null reference.
        /// </value>
        public object Parameter
        {
            get;
            private set;
        }

        #endregion Properties

        #region Execute

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute. 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter">not used.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return Enabled;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked asynchronously
        /// </summary>
        public void Execute(object parameter = null)
        {
            if (_enabled)
            {
                Parameter = parameter;
                try
                {
                    _action(this);
                }
                finally
                {
                    Parameter = null;
                }
            }
            else
            {
                Task.Run(() => { }).GetAwaiter();
            }
        }

        #endregion Execute

        #region Cached PropertyChangedEventArgs

        internal static readonly PropertyChangedEventArgs EnabledChangedEventArgs = new PropertyChangedEventArgs(nameof(Enabled));

        #endregion Cached PropertyChangedEventArgs
    }
}
