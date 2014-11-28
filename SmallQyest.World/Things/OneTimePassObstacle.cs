using SmallQyest.World;
using SmallQyest.World.Characters;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// Door which can be passed only once. Then it's closed.
    /// </summary>
    public class OneTimePassObstacle : Door
    {
        /// <summary>
        /// Initializes the Obstacle.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            // Initially the Obstacle is open:
            base.IsOpen = true;
        }

        /// <summary>
        /// Checks whether Obstacle can be passed by another Item.
        /// If Obstacle is open, it can be passed by anyone. Nobody can passed the closed Obstacle.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if Obstacle can be passed, False otherwise.</returns>
        public override bool CanPassThrough(Item item)
        {
            return this.IsOpen;
        }

        /// <summary>
        /// Handles Leaving of the Obstacle by some Item.
        /// </summary>
        /// <param name="item">Item that lived.</param>
        public override void OnLeave(Item item)
        {
            base.OnLeave(item);
            CharacterBase character = item as CharacterBase;
            if (item != null)
                this.IsOpen = false;
        }

    }
}
