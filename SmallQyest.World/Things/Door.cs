
namespace SmallQyest.World.Things
{
    /// <summary>
    /// Represents a Door which can be passed depending on some Conditions.
    /// </summary>
    public class Door : Thing
    {
        /// <summary>
        /// Checks whether the Door can be passed by another Item.
        /// If the Door is open, it can be passed by anyone. Nobody can passed the closed Door.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if the Door can be passed, False otherwise.</returns>
        public override bool CanPassThrough(Item item)
        {
            return this.IsOpen;
        }

        /// <summary>
        /// Opens the Door.
        /// </summary>
        protected void Open()
        {
            this.IsOpen = true;
        }

        /// <summary>
        /// Closes the Door.
        /// </summary>
        protected void Close()
        {
            this.IsOpen = false;
        }

        #region Properties

        /// <summary>
        /// Retrieves whether an Obstacle is open.
        /// </summary>
        public bool IsOpen
        {
            get { return this.isOpen; }
            private set
            {
                this.isOpen = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private bool isOpen = false;

        #endregion
    }
}
