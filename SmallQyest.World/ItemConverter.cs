using System.Reflection;
using Newtonsoft.Json;

namespace SmallQyest.World
{
    /// <summary>
    /// Json Converter for an Item.
    /// </summary>
    internal class ItemConverter : BaseConverter<Item>
    {
        /// <summary>
        /// Writes Object into json.
        /// </summary>
        /// <param name="writer">Instance to write json with.</param>
        /// <param name="serializer">Instance to serialize with.</param>
        /// <param name="value">Value to convert.</param>
        protected override void Write(JsonWriter writer, JsonSerializer serializer, Item value)
        {
            writer.WritePropertyName(value.GetType().GetTypeInfo().Name);
            writer.WriteStartObject();
            {
                writer.WritePropertyName("X"); writer.WriteValue(value.Position.X);
                writer.WritePropertyName("Y"); writer.WriteValue(value.Position.Y);
            }
            writer.WriteEndObject();
        }
    }
}
