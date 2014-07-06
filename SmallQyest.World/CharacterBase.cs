using System.Linq;

namespace SmallQyest.World
{
    /// <summary>
    /// Base Class for creating Characters.
    /// </summary>
    public class CharacterBase : WorldItem
    {
        /// <summary>
        /// Updates the State of the Character.
        /// </summary>
        public override void Update()
        {
            base.Update();
            if (!this.CanGoTo(this.direction))
            {
                if (this.CanGoTo(this.direction.GetRight()))
                    this.direction = this.direction.GetRight();
                else if (this.CanGoTo(this.direction.GetLeft()))
                    this.direction = this.direction.GetLeft();
                else
                    this.direction = this.direction.GetBackward();
            }
            this.Move(this.direction);
        }

        private bool CanGoTo(Vector direction)
        {
            int newX = this.X + direction.X;
            int newY = this.Y + direction.Y;
            return this.Map.GetItems<WorldItem>(newX, newY)
                .Select(item => item.CanPassThroug(this))
                .All(result => result == true);
        }

        private void Move(Vector direction)
        {
            this.X += this.direction.X;
            this.Y += this.direction.Y;
        }

        #region Properties
        private Vector direction = Vector.Right;

        #endregion
    }
}
