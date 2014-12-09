﻿
namespace SmallQyest.World.Things
{
    /// <summary>
    /// Represents a Key to pass a Door.
    /// </summary>
    public class Key : Thing
    {
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
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
