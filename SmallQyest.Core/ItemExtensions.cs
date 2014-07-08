using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.Core
{
    /// <summary>
    /// Contains Extension Methods for Items' Collections.
    /// </summary>
    public static class ItemExtensions
    {
        /// <summary>
        /// Retrieves Items at the specified Location.
        /// </summary>
        /// <param name="items">Collection of Items to look in.</param>
        /// <param name="x">X-Coordinate of Items.</param>
        /// <param name="y">Y-Coordinate of Items.</param>
        /// <returns>Items at the specified Location.</returns>
        public static IEnumerable<IItem> GetItems(this IEnumerable<IItem> items, int x, int y)
        {
            return items
                .Where(item => item.X == x && item.Y == y);
        }

        /// <summary>
        /// Retrieves Items at the specified Location.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to retrieve.</typeparam>
        /// <param name="items">Collection of Items to look in.</param>
        /// <param name="x">X-Coordinate of Items.</param>
        /// <param name="y">Y-Coordinate of Items.</param>
        /// <returns>Items of the specified Type at the specified Location.</returns>
        public static IEnumerable<ItemType> GetItems<ItemType>(this IEnumerable<IItem> items, int x, int y)
            where ItemType : IItem
        {
            return items
                .Where(item => item is ItemType && item.X == x && item.Y == y)
                .Cast<ItemType>();
        }

        /// <summary>
        /// Retrieves Items of the specified Type.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to look for.</typeparam>
        /// <param name="items">Collection of Items to look in.</param>
        /// <returns>Items of the specified Type.</returns>
        public static IEnumerable<ItemType> FindItems<ItemType>(this IEnumerable<IItem> items)
            where ItemType : IItem
        {
            return items
                .Where(item => item is ItemType)
                .Cast<ItemType>();
        }
    }
}
