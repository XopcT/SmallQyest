using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmallQyest
{
    /// <summary>
    /// Base Class which can be bounded.
    /// </summary>
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when one of the Properties change it's Value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        /// <param name="sender">Object which raised the Event.</param>
        /// <param name="propertyName">Name of the Property that changed.</param>
        protected void OnPropertyChanged(object sender, [CallerMemberName()]string propertyName = "")
        {
            var temp = this.PropertyChanged;
            if (temp != null)
                temp(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
