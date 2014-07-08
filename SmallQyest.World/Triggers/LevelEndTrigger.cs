using SmallQyest.Core;

namespace SmallQyest.World.Triggers
{
    /// <summary>
    /// Trigger which has to be placed where the Level ends.
    /// A Level may have multiple LevelEndTriggers, but at least one.
    /// </summary>
    public class LevelEndTrigger : Trigger
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public LevelEndTrigger()
        {
            // TODO Move this to Level Provider:
            this.NextLevelIndex = 1;
        }

        /// <summary>
        /// Handles Collision of the Trigger against another one.
        /// When Player enters the Trigger, the Level ends and new one is loaded.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(IItem item)
        {
            base.OnVisit(item);
            base.Level.Pass(this.NextLevelIndex);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Index of the next Level to go.
        /// </summary>
        public int NextLevelIndex { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
