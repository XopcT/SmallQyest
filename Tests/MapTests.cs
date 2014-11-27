using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.Core;
using SmallQyest.World;

namespace Tests
{
    /// <summary>
    /// Contains Tests for the Map.
    /// </summary>
    [TestClass()]
    public class MapTests
    {
        /// <summary>
        /// Tests the Map Constructor.
        /// </summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            ILevel level = new GameLevel();
            GameMap map = new GameMap(level, 2, 2);
        }

        /// <summary>
        /// Tests how the Map Constructor validates the Arguments.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorValidationTest1()
        {
            ILevel level = new GameLevel();
            GameMap map = new GameMap(level, 0, 2);
        }

        /// <summary>
        /// Tests how the Map Constructor validates the Arguments.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorValidationTest2()
        {
            ILevel level = new GameLevel();
            GameMap map = new GameMap(level, 2, 0);
        }
    }
}
