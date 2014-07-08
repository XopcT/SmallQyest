using System;
using System.Linq;
using SmallQyest.Core;
using SmallQyest.World.Triggers;
using SmallQyest.World.Characters;
using Logging;

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
            this.Logger.LogDebug("Initializing Level");
            // Looking for Level Endings:
            if (!this.Map.FindItems<LevelEndTrigger>().Any())
            {
                this.Logger.LogError("Level does not have any End");
                throw new InvalidOperationException("Level must have at least one End");
            }
            // Looking for a Player:
            Player player = this.Map.FindItems<Player>().FirstOrDefault();
            if (player == null)
            {
                this.Logger.LogError("Level does not have a Player");
                throw new InvalidOperationException("Player not found");
            }
            // Looking for a Level Start:
            LevelStartTrigger levelStart = this.Map.FindItems<LevelStartTrigger>().FirstOrDefault();
            if (levelStart == null)
            {
                this.Logger.LogError("Level does not have a Start");
                throw new InvalidCastException("Level Start not found");
            }
            // Placing Player on the Start:
            player.X = levelStart.X;
            player.Y = levelStart.Y;
            player.Direction = levelStart.Direction;
            // Initializing Items:
            foreach (IItem item in this.Map)
                item.Initialize();

            this.Logger.LogDebug("Level initialized");
        }

        /// <summary>
        /// Passes the Level.
        /// </summary>
        /// <param name="levelId">ID of the next Level.</param>
        public void Pass(int levelId)
        {
            this.Logger.LogDebug("Passing to Level {0}", levelId);
            this.OnLevelPassed(this, new LevelPassedEventArgs(levelId));
        }

        /// <summary>
        /// Fails the Level.
        /// </summary>
        public void Fail()
        {
            this.Logger.LogDebug("Level failed");
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

        /// <summary>
        /// Sets/retrieves a Logger for Level Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
