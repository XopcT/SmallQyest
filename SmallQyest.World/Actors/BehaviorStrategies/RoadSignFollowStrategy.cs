using System.Linq;
using SmallQyest.World.Things;

namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// Strategy to change Character's Direction according to Road Signs.
    /// </summary>
    public class RoadSignFollowStrategy : ActorBehaviorStrategy
    {
        /// <summary>
        /// Selects a Direction for a Actor.
        /// </summary>
        /// <param name="actor">Actor to navigate.</param>
        public override void Navigate(Actor actor)
        {
            RoadSign roadSign = actor.Map.GetItems<RoadSign>(actor.Position)
                .Where(sign => sign.EnterDirection == actor.Direction)
                .FirstOrDefault();
            if (roadSign != null)
                actor.Direction = roadSign.NewDirection;
        }
    }
}
