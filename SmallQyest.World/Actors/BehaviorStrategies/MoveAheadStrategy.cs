
namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// Strategy to move an Actor straight ahead until it collides a Obstacle.
    /// </summary>
    public class MoveAheadStrategy : ActorBehaviorStrategy
    {
        /// <summary>
        /// Moves an Actor over the Map.
        /// </summary>
        /// <param name="actor">Actor to move.</param>
        public override void Move(Actor actor)
        {
            if (actor.Direction == Vector.Left)
                actor.CurrentState = "MoveLeft";
            else if (actor.Direction == Vector.Up)
                actor.CurrentState = "MoveUp";
            else if (actor.Direction == Vector.Right)
                actor.CurrentState = "MoveRight";
            else if (actor.Direction == Vector.Down)
                actor.CurrentState = "MoveDown";
            else
                throw new System.InvalidOperationException();
            // Updating Coordinates:
            actor.Position += actor.Direction;
        }
    }
}
