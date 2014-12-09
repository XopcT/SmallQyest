using System;
using System.Linq;

namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// 1. Greedy Actor looks for Items he is interested in.
    /// 2. ???
    /// 3. PROFIT!
    /// </summary>
    /// <typeparam name="TInterest">Type of Items the Actor is interested in.</typeparam>
    public class ProfitSearchStrategy<TInterest> : ActorBehaviorStrategy
        where TInterest : Item
    {
        /// <summary>
        /// Selectes a Direction for a Character.
        /// </summary>
        /// <param name="actor">Character to navigate.</param>
        public override void Navigate(Actor actor)
        {
            Vector newDirection = actor.Map.GetItems<TInterest>()              // Getting all Items the Actor can be interested in
                .Where(item => actor.Map.CanSee(actor.Position, item.Position)  // Checking if Actor can see and can reach some of them
                    && actor.Map.CanMoveTo(actor, this.GetDirection(item.Position - actor.Position)))
                .Select(item => item.Position - actor.Position)                 // Taking Vector from a Player to that Item
                .OrderBy(way => this.GetLength(way))                            // and looking for the closest one
                .Select(way => this.GetDirection(way))
                .OrderBy(direction => this.CompareDirection(actor.Direction, direction))    // Items which do not require an Actor to change his Direction are preferred
                .FirstOrDefault();
            // Changing Actor's Direction if Item of Interest was found:
            if (newDirection != Vector.Zero)
                actor.Direction = newDirection;
        }

        private int GetLength(Vector way)
        {
            return Math.Abs(way.X + way.Y);
        }

        private Vector GetDirection(Vector way)
        {
            return new Vector(Math.Sign(way.X), Math.Sign(way.Y));
        }

        private int CompareDirection(Vector one, Vector another)
        {
            if (one == another)
                return 0;
            else
                return 1;
        }
    }
}
