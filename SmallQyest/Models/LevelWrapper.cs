using System.Collections.Generic;
using System.Linq;
using SmallQyest.Core;
using SmallQyest.World.Tiles;
using SmallQyest.World.Characters;
using SmallQyest.World.Things;

namespace SmallQyest.Models
{
    /// <summary>
    /// Model for Levels.
    /// </summary>
    public class LevelWrapper : WrapperBase<ILevel>
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Level to wrap.</param>
        public LevelWrapper(ILevel wrapped)
            : base(wrapped)
        {
            this.Tiles = this.Filter<Tile>().Select(tile => new TileWrapper(tile)).ToArray();
            this.Characters = this.Filter<CharacterBase>().Select(character => new CharacterWrapper(character)).ToArray();
            this.Things = this.Filter<Thing>().Select(thing => ThingWrapperFactory.CreateWrapper(thing)).ToArray();
        }

        /// <summary>
        /// Updates the State of the Level.
        /// </summary>
        public void Update()
        {
            // Updating the Map:
            if (base.Wrapped.Map != null)
                base.Wrapped.Map.Update();
            // Updating Tiles:
            foreach (TileWrapper tile in this.tiles)
                tile.Update();
            // Updating Things:
            foreach (ThingWrapper thing in this.things)
                thing.Update();
            // Updating Characters:
            foreach (CharacterWrapper character in this.characters)
                character.Update();
        }

        private IEnumerable<ItemType> Filter<ItemType>()
            where ItemType : IItem
        {
            if (base.Wrapped.Map != null)
            {
                return base.Wrapped.Map.FindItems<ItemType>();
            }
            else
            {
                return new ItemType[0];
            }
        }

        #region Properties

        /// <summary>
        /// Retrieves the Tiles of the Level.
        /// </summary>
        public IEnumerable<TileWrapper> Tiles
        {
            get { return this.tiles; }
            private set
            {
                this.tiles = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Retrieves the Characters of the Level.
        /// </summary>
        public IEnumerable<CharacterWrapper> Characters
        {
            get { return this.characters; }
            private set
            {
                this.characters = value;
                base.OnPropertyChanged(this);
            }
        }

        /// <summary>
        /// Retrieves the Things on the Level.
        /// </summary>
        public IEnumerable<ThingWrapper> Things
        {
            get { return this.things; }
            private set
            {
                this.things = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields

        private IEnumerable<TileWrapper> tiles = null;
        private IEnumerable<CharacterWrapper> characters = null;
        private IEnumerable<ThingWrapper> things = null;

        #endregion
    }
}
