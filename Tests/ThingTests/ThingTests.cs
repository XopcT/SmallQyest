using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.World;
using SmallQyest.World.Actors;
using SmallQyest.World.Things;
using SmallQyest.World.Tiles;
using SmallQyest.World.Triggers;

namespace Tests.ThingTests
{
    /// <summary>
    /// Contains Tests for different Things.
    /// </summary>
    [TestClass()]
    public class ThingTests
    {
        /// <summary>
        /// Tests the LevelEndTrigger.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void LevelEndTriggerVisitTest()
        {
            bool levelPassed = false;
            this.level.Setup(arg => arg.Pass(It.IsAny<int>())).Callback(() => { levelPassed = true; });

            Item player = new Player() { Level = this.level.Object };
            LevelEndTrigger tested = new LevelEndTrigger() { Level = this.level.Object };

            tested.OnVisit(player);
            Assert.IsTrue(levelPassed);
        }

        /// <summary>
        /// Tests the FallTrap.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void FallTrapTest()
        {
            bool playerKilled = false;
            Mock<Player> player = new Mock<Player>();
            player.Setup(arg => arg.Kill()).Callback(() => { playerKilled = true; });

            FallTrap tested = new FallTrap() { Level = this.level.Object };
            tested.OnVisit(player.Object);

            Assert.IsTrue(playerKilled);
        }

        /// <summary>
        /// Tests the OneTimePassObstacle.Initialize Method.
        /// </summary>
        [TestMethod()]
        public void OneTimePassObstacleInitializeTest()
        {
            OneTimePassObstacle tested = new OneTimePassObstacle() { Level = this.level.Object };
            tested.Initialize();
            Assert.IsTrue(tested.IsOpen);
        }

        /// <summary>
        /// Tests OneTimePassObstacle.OnLeave Method.
        /// </summary>
        [TestMethod()]
        public void OneTimePassObstacleLeaveTest()
        {
            Item player = new Player() { Level = this.level.Object };
            OneTimePassObstacle tested = new OneTimePassObstacle() { Level = this.level.Object };
            tested.Initialize();
            tested.OnLeave(player);
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Tests the DoorWithAKey.Initialize Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyInitializeTest()
        {
            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object };
            tested.Initialize();
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Tests the DoorWithAKey.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyCanPassTest1()
        {
            Player player = new Player() { Level = this.level.Object };
            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object, Color = KeyColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsFalse(canPass);
        }

        /// <summary>
        /// Tests the DoorWithAKey.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyCanPassTest2()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory = new List<Item>() { new Key() { Color = KeyColor.Blue } };

            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object, Color = KeyColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsFalse(canPass);
        }

        /// <summary>
        /// Tests the DoorWithAKey.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyCanPassTest3()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory = new List<Item>() { new Key() { Color = KeyColor.Red } };

            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object, Color = KeyColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsTrue(canPass);
        }

        /// <summary>
        /// Tests the DoorWithAKey.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyVisitTest1()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory = new List<Item>() { new Key() { Color = KeyColor.Blue } };

            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object, Color = KeyColor.Red };
            tested.Initialize();
            tested.OnVisit(player);
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Tests the DoorWithAKey.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void DoorWithAKeyVisitTest2()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory = new List<Item>() { new Key() { Color = KeyColor.Red } };

            DoorWithAKey tested = new DoorWithAKey() { Level = this.level.Object, Color = KeyColor.Red };
            tested.Initialize();
            tested.OnVisit(player);
            Assert.IsTrue(tested.IsOpen);
        }

        /// <summary>
        /// Tests the MoveableObstacle.CanPassThrough Method.
        /// Checks moving in positive Direction.
        /// </summary>
        [TestMethod()]
        public void MoveableObstacleCanPassTest1()
        {
            this.map.Add(new Path() { Position = new Vector(0, 0) });
            this.map.Add(new Path() { Position = new Vector(1, 0) });
            this.map.Add(new Path() { Position = new Vector(2, 0) });

            Player player = new Player() { Position = new Vector(0, 0), Direction = Vector.Up, Level = this.level.Object };

            MoveableObstacle tested = new MoveableObstacle() { Position = new Vector(1, 0), Level = this.level.Object };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsTrue(canPass);
        }

        /// <summary>
        /// Tests the MoveableObstacle.CanPassThrough Method.
        /// Checks moving in negative Direction.
        /// </summary>
        [TestMethod()]
        public void MoveableObstacleCanPassTest2()
        {
            this.map.Add(new Path() { Position = new Vector(0, 0) });
            this.map.Add(new Path() { Position = new Vector(1, 0) });
            this.map.Add(new Path() { Position = new Vector(2, 0) });

            Player player = new Player() { Position = new Vector(2, 0), Direction = Vector.Up, Level = this.level.Object };

            MoveableObstacle tested = new MoveableObstacle() { Position = new Vector(1, 0), Level = this.level.Object };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsTrue(canPass);
        }

        /// <summary>
        /// Tests the MoveableObstacle.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void MoveableObstacleCanPassTest3()
        {
            this.map.Add(new Path() { Position = new Vector(0, 0) });
            this.map.Add(new Path() { Position = new Vector(1, 0) });

            Player player = new Player() { Position = new Vector(0, 0), Direction = Vector.Up, Level = this.level.Object };

            MoveableObstacle tested = new MoveableObstacle() { Position = new Vector(1, 0), Level = this.level.Object };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsFalse(canPass);
        }

        /// <summary>
        /// Tests the Bonus.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void BonusVisitTest()
        {
            Bonus tested = new Bonus() { Position = new Vector(0, 0), Level = this.level.Object };
            Player player = new Player() { Position = new Vector(0, 0), Level = this.level.Object };

            this.map.Add(tested);
            this.map.Add(player);

            // Ensuring the Bonus is on the Map:
            Assert.IsTrue(this.map.Contains(tested));

            tested.OnVisit(player);
            // Checking if Bonus was moved into the Player's Inventory:
            Assert.IsFalse(this.map.Contains(tested));
            Assert.IsTrue(player.Inventory.Contains(tested));
        }

        /// <summary>
        /// Initializes Tests Environment.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            this.map = new Map();

            this.level = new Mock<ILevel>();
            this.level.Setup(arg => arg.Map).Returns(this.map);
        }

        #region Properties

        #endregion

        #region Fields

        private Mock<ILevel> level = null;
        private Map map = null;

        #endregion
    }
}
