using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            JsonConverter converter = null;
            if (this.typeToConverter.TryGetValue(value.GetType(), out converter))
            {
                converter.WriteJson(writer, value, serializer);
            }
        }

        /// <summary>
        /// Registers a Converter within this Instance.
        /// </summary>
        /// <typeparam name="T">Type of Item supported by Converter.</typeparam>
        /// <param name="itemName">Name of the Item.</param>
        /// <param name="constructor">Function wich instantiates Items.</param>
        /// <param name="serializedProperties">Properties to be serialized.</param>
        public void Register<T>(string itemName, Func<T> constructor, params Expression<Func<T, object>>[] serializedProperties)
            where T : Item
        {
            JsonConverter converter = new ItemConverter<T>(itemName, serializedProperties);
            this.typeToConverter.Add(typeof(T), converter);
            this.itemNameToConverter.Add(itemName, converter);
            this.itemNameToConstructor.Add(itemName, constructor);
        }

        #region Properties

        #endregion

        #region Fields
        private IDictionary<Type, JsonConverter> typeToConverter = new Dictionary<Type, JsonConverter>();
        private IDictionary<string, JsonConverter> itemNameToConverter = new Dictionary<string, JsonConverter>();
        private IDictionary<string, Func<Item>> itemNameToConstructor = new Dictionary<string, Func<Item>>();

        #endregion
    }
}
