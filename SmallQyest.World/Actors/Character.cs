using System.Collections.Generic;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class Character : Actor
    {
        /// <summary>
        /// Checks whether an Item can be passed by another Item.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if an Item can be passed, False otherwise.</returns>
        public override bool CanPassThrough(Item item)
        {
            // Nothing can Pass through a Character:
            return false;
        }

        #region Properties

        /// <summary>
        /// Retrieves the Character's Inventory.
        /// </summary>
        public ICollection<Item> Inventory
        {
            get { return this.inventory; }
        }

        #endregion

        #region Fields
        private readonly ICollection<Item> inventory = new List<Item>();

        #endregion
    }
}
