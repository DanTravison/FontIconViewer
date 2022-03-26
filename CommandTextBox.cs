using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FontIconViewer
{
    /// <summary>
    /// Provides a <see cref="EditBox"/> with a <see cref="Command"/> that is invoked when
    /// <see cref="Key.Enter"/> is pressed.
    /// </summary>
    public class CommandTextBox : TextBox
    {
		public CommandTextBox()
            : base()
        {
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Enter && IsEnabled && AcceptsReturn == false)
            {
                ICommand command = this.Command;
                if (command != null && command.CanExecute(null))
                {
                    var binding = base.GetBindingExpression(TextBox.TextProperty);
                    if (binding != null)
                    {
                        // NOTE: TextBox doesn't perform an UpdateSource until focus is
                        // lost. Since we still have focus, force the UpdateSource before
                        // invoking the command.
                        binding.UpdateSource();
                    }
                    command.Execute(command);
                    e.Handled = true;
                }
            }
        }

        #region Dependency Properties

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to use when <see cref="VirtualKey.Enter"/> is pressed.
        /// </summary>
        /// <remarks>
        /// The <see cref="ICommand"/> is only invoke when <see cref="TextBox.AcceptsReturn"/> is false,
        /// <see cref="TextBox.IsEnabled"/> is true, and <see cref="Command.Enabled"/> is true.
        /// </remarks>
        public ICommand Command
        {
            get => GetValue(CommandProperty) as ICommand;
            set => SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Command"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register
        (
            nameof(Command),
            typeof(ICommand),
            typeof(CommandTextBox),
            new PropertyMetadata(null)
        );

        #endregion Dependency Properties
    }
}
