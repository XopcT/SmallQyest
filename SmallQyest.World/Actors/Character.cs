using System.Collections.Generic;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class Character : Actor
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves the Character's Inventory.
        /// </summary>
        public ICollection<Item> Inventory
        {
            get { return this.inventory; }
            set
            {
                this.inventory = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private ICollection<Item> inventory = new List<Item>();

        #endregion
    }
}
