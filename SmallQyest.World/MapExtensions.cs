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
        /// Retrieves the Width of the Map.
        /// </summary>
        /// <param name="map">Map who's Width to retrieve.</param>
        /// <returns>Width of the Map.</returns>
        public static int GetWidth(this IEnumerable<Item> map)
        {
            if (map.Any())
                return map.Max(item => item.Position.X) + 1;
            else
                return 0;
        }

        /// <summary>
        /// Retrieves the Height of the Map.
        /// </summary>
        /// <param name="map">Map who's Height to retrieve.</param>
        /// <returns>Height of the Map.</returns>
        public static int GetHeight(this IEnumerable<Item> map)
        {
            if (map.Any())
                return map.Max(item => item.Position.Y) + 1;
            else
                return 0;
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
        /// Checks whether one Point can be seen from another.
        /// </summary>
        /// <param name="map">Map with potential Obstacles.</param>
        /// <param name="from">Point from which a Visibility Test is casted.</param>
        /// <param name="to">Point to check for a Visibility.</param>
        /// <returns>True if a Point is seen, False otherwise.</returns>
        public static bool CanSee(this IEnumerable<Item> map, Vector from, Vector to)
        {
            Vector direction = to - from;
            if (!(direction.X == 0 ^ direction.Y == 0))
                return false;

            Vector dPos = new Vector(Math.Sign(direction.X), Math.Sign(direction.Y));

            visibilityRay.Position = from;
            while (visibilityRay.Position != to)
            {
                if (!map.CanMoveTo(visibilityRay, dPos))
                    return false;
                visibilityRay.Position += dPos;
            }
            return true;
        }

        private static readonly Triggers.VisibilityRay visibilityRay = new Triggers.VisibilityRay();
    }
}
