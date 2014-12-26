using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Checks whether a Character has a specified Item.
        /// </summary>
        /// <typeparam name="ItemType">Type of Item to check for.</typeparam>
        /// <returns>True if Character has specified Item, False otherwise.</returns>
        public bool Has<ItemType>()
            where ItemType : Item
        {
            return this.Inventory.Where(item => item is ItemType).Any();
        }

        /// <summary>
        /// Checks whether a Character has a specified Item.
        /// </summary>
        /// <typeparam name="ItemType">Type of Item to check for.</typeparam>
        /// <param name="itemValidation">Function to validate an Item.</param>
        /// <returns>True if Character has specified Item, False otherwise.</returns>
        public bool Has<ItemType>(Func<ItemType, bool> itemValidation)
            where ItemType : Item
        {
            return this.inventory
                .Where(item => item is ItemType)
                .Cast<ItemType>()
                .Where(item => itemValidation(item))
                .Any();
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
