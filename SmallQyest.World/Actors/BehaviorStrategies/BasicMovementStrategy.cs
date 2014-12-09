
namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// The most simple Behavior Strategy to move a Character over the Map.
    /// </summary>
    public class BasicMovementStrategy : ActorBehaviorStrategy
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

        /// <summary>
        /// Moves an Actor over the Map.
        /// </summary>
        /// <param name="actor">Actor to move.</param>
        public override void Move(Actor actor)
        {
            if (actor.Direction.X == Vector.Left.X && actor.Direction.Y == Vector.Left.Y)
                actor.CurrentState = "MoveLeft";
            else if (actor.Direction.X == Vector.Up.X && actor.Direction.Y == Vector.Up.Y)
                actor.CurrentState = "MoveUp";
            else if (actor.Direction.X == Vector.Right.X && actor.Direction.Y == Vector.Right.Y)
                actor.CurrentState = "MoveRight";
            else if (actor.Direction.X == Vector.Down.X && actor.Direction.Y == Vector.Down.Y)
                actor.CurrentState = "MoveDown";
            else
                throw new System.InvalidOperationException();
            // Updating Coordinates:
            actor.Position += actor.Direction;
        }

    }
}
