using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SmallQyest.Core;
using SmallQyest.World.Tiles;
using SmallQyest.Models;
using SmallQyest.World;

namespace SmallQyest.ViewModels
{
    /// <summary>
    /// View Model for a Game Level.
    /// </summary>
    public class LevelViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public LevelViewModel()
        {
            this.Back = new Command(arg => this.OnBack());
        }

        /// <summary>
        /// Performs the main Level Activity.
        /// </summary>
        /// <param name="cancel">Triggers the exiting the Level.</param>
        private async void MainLoop(CancellationToken cancel)
        {
            base.Logger.LogMessage("Level Loop started.");
            while (!cancel.IsCancellationRequested)
            {
                this.UpdateMap();
                this.UpdateTiles();
                this.UpdateCharacters();
                await Task.Delay(TimeSpan.FromSeconds(0.5));
            }
            base.Logger.LogMessage("Level Loop exited");
        }

        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        private void UpdateMap()
        {
            if (this.Level != null && this.Level.Map != null)
                this.Level.Map.Update();
        }

        /// <summary>
        /// Updates the State of Tiles.
        /// </summary>
        private void UpdateTiles()
        {
            foreach (TileWrapper tile in this.GroundTiles)
                tile.Update();
        }

        /// <summary>
        /// Updates the State of Characters.
        /// </summary>
        private void UpdateCharacters()
        {
            foreach (CharacterWrapper character in this.Characters)
                character.Update();
        }

        /// <summary>
        /// Retrieves the Tiles from the Map.
        /// </summary>
        /// <returns>Tile List.</returns>
        private IEnumerable<TileWrapper> GetTiles()
        {
            if (this.Level != null && this.Level.Map != null)
            {
                return this.Level.Map
                    .Where(item => item is TileBase)
                    .Select(item => new TileWrapper((TileBase)item))
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
            if (this.Level != null && this.Level.Map != null)
            {
                return this.Level.Map
                    .Where(item => item is CharacterBase)
                    .Select(item => new CharacterWrapper((CharacterBase)item))
                    .ToArray();
            }
            else
            {
                return new CharacterWrapper[0];
            }
        }

        /// <summary>
        /// Handles Navigation to this View Model.
        /// </summary>
        public override async void OnNavigateTo()
        {
            base.OnNavigateTo();
            await Task.Run(() => this.MainLoop(this.cancel.Token), this.cancel.Token);
        }

        /// <summary>
        /// Handles Navigation from this View Model.
        /// </summary>
        public override void OnNavigateFrom()
        {
            base.OnNavigateFrom();
            this.cancel.Cancel();
        }

        /// <summary>
        /// Handles going back from the Level.
        /// </summary>
        private void OnBack()
        {
            this.cancel.Cancel();
            base.AppController.ToMainMenu();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the current Level.
        /// </summary>
        public Level Level
        {
            get { return this.level; }
            set
            {
                this.level = value;
                this.tiles = this.GetTiles();
                this.characters = this.GetCharacters();

                base.OnPropertyChanged(this);
                base.OnPropertyChanged(this, "GroundTiles");
                base.OnPropertyChanged(this, "Characters");
            }
        }

        /// <summary>
        /// Retrieves the Ground Tiles of the Map.
        /// </summary>
        public IEnumerable<TileWrapper> GroundTiles
        {
            get { return this.tiles; }
        }

        /// <summary>
        /// Retrieves the Characters of the Map.
        /// </summary>
        public IEnumerable<CharacterWrapper> Characters
        {
            get { return this.characters; }
        }

        /// <summary>
        /// Retrieves a Command to go Back from the Level.
        /// </summary>
        public ICommand Back { get; private set; }

        #endregion

        #region Fields
        private Level level = null;
        private IEnumerable<TileWrapper> tiles = null;
        private IEnumerable<CharacterWrapper> characters = null;

        private CancellationTokenSource cancel = new CancellationTokenSource();

        #endregion
    }
}
