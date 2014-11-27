using System.Collections.Generic;
using System.Linq;
using Logging;

namespace SmallQyest.World
{
    /// <summary>
    /// Contains a Level Map.
    /// </summary>
    public class GameMap : IMap
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public GameMap()
        {
            this.items = new List<IItem>();
        }

        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        public void Update()
        {
            this.Logger.LogMessage("Updating Map.");
            foreach (IItem item in this.items)
            {
                item.Update();
            }
            this.Logger.LogMessage("Map updated.");
        }

        /// <summary>
        /// Adds Item on the Map.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Add(IItem item)
        {
            this.items.Add(item);
            this.Logger.LogMessage("{0} added to Map.", item);
        }

        /// <summary>
        /// Removes all Items from the Map.
        /// </summary>
        public void Clear()
        {
            foreach (IItem item in this.items.ToArray())
            {
                this.Remove(item);
            }
        }

        /// <summary>
        /// Checks whether Map contains specified Item.
        /// </summary>
        /// <param name="item">Item to check.</param>
        /// <returns>True if Map contains the Item, False otherwise.</returns>
        public bool Contains(IItem item)
        {
            return this.items.Contains(item);
        }

        /// <summary>
        /// Copies the Items from the Map and Array, starting at a particular Index.
        /// </summary>
        /// <param name="array">Array to copy Items to.</param>
        /// <param name="arrayIndex">Index in Array at which Copy begins.</param>
        public void CopyTo(IItem[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes an Item from the Map.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>True if Item was removed, False otherwise.</returns>
        public bool Remove(IItem item)
        {
            try
            {
                return this.items.Remove(item);
            }
            finally
            {
                this.Logger.LogMessage("{0} removed from Map.", item);
            }
        }

        /// <summary>
        /// Retrieves the Enumerator to iterate over the Map Items.
        /// </summary>
        /// <returns>Enumerator Instance.</returns>
        public IEnumerator<IItem> GetEnumerator()
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
            get { return this.items.IsReadOnly; }
        }

        /// <summary>
        /// Sets/retrieves a Logger for Map Messages.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Fields
        private readonly IList<IItem> items = null;

        #endregion

    }
}
