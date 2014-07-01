using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.Core
{
    /// <summary>
    /// Contains a Level Map.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="width">Width of the Map.</param>
        /// <param name="height">Height of the Map.</param>
        public Map(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");
            this.width = width;
            this.height = height;
            this.items = new ICollection<IItem>[this.width, this.height];
            for (int x = 0; x < this.width; ++x)
            {
                for (int y = 0; y < this.height; ++y)
                {
                    this.items[x, y] = new List<IItem>();
                }
            }
        }

        /// <summary>
        /// Retrieves the X-Coordinate of the specified Item.
        /// </summary>
        /// <param name="item">Item to retrieve X-Coordinate for.</param>
        /// <returns>X-Coordinate of the Item, -1 if the Item was not found on the Map.</returns>
        public int GetX(IItem item)
        {
            var itemCoordinates = this.GetItemsWithCoordinates()
                .Where(arg => arg.Item == item)
                .FirstOrDefault();
            return itemCoordinates != null ? itemCoordinates.X : -1;
        }

        /// <summary>
        /// Retrieves the Y-Coordinate of the specified Item.
        /// </summary>
        /// <param name="item">Item to retrieve Y-Coordinate for.</param>
        /// <returns>Y-Coordinate of the Item, -1 if the Item was not found on the Map.</returns>
        public int GetY(IItem item)
        {
            var itemCoordinates = this.GetItemsWithCoordinates()
                .Where(arg => arg.Item == item)
                .FirstOrDefault();
            return itemCoordinates != null ? itemCoordinates.Y : -1;
        }

        /// <summary>
        /// Retrieves all the Items on the Map with their Coordinates.
        /// </summary>
        /// <returns>All Items and their Coordinates.</returns>
        private IEnumerable<dynamic> GetItemsWithCoordinates()
        {
            var itemsWithCoordinates = Enumerable.Range(0, this.width)
                .SelectMany(x => Enumerable.Range(0, this.height)
                    .SelectMany(y => this.items[x, y]
                        .Select(item => new { X = x, Y = y, Item = item })));
            return itemsWithCoordinates;
        }

        #region Properties

        /// <summary>
        /// Retrieves the Items on the specified Coordinates.
        /// </summary>
        /// <param name="x">X-Coordinate of the Items.</param>
        /// <param name="y">Y-Coordinate of the Items.</param>
        /// <returns></returns>
        public IEnumerable<IItem> this[int x, int y]
        {
            get { return this.items[x, y]; }
            set { this.items[x, y] = new List<IItem>(value); }
        }

        /// <summary>
        /// Retrieves the Width of the Map.
        /// </summary>
        public int Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Retrieves the Height of the Map.
        /// </summary>
        public int Height
        {
            get { return this.height; }
        }

        #endregion

        #region Fields
        private readonly int width = 0;
        private readonly int height = 0;
        private ICollection<IItem>[,] items = null;

        #endregion
    }
}
