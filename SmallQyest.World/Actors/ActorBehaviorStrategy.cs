
namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for Actor Behavior Strategy.
    /// </summary>
    public class ActorBehaviorStrategy
    {
        /// <summary>
        /// Selects a Direction for a Actor.
        /// </summary>
        /// <param name="character">Actor to navigate.</param>
        public virtual void Navigate(Actor character)
        {
        }

        /// <summary>
        /// Moves a Actor over the Map.
        /// </summary>
        /// <param name="character">Actor to move.</param>
        public virtual void Move(Actor character)
        {
        }
    }
}
