using System.Collections.Generic;

namespace SmallQyest.Core
{
    /// <summary>
    /// Defines an Interface of an Item.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Retrieves the Map the Item belongs to.
        /// </summary>
        Map Map { get; }

        /// <summary>
        /// Retrieves the Item's X-Coordinate on the Map.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Retrieves the Item's Y-Coordinate on the Map.
        /// </summary>
        int Y { get; }
    }
}
