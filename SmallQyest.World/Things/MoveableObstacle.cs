using SmallQyest.World.Actors;

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
        public override bool CanPassThrough(Item item)
        {
            Actor character = item as Actor;
            if (character != null)
            {
                // Checking if there is a free Space in the Character's Moving Direction:
                Vector direction = base.Position - character.Position;
                return base.Map.CanMoveTo(this, direction);
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
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            Actor character = item as Actor;
            if (character != null)
            {
                if (base.Map.CanMoveTo(this, character.Direction))
                {
                    base.Position += character.Direction;
                }
            }
        }
    }
}
