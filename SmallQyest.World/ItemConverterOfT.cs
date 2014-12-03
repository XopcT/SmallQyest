using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace SmallQyest.World
{
    /// <summary>
    /// Json Converter for Items of specified Type.
    /// </summary>
    /// <typeparam name="T">Type of Items to convert.</typeparam>
    internal class ItemConverter<T> : BaseConverter<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="serializedProperties"></param>
        public ItemConverter(string itemName, params Expression<Func<T, object>>[] serializedProperties)
        {
            this.ItemName = itemName;
            this.serializedProperties = serializedProperties;
        }

        /// <summary>
        /// Writes Object into Json.
        /// </summary>
        /// <param name="writer">Instance to write Json with.</param>
        /// <param name="serializer">Instance to serialize with.</param>
        /// <param name="value">Value to convert.</param>
        protected override void Write(JsonWriter writer, JsonSerializer serializer, T value)
        {
            writer.WritePropertyName(this.ItemName);
            writer.Formatting = Formatting.None;
            writer.WriteStartObject();
            foreach (Expression<Func<T, object>> propertyDescriptor in this.serializedProperties)
            {
                PropertyInfo property = this.GetProperty(propertyDescriptor);
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, this.GetValue(value, property));
            }
            writer.WriteEndObject();
            writer.Formatting = Formatting.Indented;
            base.Write(writer, serializer, value);
        }

        /// <summary>
        /// Retrieves a Value of a Property.
        /// </summary>
        /// <param name="model">Object to get Property Value from.</param>
        /// <param name="property">Property who's Value is retrieved.</param>
        /// <returns>Property Value.</returns>
        private object GetValue(T model, PropertyInfo property)
        {
            return property.GetValue(model);
        }

        /// <summary>
        /// Sets a Value of a Property.
        /// </summary>
        /// <param name="model">Object to set Property Value to.</param>
        /// <param name="property">Property who's Value is set.</param>
        /// <param name="value">Property Value.</param>
        private void SetValue(T model, PropertyInfo property, object value)
        {
            property.SetValue(model, value);
        }

        /// <summary>
        /// Retrieves a Property from Expression.
        /// </summary>
        /// <param name="expression">Expression to get a Property from.</param>
        /// <returns>Property Information.</returns>
        private PropertyInfo GetProperty(Expression<Func<T, object>> expression)
        {
            // Checking if Expression is a Member:
            MemberExpression member = expression as MemberExpression;
            if (member != null)
            {
                return member.Member as PropertyInfo;
            }
            else
            {
                // Checking if Expression is an Lambda Conversion:
                LambdaExpression lambda = expression as LambdaExpression;
                if (lambda != null)
                {
                    UnaryExpression unary = lambda.Body as UnaryExpression;
                    if (unary != null &&
                        (unary.NodeType == ExpressionType.Convert || unary.NodeType == ExpressionType.ConvertChecked))
                    {
                        // Taking Member from Unary Expression:
                        return (unary.Operand as MemberExpression).Member as PropertyInfo;
                    }
                }
            }
            throw new ArgumentException("expression");
        }

        #region Properties

        /// <summary>
        /// Retrieves a Name of a converted Item.
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Type of a converted Item.
        /// </summary>
        public Type ItemType { get { return typeof(T); } }

        #endregion

        #region Fields
        private readonly IEnumerable<Expression<Func<T, object>>> serializedProperties = null;

        #endregion
    }
}
