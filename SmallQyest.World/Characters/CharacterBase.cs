using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.World.Characters
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class CharacterBase : ItemBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public CharacterBase()
        {
            this.movementStrategy = new BasicMovementStrategy();
            this.Inventory = new List<IItem>();
        }

        /// <summary>
        /// Updates the State of the Character.
        /// </summary>
        public override void Update()
        {
            base.Update();

            this.CurrentState = "Default";

            // Visiting current Location. Alot of interesting must be waiting:
            foreach (ItemBase item in base.Map.GetItems<ItemBase>(base.X, base.Y))
                item.OnVisit(this);

            this.movementStrategy.Navigate(this);
            this.movementStrategy.Move(this);
        }

        /// <summary>
        /// Checks whether Character can go in specified Direction.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>True if Character can go in specified Direction, False otherwise.</returns>
        public bool CanGoTo(Vector direction)
        {
            int newX = this.X + direction.X;
            int newY = this.Y + direction.Y;
            IEnumerable<bool> passTestResults = this.Map.GetItems<ItemBase>(newX, newY)
                .Select(item => item.CanPassThrough(this));
            return passTestResults.Any() && passTestResults.All(result => result == true);
        }

        /// <summary>
        /// Kills the Character.
        /// </summary>
        public virtual void Kill()
        {
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Direction the Character moves in.
        /// </summary>
        public Vector Direction { get; set; }

        /// <summary>
        /// Sets/retrieves the current Character's State.
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
        /// Sets/retrieves the Character's Inventory.
        /// </summary>
        public ICollection<IItem> Inventory { get; set; }

        #endregion

        #region Fields
        private string currentState = string.Empty;
        private readonly CharacterBehaviorStrategy movementStrategy = null;

        #endregion
    }
}
