using System.Collections.Generic;
using System.Linq;
using SmallQyest.Core;

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

            // Checking if Character can go forward:
            if (!this.CanGoTo(this.Direction))
            {
                // Trying to turn right:
                if (this.CanGoTo(this.Direction.GetRight()))
                    this.Direction = this.Direction.GetRight();
                // Trying to go left:
                else if (this.CanGoTo(this.Direction.GetLeft()))
                    this.Direction = this.Direction.GetLeft();
                // Going back:
                else
                    this.Direction = this.Direction.GetBackward();
            }
            // Moving in the selected Direction:
            this.Move(this.Direction);
        }

        /// <summary>
        /// Checks whether Character can go in specified Direction.
        /// </summary>
        /// <param name="direction">Direction to check.</param>
        /// <returns>True if Character can go in specified Direction, False otherwise.</returns>
        private bool CanGoTo(Vector direction)
        {
            int newX = this.X + direction.X;
            int newY = this.Y + direction.Y;
            IEnumerable<bool> passTestResults = base.Map.GetItems<ItemBase>(newX, newY)
                .Select(item => item.CanPassThrough(this));
            return passTestResults.Any() && passTestResults.All(result => result == true);
        }

        /// <summary>
        /// Moves Character in the specified Direction.
        /// </summary>
        /// <param name="direction">Direction to move.</param>
        private void Move(Vector direction)
        {
            if (direction.X == Vector.Left.X && direction.Y == Vector.Left.Y)
                this.CurrentState = "MoveLeft";
            else if (direction.X == Vector.Up.X && direction.Y == Vector.Up.Y)
                this.CurrentState = "MoveUp";
            else if (direction.X == Vector.Right.X && direction.Y == Vector.Right.Y)
                this.CurrentState = "MoveRight";
            else if (direction.X == Vector.Down.X && direction.Y == Vector.Down.Y)
                this.CurrentState = "MoveDown";
            else
                throw new System.InvalidOperationException();

            // Leaving previous Location:
            foreach (ItemBase item in base.Map.GetItems<ItemBase>(base.X, base.Y))
                item.OnLeave(this);

            // Updating Coordinates:
            base.X += direction.X;
            base.Y += direction.Y;
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
                this.Logger.LogMessage("Player is now in {0} State.", this.currentState);
            }
        }

        /// <summary>
        /// Sets/retrieves the Character's Inventory.
        /// </summary>
        public ICollection<IItem> Inventory { get; set; }

        #endregion

        #region Fields
        private string currentState = string.Empty;

        #endregion
    }
}
