
namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface to serialize/deserialize Levels.
    /// </summary>
    public interface ILevelSerializationService
    {
        /// <summary>
        /// Retrieves a String Representation of a Level.
        /// </summary>
        /// <param name="level">Level to serialize.</param>
        /// <returns>String Representation of a Level.</returns>
        string Serialize(Level level);

        /// <summary>
        /// Deserializes a Level.
        /// </summary>
        /// <param name="source">String to deserialize a Level from.</param>
        /// <returns>Deserialized Level Instance.</returns>
        Level Deserialize(string source);
    }
}
