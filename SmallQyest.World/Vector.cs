
namespace SmallQyest.World
{
    /// <summary>
    /// 2D Vector.
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="x">X-Component of the Vector.</param>
        /// <param name="y">Y-Component of the Vector.</param>
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Retrieves a Vector with the same Direction as this one.
        /// </summary>
        /// <returns>Vector Instance.</returns>
        public Vector GetForward()
        {
            return this;
        }

        /// <summary>
        /// Retrieves a Vector directing to the right from this one.
        /// </summary>
        /// <returns>Vector Instance.</returns>
        public Vector GetRight()
        {
            int newX = -this.Y;
            int newY = this.X;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Retrieves a Vector directing to the left from this one.
        /// </summary>
        /// <returns>Vector Instance.</returns>
        public Vector GetLeft()
        {
            int newX = this.Y;
            int newY = -this.X;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Retrieves a Vector with the backward Direction from this one.
        /// </summary>
        /// <returns>Vector Instance.</returns>
        public Vector GetBackward()
        {
            int newX = -this.X;
            int newY = -this.Y;
            return new Vector(newX, newY);
        }

        #region Properties

        /// <summary>
        /// Retrieves the X-Component of the Vector.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Retrieves the Y-Component of the Vector.
        /// </summary>
        public int Y { get; private set; }

        #endregion

        #region Fields

        /// <summary>
        /// Vector which directs up.
        /// </summary>
        public static readonly Vector Up = new Vector(0, -1);

        /// <summary>
        /// Vector which directs right.
        /// </summary>
        public static readonly Vector Right = new Vector(+1, 0);

        /// <summary>
        /// Vector which directs down.
        /// </summary>
        public static readonly Vector Down = new Vector(0, +1);

        /// <summary>
        /// Vector which directs left.
        /// </summary>
        public static readonly Vector Left = new Vector(-1, 0);

        #endregion
    }
}
