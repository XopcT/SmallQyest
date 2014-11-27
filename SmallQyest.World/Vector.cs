
namespace SmallQyest.World
{
    /// <summary>
    /// 2D Vector.
    /// </summary>
    public struct Vector
    {
        /// <summary>
        /// Initializes a new Instance of current Structure.
        /// </summary>
        /// <param name="x">X-Component of the Vector.</param>
        /// <param name="y">Y-Component of the Vector.</param>
        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Adds two Vectors.
        /// </summary>
        /// <param name="left">First Vector to add.</param>
        /// <param name="right">Second Vector to add.</param>
        /// <returns>Sum of two Vectors.</returns>
        public static Vector operator +(Vector left, Vector right)
        {
            return new Vector(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        /// Subtracts one Vector from another.
        /// </summary>
        /// <param name="left">Vector to subtract from.</param>
        /// <param name="right">Vector to subtract.</param>
        /// <returns>Subtract Result of two Vectors.</returns>
        public static Vector operator -(Vector left, Vector right)
        {
            return new Vector(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        /// Retrieves a Vector negative to current one.
        /// </summary>
        /// <param name="vector">Source Vector.</param>
        /// <returns>Vector negative to current one.</returns>
        public static Vector operator -(Vector vector)
        {
            return new Vector(-vector.X, -vector.Y);
        }

        /// <summary>
        /// Checks whether two Vectors are equal.
        /// </summary>
        /// <param name="left">First Vector to compare.</param>
        /// <param name="right">Second Vector to compare.</param>
        /// <returns>True if Vectors are equal, False otherwise.</returns>
        public static bool operator ==(Vector left, Vector right)
        {
            return (left.X == right.X && left.Y == right.Y);
        }

        /// <summary>
        /// Checks whether two Vectors are unequal.
        /// </summary>
        /// <param name="left">First Vector to compare.</param>
        /// <param name="right">Second Vector to compare.</param>
        /// <returns>True if Vectors are unequal, False otherwise.</returns>
        public static bool operator !=(Vector left, Vector right)
        {
            return (left.X != right.X || left.Y != right.Y);
        }

        /// <summary>
        /// Checks whether a Vector is equal to current one.
        /// </summary>
        /// <param name="obj">Vector to compare.</param>
        /// <returns>True if Vector is equal to current one, False otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector && this == (Vector)obj);
        }

        /// <summary>
        /// Retrieves a Hashcode for a Vector.
        /// </summary>
        /// <returns>Hashcode for a Vector.</returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode();
        }

        #region Fields

        /// <summary>
        /// X-Component of the Vector.
        /// </summary>
        public int X;

        /// <summary>
        /// Y-Component of the Vector.
        /// </summary>
        public int Y;

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
