using System;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Arguments for LevelPassed Event.
    /// </summary>
    public class LevelPassedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public LevelPassedEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="nextLevel">ID of the Level after current one.</param>
        public LevelPassedEventArgs(int nextLevel)
        {
            this.NextLevel = nextLevel;
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves ID of the next Level.
        /// </summary>
        public int NextLevel { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
