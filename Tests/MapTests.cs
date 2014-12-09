using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallQyest.World;
using SmallQyest.World.Actors;
using SmallQyest.World.Things;
using SmallQyest.World.Tiles;
using SmallQyest.World.Triggers;

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
            Map tested = new Map();
        }

        /// <summary>
        /// Tests adding Items to the Map.
        /// </summary>
        [TestMethod()]
        public void ItemAddingTest()
        {
            Map tested = new Map();
            Item someItem = new Item();
            Item actor = new Player() { Position = new Vector(2, 2) };
            Item thing = new ColoredKey() { Position = new Vector(2, 2) };
            Item tile = new Grass() { Position = new Vector(2, 2) };
            tested.Add(actor);
            tested.Add(thing);
            tested.Add(tile);
            Assert.AreEqual(3, tested.Count);
            Assert.IsFalse(tested.Contains(someItem));
            Assert.IsTrue(tested.Contains(actor));
            Assert.IsTrue(tested.Contains(thing));
            Assert.IsTrue(tested.Contains(tile));
            Assert.IsTrue(tested.Actors.First() is Player);
            Assert.IsTrue(tested.Things.First() is ColoredKey);
            Assert.IsTrue(tested.Tiles.First() is Grass);
        }

        /// <summary>
        /// Tests getting Items from the Map.
        /// </summary>
        [TestMethod()]
        public void GetItemsTest1()
        {
            Map tested = new Map();
            tested.Add(new PlayerSpawnTrigger() { Position = new Vector(1, 1) });
            tested.Add(new LevelEndTrigger() { Position = new Vector(1, 2) });
            Item[] result = tested.GetItems(new Vector(1, 2)).ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.First() is LevelEndTrigger);
        }

        /// <summary>
        /// Tests getting Items from the Map.
        /// </summary>
        [TestMethod()]
        public void GetItemsTest2()
        {
            Map tested = new Map();
            tested.Add(new PlayerSpawnTrigger() { Position = new Vector(1, 1) });
            tested.Add(new LevelEndTrigger() { Position = new Vector(1, 2) });

            PlayerSpawnTrigger[] empty = tested.GetItems<PlayerSpawnTrigger>(new Vector(1, 2)).ToArray();
            PlayerSpawnTrigger[] result = tested.GetItems<PlayerSpawnTrigger>(new Vector(1, 1)).ToArray();
            Assert.AreEqual(0, empty.Length);
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.First() is PlayerSpawnTrigger);
        }

        /// <summary>
        /// Tests getting Items from the Map.
        /// </summary>
        [TestMethod()]
        public void GetItemsTest3()
        {
            Map tested = new Map();
            tested.Add(new PlayerSpawnTrigger() { Position = new Vector(1, 1) });
            tested.Add(new LevelEndTrigger() { Position = new Vector(1, 2) });

            PlayerSpawnTrigger[] result = tested.GetItems<PlayerSpawnTrigger>().ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.First() is PlayerSpawnTrigger);
        }

        /// <summary>
        /// Tests computing Map Width.
        /// </summary>
        [TestMethod()]
        public void GetWidthTest()
        {
            Map tested = new Map();
            Assert.AreEqual(0, tested.GetWidth());
            tested.Add(new Item() { Position = new Vector(9, 9) });
            Assert.AreEqual(10, tested.GetWidth());
        }

        /// <summary>
        /// Tests computing Map Height.
        /// </summary>
        [TestMethod()]
        public void GetHeightTest()
        {
            Map tested = new Map();
            Assert.AreEqual(0, tested.GetHeight());
            tested.Add(new Item() { Position = new Vector(9, 9) });
            Assert.AreEqual(10, tested.GetHeight());
        }

        /// <summary>
        /// Tests computing Visibility of a Point from another Point.
        /// </summary>
        [TestMethod()]
        public void CanSeeTest()
        {
            Map tested = new Map();

            // Crossroad:
            tested.Add(new Path() { Position = new Vector(2, 2) });
            // Two short Roads:
            tested.Add(new Path() { Position = new Vector(1, 2) });
            tested.Add(new Path() { Position = new Vector(3, 2) });
            tested.Add(new Path() { Position = new Vector(2, 1) });
            tested.Add(new Path() { Position = new Vector(2, 3) });

            Assert.IsFalse(tested.CanSee(new Vector(1, 2), new Vector(2, 3)));
            Assert.IsTrue(tested.CanSee(new Vector(1, 2), new Vector(3, 2)));

            Assert.IsFalse(tested.CanSee(new Vector(2, 1), new Vector(3, 2)));
            Assert.IsTrue(tested.CanSee(new Vector(2, 1), new Vector(2, 3)));

            // Adding an Obstacle:
            tested.Add(new MoveableObstacle() { Position = new Vector(2, 2) });
            Assert.IsFalse(tested.CanSee(new Vector(1, 2), new Vector(3, 2)));
            Assert.IsFalse(tested.CanSee(new Vector(2, 1), new Vector(2, 3)));
        }

    }
}
