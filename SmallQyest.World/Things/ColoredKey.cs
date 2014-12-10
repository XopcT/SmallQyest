using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Key of the specified Color.
    /// </summary>
    public class ColoredKey : Thing
    {
        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            Character character = item as Character;
            if (character != null)
            {
                this.Map.Remove(this);
                character.Inventory.Add(this);
            }
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
