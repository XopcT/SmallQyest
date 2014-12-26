
namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Sign which specifies Direction on Crossroads.
    /// </summary>
    public class RoadSign : Thing
    {
        #region Properties

        /// <summary>
        /// Sets/retrieves a Direction a Character has to come from to be affected by the Sign.
        /// </summary>
        public Vector EnterDirection
        {
            get { return this.enterDirection; }
            set
            {
                this.enterDirection = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Sets/retrieves a Direction a Character goes after the Sign.
        /// </summary>
        public Vector NewDirection
        {
            get { return this.newDirection; }
            set
            {
                this.newDirection = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private Vector enterDirection = Vector.Left;
        private Vector newDirection = Vector.Down;

        #endregion
    }
}
