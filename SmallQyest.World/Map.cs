using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SmallQyest.World.Actors;
using SmallQyest.World.Things;
using SmallQyest.World.Tiles;
using System;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains a Level Map.
    /// </summary>
    public class Map : ICollection<Item>
    {
        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        public virtual void Update()
        {
            foreach (Item item in this.actors)
                item.Update();
        }

        /// <summary>
        /// Adds Item on the Map.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public virtual void Add(Item item)
        {
            this.items.Add(item);

            Tile tile = item as Tile;
            Actor actor = item as Actor;
            Thing thing = item as Thing;
            if (tile != null)
                this.tiles.Add(tile);
            else if (actor != null)
                this.actors.Add(actor);
            else if (thing != null)
                this.things.Add(thing);
        }

        /// <summary>
        /// Removes all Items from the Map.
        /// </summary>
        public virtual void Clear()
        {
            foreach (Item item in this.items.ToArray())
            {
                this.Remove(item);
            }
        }

        /// <summary>
        /// Checks whether Map contains specified Item.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <returns>True if Map contains the Item, False otherwise.</returns>
        public bool Contains(Item item)
        {
            return this.items.Contains(item);
        }

        /// <summary>
        /// Copies the Items from the Map and Array, starting at a particular Index.
        /// </summary>
        /// <param name="array">Array to copy Items to.</param>
        /// <param name="arrayIndex">Index in Array at which Copy begins.</param>
        public void CopyTo(Item[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an Item from the Map.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>True if Item was removed, False otherwise.</returns>
        public virtual bool Remove(Item item)
        {
            Tile tile = item as Tile;
            Actor actor = item as Actor;
            Thing thing = item as Thing;
            if (tile != null)
                this.tiles.Remove(tile);
            else if (actor != null)
                this.actors.Remove(actor);
            else if (thing != null)
                this.things.Remove(thing);
            return this.items.Remove(item);
        }

        /// <summary>
        /// Retrieves the Enumerator to iterate over the Map Items.
        /// </summary>
        /// <returns>Enumerator Instance.</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        /// <summary>
        /// Retrieves the Enumerator to iterate over the Map Items.
        /// </summary>
        /// <returns>Enumerator Instance.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        #region Properties

        /// <summary>
        /// Retrieves Tiles from the Map.
        /// </summary>
        public ObservableCollection<Tile> Tiles
        {
            get { return this.tiles; }
        }

        /// <summary>
        /// Retrieves Actors from the Map.
        /// </summary>
        public ObservableCollection<Actor> Actors
        {
            get { return this.actors; }
        }

        /// <summary>
        /// Retrieves Things from the Map.
        /// </summary>
        public ObservableCollection<Thing> Things
        {
            get { return this.things; }
        }

        /// <summary>
        /// Retrieves the Number of Items on the Map.
        /// </summary>
        public int Count
        {
            get { return this.items.Count; }
        }

        /// <summary>
        /// Retrieves whether the Map is a read only Collection.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region Fields
        private readonly IList<Item> items = new List<Item>();
        private readonly ObservableCollection<Tile> tiles = new ObservableCollection<Tile>();
        private readonly ObservableCollection<Actor> actors = new ObservableCollection<Actor>();
        private readonly ObservableCollection<Thing> things = new ObservableCollection<Thing>();

        #endregion
    }
}
