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
            BasicMovementStrategy movementStrategy = new BasicMovementStrategy();
            base.BehaviorStrategy = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[]
                {
                    movementStrategy,
                    new ProfitSearchStrategy<Bonus>() 
                },
                new ActorBehaviorStrategy[]
                {
                    movementStrategy
                });
        }

        /// <summary>
        /// Kills the Player.
        /// </summary>
        public override void Kill()
        {
            base.Kill();
            base.Level.Fail();
        }

    }
}
