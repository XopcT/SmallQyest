
namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// Base Class for Actor Behavior Strategy.
    /// </summary>
    public class ActorBehaviorStrategy
    {
        /// <summary>
        /// Selects a Direction for an Actor.
        /// </summary>
        /// <param name="actor">Actor to navigate.</param>
        public virtual void Navigate(Actor actor)
        {
            // Nothing need to be done in current Context.
        }

        /// <summary>
        /// Moves an Actor over the Map.
        /// </summary>
        /// <param name="actor">Actor to move.</param>
        public virtual void Move(Actor actor)
        {
            // Nothing needs to be done in current Context.
        }
    }
}
