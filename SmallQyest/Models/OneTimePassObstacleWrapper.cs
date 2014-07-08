using SmallQyest.World.Things;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for one Time pass Obstacle.
    /// </summary>
    public class OneTimePassObstacleWrapper : ThingWrapper
    {
        /// <summary>
        /// Initializes a new Instance of current Class.s
        /// </summary>
        /// <param name="wrapped">One Time pass Obstacle to wrap.</param>
        public OneTimePassObstacleWrapper(OneTimePassObstacle wrapped)
            : base(wrapped)
        {
        }

        /// <summary>
        /// Updates the State of the Obstacle.
        /// </summary>
        public override void Update()
        {
            base.Update();
            this.IsOpen = ((OneTimePassObstacle)base.Wrapped).IsOpen;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves whether the Obstacle is open.
        /// </summary>
        public bool IsOpen
        {
            get { return this.isOpen; }
            set
            {
                if (this.isOpen != value)
                {
                    this.isOpen = value;
                    base.OnPropertyChanged(this);
                    base.OnPropertyChanged(this, "IsClosed");
                }
            }
        }

        /// <summary>
        /// Sets/retrieves whether the Obstacle is closed.
        /// </summary>
        public bool IsClosed
        {
            get { return !this.isOpen; }
        }

        #endregion

        #region Fields
        private bool isOpen = false;

        #endregion
    }
}
