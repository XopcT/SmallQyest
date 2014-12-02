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
        /// <param name="map">Map to look in.</param>
        /// <param name="position">Position of Items.</param>
        /// <returns>Items at the specified Location.</returns>
        public static IEnumerable<Item> GetItems(this IEnumerable<Item> map, Vector position)
        {
            return map.GetItems<Item>(position);
        }

        /// <summary>
        /// Retrieves Items at the specified Location.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to retrieve.</typeparam>
        /// <param name="map">Map to look in.</param>
        /// <param name="position">Position of Items.</param>
        /// <returns>Items of the specified Type at the specified Location.</returns>
        public static IEnumerable<ItemType> GetItems<ItemType>(this IEnumerable<Item> map, Vector position)
            where ItemType : Item
        {
            return map
                .Where(item => item is ItemType && item.Position == position)
                .Cast<ItemType>();
        }

        /// <summary>
        /// Retrieves Items of the specified Type.
        /// </summary>
        /// <typeparam name="ItemType">Type of Items to look for.</typeparam>
        /// <param name="map">Map to look in.</param>
        /// <returns>Items of the specified Type.</returns>
        public static IEnumerable<ItemType> GetItems<ItemType>(this IEnumerable<Item> map)
            where ItemType : Item
        {
            return map
                .Where(item => item is ItemType)
                .Cast<ItemType>();
        }

        /// <summary>
        /// Checks whether an Item can move in specified Direction.
        /// </summary>
        /// <param name="map">Map with potential Obstacles.</param>
        /// <param name="item">Item which tries to move.</param>
        /// <param name="direction">Direction to check.</param>
        /// <returns>True if an Item can move, False otherwise.</returns>
        public static bool CanMoveTo(this IEnumerable<Item> map, Item item, Vector direction)
        {
            Vector newPosition = item.Position + direction;
            IEnumerable<bool> passTestResults = map
                .GetItems<Item>(newPosition)
                .Select(arg => arg.CanPassThrough(item));
            return passTestResults.Any() && passTestResults.All(result => result == true);
        }

        /// <summary>
        /// Checks whether specified Point on the Map can be seen by an Item.
        /// </summary>
        /// <param name="map">Map with potential Obstacles.</param>
        /// <param name="item">Item which tries to see specified Point.</param>
        /// <param name="point">Point to check.</param>
        /// <returns>True if an Item can see the Point, False otherwise.</returns>
        public static bool CanSee(this IEnumerable<Item> map, Item item, Vector point)
        {
            throw new NotImplementedException();
        }
    }
}
