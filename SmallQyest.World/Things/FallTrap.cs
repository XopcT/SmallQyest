using SmallQyest.World;
using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Trap. Character falls down when comes in. Try to avoid it.
    /// </summary>
    public class FallTrap : Thing
    {
        /// <summary>
        /// Handles Collision of the Trap against an Item. If Character visits the trap, he falls down.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            Actor character = item as Actor;
            if (character != null)
                character.Destroy();
        }

    }
}
