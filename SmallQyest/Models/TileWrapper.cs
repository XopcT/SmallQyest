using SmallQyest.World.Tiles;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for Tiles.
    /// </summary>
    public class TileWrapper : WrapperBase<Tile>
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Tile to wrap.</param>
        public TileWrapper(Tile wrapped)
            : base(wrapped)
        {
        }

        /// <summary>
        /// Updates the State of the Tile.
        /// </summary>
        public void Update()
        {
        }

        #region Properties

        /// <summary>
        /// Retrieves the X-Coordinate of the Tile.
        /// </summary>
        public int X
        {
            get { return base.Wrapped.X; }
        }

        /// <summary>
        /// Retrieves the Y-Coordinate of the Tile.
        /// </summary>
        public int Y
        {
            get { return base.Wrapped.Y; }
        }

        #endregion

        #region Fields

        #endregion
    }
}
