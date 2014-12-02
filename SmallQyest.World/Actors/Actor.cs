using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Actors.
    /// </summary>
    public class Actor : Item
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public Actor()
        {
            this.movementStrategy = new BasicMovementStrategy();
        }

        /// <summary>
        /// Updates the State of the Actor.
        /// </summary>
        public override void Update()
        {
            base.Update();

            this.CurrentState = "Default";

            // Visiting current Location. Alot of interesting must be waiting:
            foreach (Item item in base.Map.GetItems<Item>(base.Position))
                item.OnVisit(this);

            this.movementStrategy.Navigate(this);
            this.movementStrategy.Move(this);
        }

        /// <summary>
        /// Kills the Actor.
        /// </summary>
        public virtual void Kill()
        {
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Actor's State.
        /// </summary>
        public string CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Sets/retrieves the Direction the Actor moves in.
        /// </summary>
        public Vector Direction { get; set; }

        #endregion

        #region Fields
        private string currentState = string.Empty;
        private readonly ActorBehaviorStrategy movementStrategy = null;

        #endregion
    }
}
