using System.ComponentModel;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of an Item.
    /// </summary>
    public interface IItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes the Item.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Updates the State of the Item.
        /// </summary>
        void Update();

        /// <summary>
        /// Sets/retrieves the Level the Item belongs to.
        /// </summary>
        ILevel Level { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's Position on the Map.
        /// </summary>
        Vector Position { get; set; }
    }
}
