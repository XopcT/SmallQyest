using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmallQyest.World;
using SmallQyest.World.Actors;
using SmallQyest.World.Actors.BehaviorStrategies;
using SmallQyest.World.Things;
using SmallQyest.World.Tiles;

namespace Tests.ActorTests
{
    /// <summary>
    /// Contains Tests for Characters.
    /// </summary>
    [TestClass()]
    public class ActorTests
    {
        /// <summary>
        /// Tests the basic Strategy to move over the Map.
        /// </summary>
        [TestMethod()]
        public void BasicMovementStrategyTest()
        {
            // Here is the Map:
            // . . *
            // * * *
            // . * . 
            this.map.Add(new Path() { Position = new Vector(1, 2), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(1, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(0, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 0), Level = this.level.Object });

            // This is how the Player is expected to move over the Map:
            Vector[] rout = new Vector[] { new Vector(1, 1), new Vector(2, 1), new Vector(2, 0), new Vector(2, 1) };
            Vector[] directions = new Vector[] { Vector.Up, Vector.Right, Vector.Up, Vector.Down };

            // Testing the Movement Strategy:
            Player player = new Player() { Position = new Vector(1, 2), Direction = Vector.Up, Level = this.level.Object };
            this.map.Add(player);

            BasicMovementStrategy tested = new BasicMovementStrategy();
            for (int i = 0; i < rout.Length; ++i)
            {
                tested.Navigate(player); tested.Move(player);
                Assert.AreEqual(rout[i], player.Position);
                Assert.AreEqual(directions[i], player.Direction);
            }
        }

        /// <summary>
        /// Tests Strategy to look for something interesting.
        /// </summary>
        [TestMethod()]
        public void ProfitSearchStrategyTest()
        {
            // Here is the Map:
            // x * * x
            // . * x .
            // * * . .
            this.map.Add(new Path() { Position = new Vector(0, 2), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(1, 2), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(1, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(1, 0), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(0, 0), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 0), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(3, 0), Level = this.level.Object });
            // And a Grass between the Player and a Treasure which will be visible but can not be reached:
            this.map.Add(new Grass() { Position = new Vector(0, 1), Level = this.level.Object });
            // Putting some Trasures:
            this.map.Add(new Bonus() { Position = new Vector(0, 0), Level = this.level.Object });
            this.map.Add(new Bonus() { Position = new Vector(2, 1), Level = this.level.Object });
            this.map.Add(new Bonus() { Position = new Vector(3, 0), Level = this.level.Object });

            Player player = new Player() { Position = new Vector(0, 2), Direction = Vector.Right, Level = this.level.Object };
            this.map.Add(player);

            ProfitSearchStrategy<Bonus> tested = new ProfitSearchStrategy<Bonus>();

            // Player should not turn to the Items he can not reach:
            tested.Navigate(player);
            Assert.AreEqual(Vector.Right, player.Direction);

            // Player should turn to the Items he can reach:
            player.Position = new Vector(1, 1);
            player.Direction = Vector.Up;
            tested.Navigate(player);
            Assert.AreEqual(Vector.Right, player.Direction);

            // When a Player sees several Treasures, he chooses the closest one:
            player.Position = new Vector(1, 0);
            player.Direction = Vector.Up;
            tested.Navigate(player);
            Assert.AreEqual(Vector.Left, player.Direction);

            // When there are several Treasures, he chosses the one he is already looking at:
            player.Position = new Vector(2, 0);
            player.Direction = Vector.Right;
            tested.Navigate(player);
            Assert.AreEqual(Vector.Right, player.Direction);
        }

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
