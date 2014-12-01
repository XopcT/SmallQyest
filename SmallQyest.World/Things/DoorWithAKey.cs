using System.Linq;
using SmallQyest.World;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Door which can be passed only with a Key.
    /// </summary>
    public class DoorWithAKey : Door
    {
        /// <summary>
        /// Initializes the Item.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            base.Close();
        }

        /// <summary>
        /// Checks whether an Item can be passed by another Item.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if an Item can be passed, False otherwise.</returns>
        public override bool CanPassThrough(Item item)
        {
            // Any Object can pass an opened Door:
            if (this.IsOpen)
                return true;
            // The Door is closed, so checking whether a Character has a Key to pass it:
            return this.HasKey(item);
        }

        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            if (this.IsOpen)
                return;
            if (this.HasKey(item))
                base.Open();
        }

        /// <summary>
        /// Checks whether an Item is a Character and has a Key from this Door.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <returns>True if Character has a Key from this Door, False otherwise.</returns>
        private bool HasKey(Item item)
        {
            Actors.Character character = item as Actors.Character;
            if (character != null && character.Inventory != null)
            {
                bool hasKey = character.Inventory
                    .Where(inventoryItem => inventoryItem is Key && ((Key)inventoryItem).Color == this.color)
                    .Any();
                return hasKey;
            }
            return false;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Color of the Key.
        /// </summary>
        public KeyColor Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private KeyColor color = KeyColor.Red;

        #endregion
    }
}
