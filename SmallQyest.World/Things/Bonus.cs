using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// Gives something nice to the Player.
    /// </summary>
    public class Bonus : Thing
    {
        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            Character character = item as Character;
            if (character != null)
            {
                character.PickUp(this);
            }
        }
    }
}
