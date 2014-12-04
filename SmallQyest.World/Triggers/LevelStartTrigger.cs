using System;

namespace SmallQyest.World.Triggers
{
    /// <summary>
    /// Trigger which has to be placed at the Beginning of each Level.
    /// </summary>
    [Obsolete("Use Player Spawn Trigger instead.")]
    public class LevelStartTrigger : Trigger
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public LevelStartTrigger()
        {
            // TODO Move this to Level Provider:
            this.Direction = Vector.Right;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the initial Player's Direction.
        /// </summary>
        public Vector Direction { get; set; }

        #endregion
    }
}
