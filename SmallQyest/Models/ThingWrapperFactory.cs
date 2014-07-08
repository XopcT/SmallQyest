using SmallQyest.World.Things;

namespace SmallQyest.Models
{
    /// <summary>
    /// Creates Models for different Things.
    /// </summary>
    public static class ThingWrapperFactory
    {
        /// <summary>
        /// Creates a Model.
        /// </summary>
        /// <param name="wrapped">Thing to create Model for.</param>
        /// <returns>Model Instance.</returns>
        public static ThingWrapper CreateWrapper(Thing wrapped)
        {
            if (wrapped is OneTimePassObstacle)
                return new OneTimePassObstacleWrapper((OneTimePassObstacle)wrapped);
            return new ThingWrapper(wrapped);
        }
    }
}
