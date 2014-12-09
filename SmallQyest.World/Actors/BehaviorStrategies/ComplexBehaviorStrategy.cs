using System;
using System.Collections.Generic;

namespace SmallQyest.World.Actors.BehaviorStrategies
{
    /// <summary>
    /// Advanced Behavior Strategy which contains List of Strategies for Movement and Navigation.
    /// </summary>
    public class ComplexBehaviorStrategy : ActorBehaviorStrategy
    {
        /// <summary>
        /// Initiailzes a new Instance of current Class.
        /// </summary>
        /// <param name="navigationStrategies">Strategies for Navigation.</param>
        /// <param name="movementStrategies">Strategies for Movement.</param>
        public ComplexBehaviorStrategy(IEnumerable<ActorBehaviorStrategy> navigationStrategies, IEnumerable<ActorBehaviorStrategy> movementStrategies)
        {
            if (navigationStrategies == null)
                throw new ArgumentNullException("navigationStrategies");
            this.navigationStrategies = navigationStrategies;

            if (movementStrategies == null)
                throw new ArgumentNullException("movementStrategies");
            this.movementStrategies = movementStrategies;
        }

        /// <summary>
        /// Selects a Direction for a Actor.
        /// </summary>
        /// <param name="actor">Actor to navigate.</param>
        public override void Navigate(Actor actor)
        {
            foreach (ActorBehaviorStrategy strategy in this.navigationStrategies)
                strategy.Navigate(actor);
        }

        /// <summary>
        /// Moves a Actor over the Map.
        /// </summary>
        /// <param name="actor">Actor to move.</param>
        public override void Move(Actor actor)
        {
            foreach (ActorBehaviorStrategy strategy in this.movementStrategies)
                strategy.Move(actor);
        }

        #region Properties

        #endregion

        #region Fields
        private readonly IEnumerable<ActorBehaviorStrategy> navigationStrategies = null;
        private readonly IEnumerable<ActorBehaviorStrategy> movementStrategies = null;

        #endregion
    }
}
