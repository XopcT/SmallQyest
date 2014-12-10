using SmallQyest.World.Actors.BehaviorStrategies;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Basic Class for the Enemy. It travels around the Map. Mostly harmless yet.
    /// </summary>
    public class Enemy : Character
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public Enemy()
        {
            base.BehaviorStrategy = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[] { new BasicPathfindingStrategy() },
                new ActorBehaviorStrategy[] { new MoveAheadStrategy() });
        }
    }
}
