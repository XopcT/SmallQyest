using System;
using Newtonsoft.Json;

namespace SmallQyest.World.Serialization
{
    /// <summary>
    /// Serializes/Deserializes a Level using Json.
    /// </summary>
    public class JsonLevelSerializer : ILevelSerializationService
    {
        public JsonLevelSerializer(IItemFactory itemFactory)
        {
            if (itemFactory == null)
                throw new ArgumentNullException("itemFactory");
            this.itemFactory = itemFactory;
        }

        /// <summary>
        /// Retrieves a String Representation of a Level.
        /// </summary>
        /// <param name="level">Level to serialize.</param>
        /// <returns>String Representation of a Level.</returns>
        public string Serialize(Level level)
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
        public Level Deserialize(string source)
        {
            JsonConvert.DeserializeObject<Level>(source, new LevelConverter());
            throw new NotImplementedException();
        }

        #region Fields
        private readonly IItemFactory itemFactory = null;

        #endregion
    }
}
