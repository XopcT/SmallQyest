using System.Linq;
using SmallQyest.World;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Door of the specified Color.
    /// </summary>
    public class ColoredDoor : Door
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
            if (base.CanPassThrough(item))
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
            if (character != null)
            {
                return character.Has<ColoredKey>(key => key.Color == this.Color);
            }
            return false;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Color of the Key.
        /// </summary>
        public ItemColor Color
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
        private ItemColor color = ItemColor.Red;

        #endregion
    }
}
