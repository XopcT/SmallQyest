using SmallQyest.Core;

namespace SmallQyest.World.Tiles
{
    /// <summary>
    /// Represents a Path on the Map.
    /// </summary>
    public class Path : Tile
    {
        /// <summary>
        /// Checks whether a Tiles can be passed by another Item.
        /// A Path is the best Way to travel through the Map. It can be passed by anyone.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if a Tile can be passed, False otherwise.</returns>
        public override bool CanPassThroug(IItem item)
        {
            return true;
        }

    }
}
