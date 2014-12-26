using System;
using SmallQyest.World.Things;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// An Enemy of the specified Color.
    /// </summary>
    public class ColoredEnemy : Enemy
    {
        /// <summary>
        /// Checks whether an Enemy is defeated by a specified Character.
        /// Colored Enemy can be defeated with a Weapon of the same Color.
        /// </summary>
        /// <param name="character">Character to check agaist him.</param>
        /// <returns>True if the Enemy is defeted by the specified Character, False otherwise.</returns>
        protected override bool IsDefeated(Character character)
        {
            return character.Has<ColoredWeapon>(weapon => weapon.Color == this.Color);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Color of the Enemy.
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
