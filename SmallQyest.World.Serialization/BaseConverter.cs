using System;
using System.Reflection;
using Newtonsoft.Json;

namespace SmallQyest.World
{
    /// <summary>
    /// Base Class to convert World Items into json.
    /// </summary>
    /// <typeparam name="T">Type of converted Item.</typeparam>
    internal abstract class BaseConverter<T> : JsonConverter
        where T : class
    {
        /// <summary>
        /// Retrieves whether specified Object Type can be converted.
        /// </summary>
        /// <param name="objectType">Type of the Object.</param>
        /// <returns>True if Object can be converted, False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            TypeInfo supportedTypeInfo = typeof(T).GetTypeInfo();
            TypeInfo objectTypeInfo = objectType.GetTypeInfo();
            return supportedTypeInfo.IsAssignableFrom(objectTypeInfo);
        }

        /// <summary>
        /// Converts specified Object into json.
        /// </summary>
        /// <param name="writer">Instance to write json with.</param>
        /// <param name="value">Value to convert.</param>
        /// <param name="serializer">Instance to serialize with.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            T t = value as T;
            if (value == null)
                throw new InvalidOperationException();
            this.Write(writer, serializer, t);
        }

        /// <summary>
        /// Writes Object into json.
        /// </summary>
        /// <param name="writer">Instance to write json with.</param>
        /// <param name="serializer">Instance to serialize with.</param>
        /// <param name="value">Value to convert.</param>
        protected virtual void Write(JsonWriter writer, JsonSerializer serializer, T value)
        {
            // Doing nothing.
        }

        /// <summary>
        /// Converts specified json into an Object.
        /// </summary>
        /// <param name="reader">Instance to read json with.</param>
        /// <param name="objectType">Type of the Object to read.</param>
        /// <param name="existingValue">Existing Object.</param>
        /// <param name="serializer">Instance to deserialize with.</param>
        /// <returns>Converted Instance.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
