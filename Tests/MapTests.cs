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
    }
}
