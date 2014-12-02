using SmallQyest.World;
using SmallQyest.World.Actors;

namespace SmallQyest.World.Tiles
{
    /// <summary>
    /// Represents a Grass on the Map. This Tile can not be passed by a Character.
    /// </summary>
    public class Grass : Tile
    {
        /// <summary>
        /// Checks whether a Tiles can be passed by another Item.
        /// Characters can not pass the Grass.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if a Tile can be passed, False otherwise.</returns>
        public override bool CanPassThrough(Item item)
        {
            return false;
        }
    }
}
