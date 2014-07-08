using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.Core;
using SmallQyest.World.Characters;

namespace Tests
{
    /// <summary>
    /// Contains Tests for Characters.
    /// </summary>
    [TestClass()]
    public class CharactersTests
    {
        /// <summary>
        /// Tests killing the Player.
        /// </summary>
        [TestMethod()]
        public void PlayerKillTest()
        {
            bool levelFailed = false;
            this.level.Setup(arg => arg.Fail()).Callback(() => { levelFailed = true; });

            Player player = new Player() { X = 2, Y = 2, Map = this.map.Object };
            player.Kill();

            Assert.IsTrue(levelFailed);
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
