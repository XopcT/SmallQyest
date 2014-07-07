using System.Linq;

namespace SmallQyest.World.Characters
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class CharacterBase : WorldItem
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public CharacterBase()
        {
            this.Direction = Vector.Right;
        }

        /// <summary>
        /// Updates the State of the Character.
        /// </summary>
        public override void Update()
        {
            base.Update();
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
            return this.Map.GetItems<WorldItem>(newX, newY)
                .Select(item => item.CanPassThroug(this))
                .All(result => result == true);
        }

        /// <summary>
        /// Moves Character in the specified Direction.
        /// </summary>
        /// <param name="direction">Direction to move.</param>
        private void Move(Vector direction)
        {
            // Leaving previous Location:
            foreach (WorldItem item in base.Map.GetItems<WorldItem>(base.X, base.Y))
                item.OnLeave(this);
            // Updating Coordinates:
            base.X += this.Direction.X;
            base.Y += this.Direction.Y;
            // Visiting new Location. Alot of interesting is waiting:
            foreach (WorldItem item in base.Map.GetItems<WorldItem>(base.X, base.Y))
                item.OnVisit(this);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Direction the Character moves in.
        /// </summary>
        public Vector Direction { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
