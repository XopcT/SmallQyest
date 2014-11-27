using System.Collections.Generic;
using System.Linq;
using SmallQyest.Core;
using SmallQyest.World.Characters;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// Obstacle which can be moved by a Character.
    /// </summary>
    public class MoveableObstacle : Thing
    {
        /// <summary>
        /// Checks whether a Character can move to the Obstacle's Location.
        /// If there is a free Space in Character's Moving Direction, the Obstacle can be moved there.
        /// </summary>
        /// <param name="item">Item which tries to pass the Obstacle.</param>
        /// <returns>True if Item can pass, False otherwise.</returns>
        public override bool CanPassThrough(IItem item)
        {
            CharacterBase character = item as CharacterBase;
            if (character != null)
            {
                // Checking if there is a free Space in the Character's Moving Direction:
                return this.CanMoveTo(character.Direction);
            }
            else
                // Anyone except a Character can not move the Obstacle:
                return false;
        }

        /// <summary>
        /// Handles visiting Obstacle by another Item.
        /// If Character visits the Obstacle, he moves it in Front of him.
        /// </summary>
        /// <param name="item">Item visiting the Obstacle.</param>
        public override void OnVisit(IItem item)
        {
            base.OnVisit(item);
            CharacterBase character = item as CharacterBase;
            if (character != null)
            {
                if (this.CanMoveTo(character.Direction))
                {
                    base.X += character.Direction.X;
                    base.Y += character.Direction.Y;
                }
            }
        }

        /// <summary>
        /// Checks whether there is a free Space in specified Direction.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>True if there is a free Space, False otherwise.</returns>
        private bool CanMoveTo(Vector direction)
        {
            int newX = this.X + direction.X;
            int newY = this.Y + direction.Y;
            IEnumerable<bool> passTestResults = base.Map.GetItems<ItemBase>(newX, newY)
                .Select(item => item.CanPassThrough(this));
            return passTestResults.Any() && passTestResults.All(result => result == true);
        }
    }
}
