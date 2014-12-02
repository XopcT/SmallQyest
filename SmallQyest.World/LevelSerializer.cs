using System;
using Newtonsoft.Json;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Extension Methods to serialize/deserialize a Level.
    /// </summary>
    public static class LevelSerializer
    {
        /// <summary>
        /// Retrieves a String Representation of a Level.
        /// </summary>
        /// <param name="level">Level to serialize.</param>
        /// <returns>String Representation of a Level.</returns>
        public static string Serialize(this Level level)
        {
            string result = JsonConvert.SerializeObject(level, Formatting.Indented, converters);
            return result;
        }

        /// <summary>
        /// Deserializes a Level.
        /// </summary>
        /// <param name="source">String to deserialize a Level from.</param>
        /// <returns>Deserialized Level Instance.</returns>
        public static Level Deserialize(string source)
        {
            throw new NotImplementedException();
        }

        #region Fields

        private static readonly JsonConverter[] converters = new JsonConverter[]
        {
            new LevelConverter(),
            new ItemConverter(),
        };

        #endregion
    }
}
