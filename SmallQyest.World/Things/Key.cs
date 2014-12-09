using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// Represents a Key to pass a Door.
    /// </summary>
    public class Key : Thing
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
                character.PickUp(this);
            }
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
