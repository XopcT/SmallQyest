using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.Core;

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
            Map map = new Map(2, 2);
        }

        /// <summary>
        /// Tests how the Map Constructor validates the Arguments.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorValidationTest1()
        {
            Map map = new Map(0, 2);
        }

        /// <summary>
        /// Tests how the Map Constructor validates the Arguments.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorValidationTest2()
        {
            Map map = new Map(2, 0);
        }

        /// <summary>
        /// Tests how the Map retrieves the X-Coordinate of an Item.
        /// </summary>
        [TestMethod()]
        public void GetXCoordinateTest()
        {
            Map map = new Map(3, 3);
            Mock<IItem> item = new Mock<IItem>();
            Assert.AreEqual(-1, map.GetX(item.Object));
            map[2, 2] = new IItem[] { item.Object };
            Assert.AreEqual(2, map.GetX(item.Object));
        }

        /// <summary>
        /// Tests how the Map retrieves the Y-Coordinate of an Item.
        /// </summary>
        [TestMethod()]
        public void GetYCoordinateTest()
        {
            Map map = new Map(3, 3);
            Mock<IItem> item = new Mock<IItem>();
            Assert.AreEqual(-1, map.GetY(item.Object));
            map[2, 2] = new IItem[] { item.Object };
            Assert.AreEqual(2, map.GetY(item.Object));
        }
    }
}
