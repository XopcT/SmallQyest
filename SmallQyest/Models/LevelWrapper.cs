using System.Collections.Generic;
using System.Linq;
using SmallQyest.Core;
using SmallQyest.World.Tiles;
using SmallQyest.World.Characters;

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
            this.Tiles = this.GetTiles();
            this.Characters = this.GetCharacters();
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
            // Updating Characters:
            foreach (CharacterWrapper character in this.characters)
                character.Update();
        }

        /// <summary>
        /// Retrieves the Tiles from the Map.
        /// </summary>
        /// <returns>Tile List.</returns>
        private IEnumerable<TileWrapper> GetTiles()
        {
            if (base.Wrapped.Map != null)
            {
                return base.Wrapped.Map
                    .Where(item => item is Tile)
                    .Select(item => new TileWrapper((Tile)item))
                    .ToArray();
            }
            else
            {
                return new TileWrapper[0];
            }
        }

        /// <summary>
        /// Retrieves the Characters from the Map.
        /// </summary>
        /// <returns>Character List.</returns>
        private IEnumerable<CharacterWrapper> GetCharacters()
        {
            if (base.Wrapped.Map != null)
            {
                return base.Wrapped.Map
                    .Where(item => item is CharacterBase)
                    .Select(item => new CharacterWrapper((CharacterBase)item))
                    .ToArray();
            }
            else
            {
                return new CharacterWrapper[0];
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

        #endregion

        #region Fields

        private IEnumerable<TileWrapper> tiles = null;
        private IEnumerable<CharacterWrapper> characters = null;

        #endregion
    }
}
