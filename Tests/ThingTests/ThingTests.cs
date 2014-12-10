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
            bool playerDestroyed = false;
            Mock<Player> player = new Mock<Player>();
            player.Setup(arg => arg.Destroy()).Callback(() => { playerDestroyed = true; });

            FallTrap tested = new FallTrap() { Level = this.level.Object };
            tested.OnVisit(player.Object);

            Assert.IsTrue(playerDestroyed);
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
        /// Tests the ColoredDoor.Initialize Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorInitializeTest()
        {
            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object };
            tested.Initialize();
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Tests the ColoredDoor.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorCanPassTest1()
        {
            Player player = new Player() { Level = this.level.Object };
            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object, Color = ItemColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsFalse(canPass);
        }

        /// <summary>
        /// Tests the ColoredDoor.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorCanPassTest2()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory.Add(new ColoredKey() { Color = ItemColor.Blue });

            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object, Color = ItemColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsFalse(canPass);
        }

        /// <summary>
        /// Tests the ColoredDoor.CanPassThrough Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorCanPassTest3()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory.Add(new ColoredKey() { Color = ItemColor.Red });

            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object, Color = ItemColor.Red };
            tested.Initialize();
            bool canPass = tested.CanPassThrough(player);
            Assert.IsTrue(canPass);
        }

        /// <summary>
        /// Tests the ColoredDoor.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorVisitTest1()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory.Add(new ColoredKey() { Color = ItemColor.Blue });

            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object, Color = ItemColor.Red };
            tested.Initialize();
            tested.OnVisit(player);
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Tests the ColoredDoor.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void ColoredDoorVisitTest2()
        {
            Player player = new Player() { Level = this.level.Object };
            player.Inventory.Add(new ColoredKey() { Color = ItemColor.Red });

            ColoredDoor tested = new ColoredDoor() { Level = this.level.Object, Color = ItemColor.Red };
            tested.Initialize();
            tested.OnVisit(player);
            Assert.IsTrue(tested.IsOpen);
        }

        /// <summary>
        /// Tests the ColoredKey.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void ColoredKeyVisitTest()
        {
            ColoredKey tested = new ColoredKey() { Position = new Vector(0, 0), Level = this.level.Object };
            Player player = new Player() { Position = new Vector(0, 0), Level = this.level.Object };

            this.map.Add(tested);
            this.map.Add(player);

            // Ensuring the Key is on the Map:
            Assert.IsTrue(this.map.Contains(tested));
            tested.OnVisit(player);
            // Checking if Key was moved into the Player's Inventory:
            Assert.IsFalse(this.map.Contains(tested));
            Assert.IsTrue(player.Inventory.Contains(tested));
        }

        /// <summary>
        /// Tests the ColoredLever.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void ColoredLeverVisitTest()
        {
            ColoredLever tested = new ColoredLever() { Position = new Vector(0, 0), Color = ItemColor.Red, Level = this.level.Object };
            Player player = new Player() { Position = new Vector(0, 1), Level = this.level.Object };
            ColoredDoor door = new ColoredDoor() { Position = new Vector(0, 2), Level = this.level.Object };
            door.Initialize();

            this.map.Add(tested);
            this.map.Add(player);
            this.map.Add(door);
            // Ensuring the Door is closed before the Test:
            Assert.IsFalse(door.IsOpen);

            // Checking if the Lever opens the Door:
            tested.OnVisit(player);
            Assert.IsTrue(door.IsOpen);
            // Checking if the Lever closes the Door back:
            tested.OnVisit(player);
            Assert.IsFalse(door.IsOpen);
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
