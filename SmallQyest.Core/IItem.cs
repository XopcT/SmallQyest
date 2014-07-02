using System.Collections.Generic;

namespace SmallQyest.Core
{
    /// <summary>
    /// Defines an Interface of an Item.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Sets/retrieves the Map the Item belongs to.
        /// </summary>
        Map Map { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's X-Coordinate on the Map.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's Y-Coordinate on the Map.
        /// </summary>
        int Y { get; set; }
    }
}
