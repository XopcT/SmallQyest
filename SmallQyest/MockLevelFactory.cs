using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallQyest.Core;
using SmallQyest.World;

namespace SmallQyest
{
    /// <summary>
    /// Level Factory for Test Purposes.
    /// </summary>
    public class MockLevelFactory : ILevelFactory
    {
        /// <summary>
        /// Loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public Level LoadLevel(int levelId)
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
                { 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, },
                { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            };
            int width = levelMap.GetLength(1);
            int height = levelMap.GetLength(0);

            Map map = new Map(width, height);

            IEnumerable<IItem> items = Enumerable.Range(0, width)
                .SelectMany(x => Enumerable.Range(0, height)
                    .Select(y => ValueToItem(levelMap[y, x], x, y)));
            foreach (IItem item in items)
                map.Add(item);
            return new Level() { Map = map };
        }

        /// <summary>
        /// Asynchronously loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public Task<Level> LoadLevelAsync(int levelId)
        {
            throw new NotImplementedException();
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
    }
}
