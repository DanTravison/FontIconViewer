using System.ComponentModel;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides an abstract base class for classes supporting INotifyPropertyChanged
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        protected ObservableObject()
        {
        }

        #region INotifyPropertyChanged

        /// <summary>
        /// Occurs when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event with a cached <see cref="PropertyChangedEventArgs"/>.
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> for the event.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion INotifyPropertyChanged
    }
}
