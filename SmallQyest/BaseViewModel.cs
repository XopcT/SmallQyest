using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmallQyest
{
    /// <summary>
    /// Base Class for creating View Models.
    /// </summary>
    public class BaseViewModel : IViewModel
    {
        #region Events

        /// <summary>
        /// Occurs when one of the Properties change it's Value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        /// <param name="sender">Object which raised the Event.</param>
        /// <param name="propertyName">Name of the Property that changed.</param>
        protected void OnPropertyChanged(object sender, string propertyName)
        {
            var temp = this.PropertyChanged;
            if (temp != null)
                temp(sender, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        /// <param name="propertyName">Name of the Property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName()] string propertyName = "")
        {
            this.OnPropertyChanged(this, propertyName);
        }

        #endregion

        #region Properties



        #endregion

        #region Fields

        #endregion
    }
}
