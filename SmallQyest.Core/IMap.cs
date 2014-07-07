using System;
using System.Collections.Generic;

namespace SmallQyest.Core
{
    /// <summary>
    /// Defines an Interface of a Game Map.
    /// </summary>
    public interface IMap : ICollection<IItem>
    {
        /// <summary>
        /// Retrieves Items with the specified Coordinates.
        /// </summary>
        /// <param name="x">X-Coordinate of Items.</param>
        /// <param name="y">Y-Coordinate of Items.</param>
        /// <returns>Items with the specified Coordinates.</returns>
        IEnumerable<IItem> GetItems(int x, int y);

        /// <summary>
        /// Retrieves Items of the specified Type with the specified Coordinates.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to retrieve.</typeparam>
        /// <param name="x">X-Coordinate of Items.</param>
        /// <param name="y">Y-Coordinate of Items.</param>
        /// <returns>Items of the specified Type with the specified Coordinates.</returns>
        IEnumerable<ItemType> GetItems<ItemType>(int x, int y)
            where ItemType : IItem;

        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        void Update();

        /// <summary>
        /// Retrieves a Level the Map belongs to.
        /// </summary>
        ILevel Level { get; }

        /// <summary>
        /// Retrieves Width of the Map.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Retrieves Height of the Map.
        /// </summary>
        int Height { get; }
    }
}
