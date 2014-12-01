
namespace SmallQyest.World.Things
{
    /// <summary>
    /// Represents a Door which can be passed depending on some Conditions.
    /// </summary>
    public class Door : Thing
    {
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
