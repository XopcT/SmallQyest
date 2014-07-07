using SmallQyest.World.Characters;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for Chracters.
    /// </summary>
    public class CharacterWrapper : WrapperBase<CharacterBase>
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Character to wrap.</param>
        public CharacterWrapper(CharacterBase wrapped)
            : base(wrapped)
        {
        }

        /// <summary>
        /// Updates the State of the Character.
        /// </summary>
        public void Update()
        {
            this.X = base.Wrapped.X;
            this.Y = this.Wrapped.Y;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the X-Coordinate of the Character.
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
        /// Sets/retrieves the Y-Coordinate of the Character.
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
