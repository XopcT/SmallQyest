using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Extension Methods for Items' Collections.
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Retrieves Items at the specified Location.
        /// </summary>
        /// <param name="items">Collection of Items to look in.</param>
        /// <param name="position">Position of Items.</param>
        /// <returns>Items at the specified Location.</returns>
        public static IEnumerable<Item> GetItems(this IEnumerable<Item> items, Vector position)
        {
            return items.GetItems<Item>(position);
        }

        /// <summary>
        /// Retrieves Items at the specified Location.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to retrieve.</typeparam>
        /// <param name="items">Collection of Items to look in.</param>
        /// <param name="position">Position of Items.</param>
        /// <returns>Items of the specified Type at the specified Location.</returns>
        public static IEnumerable<ItemType> GetItems<ItemType>(this IEnumerable<Item> items, Vector position)
            where ItemType : Item
        {
            return items
                .Where(item => item is ItemType && item.Position == position)
                .Cast<ItemType>();
        }

        /// <summary>
        /// Retrieves Items of the specified Type.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to look for.</typeparam>
        /// <param name="items">Collection of Items to look in.</param>
        /// <returns>Items of the specified Type.</returns>
        public static IEnumerable<ItemType> GetItems<ItemType>(this IEnumerable<Item> items)
            where ItemType : Item
        {
            return items
                .Where(item => item is ItemType)
                .Cast<ItemType>();
        }
    }
}
