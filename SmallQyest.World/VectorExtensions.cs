
namespace SmallQyest.World
{
    /// <summary>
    /// Contains Extension Methods for Vectors.
    /// </summary>
    public static class VectorExtensions
    {
        /// <summary>
        /// Retrieves a Vector with the same Direction as current one.
        /// </summary>
        /// <param name="vector">Source Vector.</param>
        /// <returns>Vector with the same Direction as current one.</returns>
        public static Vector GetForward(this Vector vector)
        {
            return vector;
        }

        /// <summary>
        /// Retrieves a Vector directing to the right from current one.
        /// </summary>
        /// <param name="vector">Source Vector.</param>
        /// <returns>Vector directing to the right from current one.</returns>
        public static Vector GetRight(this Vector vector)
        {
            int newX = -vector.Y;
            int newY = vector.X;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Retrieves a Vector directing to the left from current one.
        /// </summary>
        /// <param name="vector">Source Vector.</param>
        /// <returns>Vector directing to the left from current one.</returns>
        public static Vector GetLeft(this Vector vector)
        {
            int newX = vector.Y;
            int newY = -vector.X;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Retrieves a Vector with the backward Direction from current one.
        /// </summary>
        /// <param name="vector">Source Vector.</param>
        /// <returns>Vector with the backward Direction from current one.</returns>
        public static Vector GetBackward(this Vector vector)
        {
            return -vector;
        }
    }
}
