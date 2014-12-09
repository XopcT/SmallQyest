using System.Collections.Generic;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class Character : Actor
    {
        /// <summary>
        /// Picks up an Item.
        /// </summary>
        /// <param name="item">Item to pick up.</param>
        public void PickUp(Item item)
        {
            // This Method helps to avoid the Collection change Exception
            // when an Item is removed from the Map an put into the Character's Inventory.
            if (this.updating)
            {
                this.toPickup.Enqueue(item);
            }
            else
            {
                this.Map.Remove(item);
                this.inventory.Add(item);
            }
        }

        /// <summary>
        /// Updates the State of the Character.
        /// </summary>
        public override void Update()
        {
            try
            {
                this.updating = true;
                base.Update();
                // Checking if there were any Items to pick up during the OnVisit/OnLeave Loops:
                while (this.toPickup.Count > 0)
                {
                    Item item = this.toPickup.Dequeue();
                    this.Map.Remove(item);
                    this.inventory.Add(item);
                }
            }
            finally
            {
                this.updating = false;
            }
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
        private bool updating = false;
        private readonly ICollection<Item> inventory = new List<Item>();
        private readonly Queue<Item> toPickup = new Queue<Item>();

        #endregion
    }
}
