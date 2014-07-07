using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallQyest.Core;
using SmallQyest.World.Tiles;
using SmallQyest.World;

namespace SmallQyest
{
    /// <summary>
    /// Level Factory for Test Purposes.
    /// </summary>
    public class MockLevelProvider : ILevelProvider
    {
        /// <summary>
        /// Loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public ILevel LoadLevel(int levelId)
        {
            int[,] levelMap = new int[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, },
                { 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, },
                { 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, },
                { 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, },
                { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, },
                { 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, },
                { 1, 3, 1, 1, 0, 0, 0, 0, 1, 0, },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            };

            ILevel level = new Level();
            level.Map = this.CreateMap(level, levelMap);
            level.Map.Add(this.ItemFactory.GetPlayer());

            return level;
        }

        /// <summary>
        /// Asynchronously loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public Task<ILevel> LoadLevelAsync(int levelId)
        {
            throw new NotImplementedException();
        }

        private IMap CreateMap(ILevel level, int[,] numericMap)
        {
            int width = numericMap.GetLength(1);
            int height = numericMap.GetLength(0);

            IMap map = new Map(level, width, height);
            IEnumerable<IItem> items = Enumerable.Range(0, width)
                .SelectMany(x => Enumerable.Range(0, height)
                    .SelectMany(y => this.CreateItems(numericMap[y, x], x, y)));
            foreach (IItem item in items)
                map.Add(item);
            return map;
        }

        private IEnumerable<IItem> CreateItems(int value, int x, int y)
        {
            if ((value & 1) == 1)
            {
                IItem item = this.ItemFactory.GetPath();
                item.X = x;
                item.Y = y;
                yield return item;
            }
            else
            {
                IItem item = this.ItemFactory.GetGrass();
                item.X = x;
                item.Y = y;
                yield return item;
            }
            if ((value & 2) == 2)
            {
                IItem item = this.ItemFactory.GetLevelStartTrigger();
                item.X = x;
                item.Y = y;
                yield return item;
            }
            if ((value & 4) == 4)
            {
                IItem item = this.ItemFactory.GetLevelEndTrigger();
                item.X = x;
                item.Y = y;
                yield return item;
            }
        }

        /// <summary>
        /// Converts Value from a numeric Map Source into an Item.
        /// </summary>
        /// <param name="value">Value to convert.</param>
        /// <param name="x">X-Coordinate of an Item.</param>
        /// <param name="y">Y-Coordinate of an Item.</param>
        /// <returns>Created Item Instance.</returns>
        private IItem ValueToItem(int value, int x, int y)
        {
            if (value == 0)
                return new Grass() { X = x, Y = y, };
            else if (value == 1)
                return new Path() { X = x, Y = y };
            throw new ArgumentException();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Factory which creates World Items.
        /// </summary>
        public IItemFactory ItemFactory { get; set; }

        #endregion
    }
}
