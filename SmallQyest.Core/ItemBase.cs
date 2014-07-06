using System;

namespace SmallQyest.Core
{
    /// <summary>
    /// Base Class for creating Items.
    /// </summary>
    public class ItemBase : IItem
    {
        /// <summary>
        /// Updates the State of the Item.
        /// </summary>
        /// <param name="elapsedTime">Time passed since previous Update.</param>
        public virtual void Update(TimeSpan elapsedTime)
        {
            // Nothing needs to be done in current Context.
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Map the Item belongs to.
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's X-Coordinate on the Map.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's Y-Coordinate on the Map.
        /// </summary>
        public int Y { get; set; }

        #endregion

        #region Fields

        #endregion

    }
}
