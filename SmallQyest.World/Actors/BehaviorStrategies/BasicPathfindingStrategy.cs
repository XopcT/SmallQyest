
namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// The most simple Behavior Strategy to move a Character over the Map.
    /// </summary>
    public class BasicPathfindingStrategy : ActorBehaviorStrategy
    {
        /// <summary>
        /// Selects a Direction for an Actor.
        /// </summary>
        /// <param name="actor">Actor to navigate.</param>
        public override void Navigate(Actor actor)
        {
            // Checking if a Character can keep moving forward:
            if (!actor.Map.CanMoveTo(actor, actor.Direction))
            {
                // Trying to turn right or left:
                Vector right = actor.Direction.GetRight();
                Vector left = actor.Direction.GetLeft();

                // Trying to turn right:
                if (actor.Map.CanMoveTo(actor, right))
                    actor.Direction = right;
                // Trying to go left:
                else if (actor.Map.CanMoveTo(actor, left))
                    actor.Direction = left;
                // Going back:
                else
                    actor.Direction = actor.Direction.GetBackward();
            }
        }

    }
}
