using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallQyest.World;
using SmallQyest.World.Actors;
using SmallQyest.World.Tiles;

namespace Tests
{
    /// <summary>
    /// Contains Tests for Tiles.
    /// </summary>
    [TestClass()]
    public class TilesTests
    {
        /// <summary>
        /// Tests the Grass' Constructor.
        /// </summary>
        [TestMethod()]
        public void GrassConstructorTest()
        {
            Grass tested = new Grass();
        }

        /// <summary>
        /// Tests the Grass.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void GrassCanPassTest()
        {
            Grass tested = new Grass();
            Item player = new Player();
            Assert.IsFalse(tested.CanPassThrough(player));
        }

        /// <summary>
        /// Tests the Path's Constructor.
        /// </summary>
        public void PathConstructorTest()
        {
            Path tested = new Path();
        }

        /// <summary>
        /// Tests the Path.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void PathCanPassTest()
        {
            Path tested = new Path();
            Item player = new Player();
            Assert.IsTrue(tested.CanPassThrough(player));
        }
    }
}
