using SmallQyest.World.Actors.BehaviorStrategies;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Basic Class for the Enemy. It travels around the Map. Mostly harmless yet.
    /// </summary>
    public class Enemy : Character
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public Enemy()
        {
            base.BehaviorStrategy = new ComplexBehaviorStrategy(
                new ActorBehaviorStrategy[] { new BasicPathfindingStrategy() },
                new ActorBehaviorStrategy[] { new MoveAheadStrategy() });
        }

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
                if (this.IsDefeated(character))
                    this.Destroy();
                else
                    character.Destroy();
            }
        }

        /// <summary>
        /// Checks whether an Enemy is defeated by a specified Character.
        /// </summary>
        /// <param name="character">Character to check agaist him.</param>
        /// <returns>True if the Enemy is defeted by the specified Character, False otherwise.</returns>
        protected virtual bool IsDefeated(Character character)
        {
            return false;
        }
    }
}
