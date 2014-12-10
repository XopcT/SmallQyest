using SmallQyest.World.Actors.BehaviorStrategies;
using SmallQyest.World.Things;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Character controller by the Player.
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Initializes a new Instance of current Class.s
        /// </summary>
        public Player()
        {
            base.BehaviorStrategy = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[] { new BasicPathfindingStrategy(), new ProfitSearchStrategy<Bonus>() },
                new ActorBehaviorStrategy[] { new MoveAheadStrategy() });
        }

        /// <summary>
        /// Destroys the Player.
        /// </summary>
        public override void Destroy()
        {
            base.Destroy();
            base.Level.Fail();
        }

    }
}
