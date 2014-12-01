using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.World;
using SmallQyest.World.Actors;

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

            Player player = new Player() { Level = this.level.Object };
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
            this.level.Setup(arg => arg.Map).Returns(this.map);
        }

        #region Properties

        #endregion

        #region Fields
        private Map map = new Map();
        private Mock<ILevel> level = null;

        #endregion
    }
}
