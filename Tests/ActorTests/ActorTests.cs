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
        public void BasicPathfindingStrategyTest()
        {
            // Here is the Map:
            // . . *
            // . * *
            // . * . 
            this.map.Add(new Path() { Position = new Vector(1, 2), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(1, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 1), Level = this.level.Object });
            this.map.Add(new Path() { Position = new Vector(2, 0), Level = this.level.Object });

            // This is how the Player is expected to move over the Map:
            Vector[] rout = new Vector[] { new Vector(1, 1), new Vector(2, 1), new Vector(2, 0), new Vector(2, 1) };
            Vector[] directions = new Vector[] { Vector.Up, Vector.Right, Vector.Up, Vector.Down };

            // Testing the Movement Strategy:
            Player player = new Player() { Position = new Vector(1, 2), Direction = Vector.Up, Level = this.level.Object };
            this.map.Add(player);

            BasicPathfindingStrategy tested = new BasicPathfindingStrategy();
            for (int i = 0; i < rout.Length; ++i)
            {
                tested.Navigate(player);
                Assert.AreEqual(directions[i], player.Direction);
                player.Position = rout[i];
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
        /// Tests the Complex Behavior Strategy.
        /// </summary>
        [TestMethod()]
        public void ComplexBehaviorStrategyTest()
        {
            bool[] navigateCalled = new bool[3] { false, false, false, };
            bool[] moveCalled = new bool[3] { false, false, false, };
            Mock<ActorBehaviorStrategy>[] behaviorStrategies = new Mock<ActorBehaviorStrategy>[3]
            {
                new Mock<ActorBehaviorStrategy>(),
                new Mock<ActorBehaviorStrategy>(),
                new Mock<ActorBehaviorStrategy>(),
            };
            for (int i = 0; i < behaviorStrategies.Length; ++i)
            {
                int index = i;
                behaviorStrategies[i].Setup(arg => arg.Navigate(It.IsAny<Actor>())).Callback(() => { navigateCalled[index] = true; });
                behaviorStrategies[i].Setup(arg => arg.Move(It.IsAny<Actor>())).Callback(() => { moveCalled[index] = true; });
            }
            ComplexBehaviorStrategy tested = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[] { behaviorStrategies[0].Object, behaviorStrategies[1].Object },
                new ActorBehaviorStrategy[] { behaviorStrategies[1].Object, behaviorStrategies[2].Object });
            Player player = new Player() { Position = Vector.Zero, Direction = Vector.Up };
            tested.Navigate(player);
            tested.Move(player);
            Assert.IsTrue(navigateCalled[0]);
            Assert.IsTrue(navigateCalled[1]);
            Assert.IsFalse(navigateCalled[2]);
            Assert.IsFalse(moveCalled[0]);
            Assert.IsTrue(moveCalled[1]);
            Assert.IsTrue(moveCalled[2]);
        }

        /// <summary>
        /// Tests the Bullet.Update Method.
        /// </summary>
        [TestMethod()]
        public void BulletUpdateTest()
        {
            Bullet tested = new Bullet() { Position = new Vector(1, 1), Level = this.level.Object };
            tested.Initialize();

            MoveableObstacle obstacle = new MoveableObstacle() { Position = new Vector(1, 1), Level = this.level.Object };
            this.map.Add(tested);
            this.map.Add(obstacle);
            this.map.Update();
            Assert.IsTrue(tested.IsDestroyed);
        }

        /// <summary>
        /// Tests the Bullet.OnVisit Method.
        /// </summary>
        [TestMethod()]
        public void BulletVisitTest()
        {
            Player player = new Player() { Level = this.level.Object };
            Bullet tested = new Bullet() { Level = this.level.Object };
            player.Initialize();
            tested.Initialize();

            tested.OnVisit(player);
            Assert.IsTrue(player.IsDestroyed);
            Assert.IsTrue(tested.IsDestroyed);
        }

        /// <summary>
        /// Tests destroying the Player.
        /// </summary>
        [TestMethod()]
        public void PlayerDestroyTest()
        {
            bool levelFailed = false;
            this.level.Setup(arg => arg.Fail()).Callback(() => { levelFailed = true; });

            Player player = new Player() { Level = this.level.Object };
            player.Destroy();

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
