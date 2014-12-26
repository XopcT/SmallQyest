using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Weapon of the specified Color.
    /// </summary>
    public class ColoredWeapon : PickableThing<Character>
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves a Color of the Weapon.
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
