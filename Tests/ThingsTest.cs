using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.Core;
using SmallQyest.World.Characters;
using SmallQyest.World.Things;
using SmallQyest.World.Triggers;

namespace Tests
{
    /// <summary>
    /// Contains Tests for different Things.
    /// </summary>
    [TestClass()]
    public class ThingsTest
    {
        /// <summary>
        /// Tests visiting the LevelEndTrigger.
        /// </summary>
        [TestMethod()]
        public void LevelEndTriggerVisitTest()
        {
            bool levelPassed = false;
            this.level.Setup(arg => arg.Pass(It.IsAny<int>())).Callback(() => { levelPassed = true; });
            IItem player = new Player() { X = 2, Y = 2, Map = this.map.Object };
            LevelEndTrigger tested = new LevelEndTrigger() { X = 2, Y = 2, Map = this.map.Object };

            tested.OnVisit(player);
            Assert.IsTrue(levelPassed);
        }

        /// <summary>
        /// Tests visiting the FallTrap.
        /// </summary>
        [TestMethod()]
        public void FallTrapTest()
        {
            bool playerKilled = false;
            Mock<Player> player = new Mock<Player>();
            player.Setup(arg => arg.Kill()).Callback(() => { playerKilled = true; });

            FallTrap tested = new FallTrap() { X = 2, Y = 2, Map = this.map.Object };
            tested.OnVisit(player.Object);

            Assert.IsTrue(playerKilled);
        }

        /// <summary>
        /// Tests initializing the OneTimePassObstacle.
        /// </summary>
        [TestMethod()]
        public void OneTimePassObstacleInitializeTest()
        {
            OneTimePassObstacle tested = new OneTimePassObstacle() { X = 2, Y = 2, Map = this.map.Object };
            tested.Initialize();
            Assert.IsTrue(tested.IsOpen);
        }

        /// <summary>
        /// Tests leaving the OneTimePassObstacle.
        /// </summary>
        [TestMethod()]
        public void OneTimePassObstacleLeaveTest()
        {
            IItem player = new Player() { X = 2, Y = 2, Map = this.map.Object };
            OneTimePassObstacle tested = new OneTimePassObstacle() { X = 2, Y = 2, Map = this.map.Object };
            tested.Initialize();
            tested.OnLeave(player);
            Assert.IsFalse(tested.IsOpen);
        }

        /// <summary>
        /// Initializes Tests Environment.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            this.level = new Mock<ILevel>();
            this.map = new Mock<IMap>();
            this.mapItems = new List<IItem>();

            this.map.Setup(arg => arg.Level).Returns(this.level.Object);
            this.map.Setup(arg => arg.Width).Returns(5);
            this.map.Setup(arg => arg.Height).Returns(5);
            this.map.Setup(arg => arg.GetEnumerator()).Returns(this.mapItems.GetEnumerator());
        }

        #region Properties

        #endregion

        #region Fields

        private Mock<ILevel> level = null;
        private Mock<IMap> map = null;
        private ICollection<IItem> mapItems = null;

        #endregion
    }
}
