using System.Collections.Generic;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of a Game Map.
    /// </summary>
    public interface IMap : ICollection<IItem>
    {
        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        void Update();
    }
}
