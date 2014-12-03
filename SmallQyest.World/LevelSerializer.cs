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
            ItemConverter itemConverter = new ItemConverter();
            itemConverter.Register("Grass", () => new Tiles.Grass(), x => x.Position);
            itemConverter.Register("Path", () => new Tiles.Path(), x => x.Position);
            itemConverter.Register("FallTrap", () => new Things.FallTrap(), x => x.Position);
            itemConverter.Register("MoveableObstacle", () => new Things.MoveableObstacle(), x => x.Position);
            itemConverter.Register("OneTimePassObstacle", () => new Things.OneTimePassObstacle(), x => x.Position);
            itemConverter.Register("Player", () => new Actors.Player(),
                x => x.Position,
                x => x.Direction);
            itemConverter.Register("LevelEndTrigger", () => new Triggers.LevelEndTrigger(), x => x.Position);
            itemConverter.Register("PlayerSpawnTrigger", () => new Triggers.PlayerSpawnTrigger(), x => x.Position);
            string result = JsonConvert.SerializeObject(level, Formatting.Indented, new LevelConverter(), itemConverter);
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

        #endregion
    }
}
