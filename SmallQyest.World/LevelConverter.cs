using System.Collections.Generic;
using Newtonsoft.Json;

namespace SmallQyest.World
{
    /// <summary>
    /// Json Converter for a Level.
    /// </summary>
    internal class LevelConverter : BaseConverter<Level>
    {
        /// <summary>
        /// Writes Object into Json.
        /// </summary>
        /// <param name="writer">Instance to write Json with.</param>
        /// <param name="serializer">Instance to serialize with.</param>
        /// <param name="value">Value to convert.</param>
        protected override void Write(JsonWriter writer, JsonSerializer serializer, Level value)
        {
            writer.WriteStartObject();
            {
                writer.WritePropertyName("Tools");
                this.WriteItemCollection(writer, serializer, value.Tools);

                writer.WritePropertyName("Map");
                this.WriteItemCollection(writer, serializer, value.Map);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Writes a Collection.
        /// </summary>
        private void WriteItemCollection(JsonWriter writer, JsonSerializer serializer, IEnumerable<Item> items)
        {
            writer.WriteStartObject();
            foreach (Item item in items)
                serializer.Serialize(writer, item);
            writer.WriteEndObject();
        }
    }
}
