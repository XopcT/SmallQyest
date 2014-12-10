using SmallQyest.World.Actors.BehaviorStrategies;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Base Class for creating Actors.
    /// </summary>
    public class Actor : Item
    {
        /// <summary>
        /// Initializes the Actor.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            this.IsDestroyed = false;
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

            if (this.BehaviorStrategy != null)
            {
                this.BehaviorStrategy.Navigate(this);
                this.BehaviorStrategy.Move(this);
            }

            // Leaving previous Location:
            foreach (Item item in base.Map.GetItems<Item>(base.Position))
                item.OnLeave(this);
        }

        /// <summary>
        /// Destroys the Actor.
        /// </summary>
        public virtual void Destroy()
        {
            this.IsDestroyed = true;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Direction the Actor moves in.
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Sets/retrieves whether an Actor is destroyed.
        /// </summary>
        public bool IsDestroyed
        {
            get { return this.isDestroyed; }
            set
            {
                this.isDestroyed = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Sets/retrieves a Behavior Strategy for the Actor.
        /// </summary>
        protected ActorBehaviorStrategy BehaviorStrategy { get; set; }

        #endregion

        #region Fields
        private bool isDestroyed = false;

        #endregion
    }
}
