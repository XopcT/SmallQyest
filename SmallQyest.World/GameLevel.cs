using System;
using System.Linq;
using SmallQyest.World.Characters;
using SmallQyest.World.Triggers;
using Logging;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Information of a single Level.
    /// </summary>
    public class GameLevel : ILevel
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="map">Map of the Level.</param>
        public GameLevel(IMap map)
        {
            if (map == null)
                throw new ArgumentNullException("map");
            this.Map = map;
        }

        /// <summary>
        /// Initializes the Level.
        /// </summary>
        public void Initialize()
        {
            this.Logger.LogDebug("Initializing Level");

            this.ValidateMap();
            this.InitializeItems();
            this.Reset();

            this.Logger.LogDebug("Level initialized");
        }

        /// <summary>
        /// Initializes Items on the Map.
        /// </summary>
        private void InitializeItems()
        {
            foreach (IItem item in this.Map)
            {
                item.Level = this;
                item.Initialize();
            }
        }

        /// <summary>
        /// Resets the Level to initial State.
        /// </summary>
        public void Reset()
        {
            IItem levelStart = this.Map.FindItems<LevelStartTrigger>().First();
            Player player = this.Map.FindItems<Player>().First();
            player.X = levelStart.X;
            player.Y = levelStart.Y;
            player.Direction = Vector.Right;
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

        /// <summary>
        /// Checks whether a Map is valid.
        /// </summary>
        private void ValidateMap()
        {
            // Looking for a Level Start:
            if (!this.Map.FindItems<LevelStartTrigger>().Any())
            {
                this.Logger.LogError("Level does not have a Start");
                throw new InvalidCastException("Level Start not found");
            }

            // Looking for Level Endings:
            if (!this.Map.FindItems<LevelEndTrigger>().Any())
            {
                this.Logger.LogError("Level does not have any End");
                throw new InvalidOperationException("Level must have at least one End");
            }

            // Looking for a Player:
            if (!this.Map.FindItems<Player>().Any())
            {
                this.Logger.LogError("Level does not have a Player");
                throw new InvalidOperationException("Player not found");
            }
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
        /// Retrieves the Level Map.
        /// </summary>
        public IMap Map { get; private set; }

        /// <summary>
        /// Sets/retrieves a Logger for Level Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
