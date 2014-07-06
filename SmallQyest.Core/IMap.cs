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
        /// Updates the State of the Map.
        /// </summary>
        /// <param name="elapsedTime">Time passed since previous Update.</param>
        void Update(TimeSpan elapsedTime);

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
