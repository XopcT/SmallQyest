using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using SmallQyest.World.Actors;
using SmallQyest.World.Things;
using SmallQyest.World.Triggers;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains Information of a single Level.
    /// </summary>
    public class Level : ILevel
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="map">Map of the Level.</param>
        public Level(Map map)
        {
            if (map == null)
                throw new ArgumentNullException("map");
            this.Map = map;
        }

        /// <summary>
        /// Initializes the Level.
        /// </summary>
        public virtual void Initialize()
        {
            // Looking for a Level Start:
            if (!this.Map.GetItems<PlayerSpawnTrigger>().Any())
                throw new InvalidOperationException("Level Start not found");
            // Looking for Level Endings:
            if (!this.Map.GetItems<LevelEndTrigger>().Any())
                throw new InvalidOperationException("Level must have at least one End");

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
            this.InitializeItems();
        }

        /// <summary>
        /// Initializes the Items.
        /// </summary>
        private void InitializeItems()
        {
            foreach (Item item in this.Map.Union(this.tools).ToArray())
            {
                item.Initialize();
            }
        }

        /// <summary>
        /// Starts playing the Level.
        /// </summary>
        public virtual void Start()
        {
            this.IsPlaying = true;
        }

        /// <summary>
        /// Stops playing the Level.
        /// </summary>
        public virtual void Stop()
        {
            this.IsPlaying = false;
            this.InitializeItems();
        }

        /// <summary>
        /// Resets the Level to initial State.
        /// </summary>
        public virtual void Reset()
        {
            this.Stop();
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
        /// Passes the Level.
        /// </summary>
        /// <param name="levelId">ID of the next Level.</param>
        public virtual void Pass(int levelId)
        {
            this.OnLevelPassed(this, new LevelPassedEventArgs(levelId));
        }

        /// <summary>
        /// Fails the Level.
        /// </summary>
        public virtual void Fail()
        {
            this.OnLevelFailed(this, EventArgs.Empty);
        }

        #region Events

        /// <summary>
        /// Occurs when a Property Value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        private void OnPropertyChanged(object sender, [CallerMemberName()]string propertyName = "")
        {
            var temp = this.PropertyChanged;
            if (temp != null)
                temp(sender, new PropertyChangedEventArgs(propertyName));
        }

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
        /// Retrieves whether the Level is currently playing.
        /// </summary>
        public bool IsPlaying
        {
            get { return this.isPlaying; }
            set
            {
                this.isPlaying = value;
                this.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private bool isPlaying = false;
        private readonly ObservableCollection<Thing> tools = new ObservableCollection<Thing>();

        #endregion
    }
}
