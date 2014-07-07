using System;
using System.Linq;
using SmallQyest.Core;
using SmallQyest.World.Triggers;
using SmallQyest.World.Characters;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Information of a single Level.
    /// </summary>
    public class Level : ILevel
    {
        /// <summary>
        /// Initializes the Level.
        /// </summary>
        public void Initialize()
        {
            // Looking for Level Endings:
            if (!this.Map.Where(item => item is LevelEndTrigger).Any())
                throw new InvalidOperationException("Level must have at least one End");

            // Looking for a Player:
            IItem player = this.Map.Where(item => item is Player).FirstOrDefault();
            if (player == null)
                throw new InvalidOperationException("Player not found");

            // Looking for a Level Start:
            IItem levelStart = this.Map.Where(item => item is LevelStartTrigger).FirstOrDefault();
            if (levelStart == null)
                throw new InvalidCastException("Level Start not found");

            player.X = levelStart.X;
            player.Y = levelStart.Y;
        }

        /// <summary>
        /// Passes the Level.
        /// </summary>
        /// <param name="levelId">ID of the next Level.</param>
        public void Pass(int levelId)
        {
            this.OnLevelPassed(this, new LevelPassedEventArgs(levelId));
        }

        /// <summary>
        /// Fails the Level.
        /// </summary>
        public void Fail()
        {
            this.OnLevelFailed(this, EventArgs.Empty);
        }

        #region Events

        /// <summary>
        /// Occurs when Player passes the Level.
        /// </summary>
        public event EventHandler<LevelPassedEventArgs> LevelPassed;

        /// <summary>
        /// Raises the LevelPassed Event.
        /// </summary>
        private void OnLevelPassed(object sender, LevelPassedEventArgs e)
        {
            var temp = this.LevelPassed;
            if (temp != null)
                temp(sender, e);
        }

        /// <summary>
        /// Occurs when Player fails with the Level.
        /// </summary>
        public event EventHandler<EventArgs> LevelFailed;

        /// <summary>
        /// Raises the LevelFailed Event.
        /// </summary>
        private void OnLevelFailed(object sender, EventArgs e)
        {
            var temp = this.LevelFailed;
            if (temp != null)
                temp(sender, e);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets/retrieves the Level Map.
        /// </summary>
        public IMap Map { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
