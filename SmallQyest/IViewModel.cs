using System.ComponentModel;

namespace SmallQyest
{
    /// <summary>
    /// Defines an Interface of a View Model.
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Handles Navigation to this View Model.
        /// </summary>
        void OnNavigateTo();

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        void OnNavigateFrom();
    }
}
