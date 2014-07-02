
namespace SmallQyest.World
{
    /// <summary>
    /// Represents a Path on the Ground. The only Type of the Ground a Character can pass.
    /// </summary>
    public class Path : Ground
    {
        /// <summary>
        /// Checks whether the Ground can be passed by a Character.
        /// </summary>
        /// <returns>True if Ground can be passed, False otherwise.</returns>
        public override bool CanPassThrough()
        {
            // A Path can be passed. Retrieves True.
            return true;
        }
    }
}
