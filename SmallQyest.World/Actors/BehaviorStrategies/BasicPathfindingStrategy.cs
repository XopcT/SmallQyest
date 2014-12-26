
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
                Map map = actor.Map;
                Vector toRight = actor.Direction.GetRight();
                Vector toLeft = actor.Direction.GetLeft();

                // Trying to turn right or left:
                bool canTurnRight = map.CanMoveTo(actor, toRight);
                bool canTurnLeft = map.CanMoveTo(actor, toLeft);

                if (canTurnLeft ^ canTurnRight)
                {
                    // Trying to turn right:
                    if (canTurnRight)
                        actor.Direction = toRight;
                    // Trying to go left:
                    if (canTurnLeft)
                        actor.Direction = toLeft;
                }
                else
                    // Going back:
                    actor.Direction = actor.Direction.GetBackward();
            }
        }

    }
}
