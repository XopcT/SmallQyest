using SmallQyest.World.Actors.BehaviorStrategies;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// A Bullet. It flies. It kills a Character. It destoys when aims any Obstacle.
    /// </summary>
    public class Bullet : Actor
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public Bullet()
        {
            base.BehaviorStrategy = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[] { },
                new ActorBehaviorStrategy[] { new MoveAheadStrategy() });
        }

        /// <summary>
        /// Updates the State of the Bullet.
        /// </summary>
        public override void Update()
        {
            if (!base.Map.CanPassThrough(this, this.Position))
                this.Destroy();
        }

        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            Actor actor = item as Actor;
            if (actor != null)
            {
                actor.Destroy();
                this.Destroy();
            }
        }

    }
}
