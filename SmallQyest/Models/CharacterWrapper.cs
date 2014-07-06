using SmallQyest.World;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for Chracters.
    /// </summary>
    public class CharacterWrapper : BindableBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Character to wrap.</param>
        public CharacterWrapper(CharacterBase wrapped)
        {
            this.wrapped = wrapped;
        }

        /// <summary>
        /// Updates the State of the Wrapper
        /// </summary>
        public void Update()
        {
            this.X = this.wrapped.X;
            this.Y = this.wrapped.Y;
        }

        #region Properties

        /// <summary>
        /// Retrieves the original Character.
        /// </summary>
        public CharacterBase Wrapped
        {
            get { return this.wrapped; }
        }

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
        private readonly CharacterBase wrapped = null;
        private int x = 0;
        private int y = 0;

        #endregion
    }
}
