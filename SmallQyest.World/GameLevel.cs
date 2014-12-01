using System;
using System.Collections.ObjectModel;
using System.Linq;
using SmallQyest.World.Actors;
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
            foreach (Item item in this.Map)
            {
                item.Level = this;
                item.Origin = ItemOrigin.FromMap;
            }
            foreach (Item item in this.Tools)
            {
                item.Level = this;
                item.Origin = ItemOrigin.FromToolbar;
            }
            this.Restart();

            this.Logger.LogDebug("Level initialized");
        }

        /// <summary>
        /// Starts the Level again.
        /// </summary>
        public void Restart()
        {
            foreach (Item item in this.Map.Union(this.tools).ToArray())
            {
                item.Initialize();
            }
        }

        /// <summary>
        /// Resets the Level to initial State.
        /// </summary>
        public void Reset()
        {
            this.MoveItemsFromInventoryToMap();
            this.MoveItemsFromMapToToolbar();
        }

        /// <summary>
        /// Moves Items from Characters' Inventories to the Map.
        /// </summary>
        private void MoveItemsFromInventoryToMap()
        {

            Character[] characters = this.Map.GetItems<Character>().ToArray();
            foreach (Character character in characters)
            {
                Item[] items = character.Inventory.ToArray();
                foreach (Item item in items)
                {
                    this.Map.Add(item);
                    character.Inventory.Remove(item);
                }
            }
        }

        /// <summary>
        /// Moves Items from Map to the Toolbar.
        /// </summary>
        private void MoveItemsFromMapToToolbar()
        {
            Item[] toolbarItems = this.Map.GetItems<Thing>()
                .Where(item => item.Origin == ItemOrigin.FromToolbar)
                .ToArray();
            foreach (Thing toolbarItem in toolbarItems)
            {
                this.Tools.Add(toolbarItem);
                this.Map.Remove(toolbarItem);
            }
        }

        /// <summary>
        /// Checks whether a Map is valid.
        /// </summary>
        private void ValidateMap()
        {
            // Looking for a Level Start:
            if (!this.Map.GetItems<PlayerSpawnTrigger>().Any())
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
