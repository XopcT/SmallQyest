using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            GameMap map = new GameMap();
            ILevel level = new GameLevel(map);
        }

    }
}
