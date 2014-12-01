using System;
using System.Collections.ObjectModel;
using System.Linq;
using SmallQyest.World.Characters;
using SmallQyest.World.Things;
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
        public GameLevel(Map map)
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
            this.Reset();

            this.Logger.LogDebug("Level initialized");
        }

        /// <summary>
        /// Checks whether a Map is valid.
        /// </summary>
        private void ValidateMap()
        {
            // Looking for a Level Start:
            if (!this.Map.GetItems<LevelStartTrigger>().Any())
            {
                this.Logger.LogError("Level does not have a Start");
                throw new InvalidCastException("Level Start not found");
            }

            // Looking for Level Endings:
            if (!this.Map.GetItems<LevelEndTrigger>().Any())
            {
                this.Logger.LogError("Level does not have any End");
                throw new InvalidOperationException("Level must have at least one End");
            }

            // Looking for a Player:
            if (!this.Map.GetItems<Player>().Any())
            {
                this.Logger.LogError("Level does not have a Player");
                throw new InvalidOperationException("Player not found");
            }
        }

        /// <summary>
        /// Resets the Level to initial State.
        /// </summary>
        public void Reset()
        {
            foreach (Item item in this.Map.Union(this.tools))
            {
                item.Level = this;
                item.Initialize();
            }

            Item levelStart = this.Map.GetItems<LevelStartTrigger>().First();
            Player player = this.Map.GetItems<Player>().First();
            player.Position = levelStart.Position;
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
        public Map Map { get; private set; }

        /// <summary>
        /// Retrieves the Collection of Tools available for this Level.
        /// </summary>
        public ObservableCollection<Thing> Tools
        {
            get { return this.tools; }
        }

        /// <summary>
        /// Sets/retrieves a Logger for Level Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields

        private readonly ObservableCollection<Thing> tools = new ObservableCollection<Thing>();

        #endregion
    }
}
