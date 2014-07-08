using SmallQyest.World.Things;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for different Things.
    /// </summary>
    public class ThingWrapper : WrapperBase<Thing>
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Thing to wrap.</param>
        public ThingWrapper(Thing wrapped)
            : base(wrapped)
        {
        }

        /// <summary>
        /// Updates the State of the Thing.
        /// </summary>
        public virtual void Update()
        {
            this.X = base.Wrapped.X;
            this.Y = base.Wrapped.Y;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the X-Coordinate of the Thing.
        /// </summary>
        public int X
        {
            get { return this.x; }
            set
            {
                this.x = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Sets/retrieves the Y-Coordinate of the Thing.
        /// </summary>
        public int Y
        {
            get { return this.y; }
            set
            {
                this.y = value;
                base.OnPropertyChanged(this);
            }
        }


        #endregion

        #region Fields
        private int x = 0;
        private int y = 0;

        #endregion
    }
}
