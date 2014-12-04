using SmallQyest.World;
using SmallQyest.World.Actors;

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
            base.Open();
        }

        /// <summary>
        /// Handles Leaving of the Obstacle by some Item.
        /// </summary>
        /// <param name="item">Item that lived.</param>
        public override void OnLeave(Item item)
        {
            base.OnLeave(item);
            Actor character = item as Actor;
            if (item != null)
                base.Close();
        }

    }
}
