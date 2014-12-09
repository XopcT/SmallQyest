﻿using System.Collections.Generic;
using System.Linq;
using SmallQyest.World.Actors.BehaviorStrategies;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Actors.
    /// </summary>
    public class Actor : Item
    {
        /// <summary>
        /// Updates the State of the Actor.
        /// </summary>
        public override void Update()
        {
            base.Update();

            this.CurrentState = "Default";

            // Visiting current Location. Alot of interesting must be waiting:
            foreach (Item item in base.Map.GetItems<Item>(base.Position).ToArray())
                item.OnVisit(this);

            if (this.BehaviorStrategy == null)
                return;

            this.BehaviorStrategy.Navigate(this);
            this.BehaviorStrategy.Move(this);

            // Leaving previous Location:
            foreach (Item item in base.Map.GetItems<Item>(base.Position).ToArray())
                item.OnLeave(this);
        }

        /// <summary>
        /// Kills the Actor.
        /// </summary>
        public virtual void Kill()
        {
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Direction the Actor moves in.
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Sets/retrieves a Behavior Strategy for the Actor.
        /// </summary>
        protected ActorBehaviorStrategy BehaviorStrategy { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
