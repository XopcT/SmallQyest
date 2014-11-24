using SmallQyest.Core;
using SmallQyest.World.Characters;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// An Obstacle which can be passed only once. Then it's closed.
    /// </summary>
    public class OneTimePassObstacle : Thing
    {
        /// <summary>
        /// Initializes the Obstacle.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            // Initially the Obstacle is open:
            this.IsOpen = true;
        }

        /// <summary>
        /// Checks whether Obstacle can be passed by another Item.
        /// If Obstacle is open, it can be passed by anyone. Nobody can passed the closed Obstacle.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if Obstacle can be passed, False otherwise.</returns>
        public override bool CanPassThroug(IItem item)
        {
            return this.IsOpen;
        }

        /// <summary>
        /// Handles Leaving of the Obstacle by some Item.
        /// </summary>
        /// <param name="item">Item that lived.</param>
        public override void OnLeave(IItem item)
        {
            base.OnLeave(item);
            CharacterBase character = item as CharacterBase;
            if (item != null)
                this.IsOpen = false;
        }

        #region Properties

        /// <summary>
        /// Retrieves whether an Obstacle is open.
        /// </summary>
        public bool IsOpen
        {
            get { return this.isOpen; }
            private set
            {
                this.isOpen = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private bool isOpen = true;

        #endregion
    }
}
