using SmallQyest.World.Tiles;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for Tiles.
    /// </summary>
    public class TileWrapper : BindableBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Tile to wrap.</param>
        public TileWrapper(TileBase wrapped)
        {
            this.wrapped = wrapped;
        }

        /// <summary>
        /// Updates the State of the Wrapper.
        /// </summary>
        public void Update()
        {
        }

        #region Properties

        /// <summary>
        /// Retrieves the original Tile.
        /// </summary>
        public TileBase Wrapped
        {
            get { return this.wrapped; }
        }

        /// <summary>
        /// Retrieves the X-Coordinate of the Tile.
        /// </summary>
        public int X
        {
            get { return this.wrapped.X; }
        }

        /// <summary>
        /// Retrieves the Y-Coordinate of the Tile.
        /// </summary>
        public int Y
        {
            get { return this.wrapped.Y; }
        }

        #endregion

        #region Fields
        private readonly TileBase wrapped = null;

        #endregion
    }
}
