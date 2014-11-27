
namespace SmallQyest.World.Things
{
    /// <summary>
    /// Represents a Door which can be passed depending on some Conditions.
    /// </summary>
    public class Door : Thing
    {
        #region Properties

        /// <summary>
        /// Retrieves whether an Obstacle is open.
        /// </summary>
        public bool IsOpen
        {
            get { return this.isOpen; }
            protected set
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
