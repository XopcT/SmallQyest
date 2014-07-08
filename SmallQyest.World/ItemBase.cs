using SmallQyest.Core;

namespace SmallQyest.World
{
    /// <summary>
    /// Base Class for all Items.
    /// </summary>
    public class ItemBase : IItem
    {
        /// <summary>
        /// Initializes the Item.
        /// </summary>
        public virtual void Initialize()
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Updates the State of the Item.
        /// </summary>
        public virtual void Update()
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Checks whether an Item can be passed by another Item.
        /// </summary>
        /// <param name="item">Item to check with.</param>
        /// <returns>True if an Item can be passed, False otherwise.</returns>
        public virtual bool CanPassThroug(IItem item)
        {
            // An Item may be passed by any other Item by default:
            return true;
        }

        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public virtual void OnVisit(IItem item)
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Handles Leaving of this Item by another one.
        /// </summary>
        /// <param name="item">Item that lived.</param>
        public virtual void OnLeave(IItem item)
        {
            // Nothing needs to be done in current Context.
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Map the Item belongs to.
        /// </summary>
        public IMap Map { get; set; }

        /// <summary>
        /// Retrieves the Level the Item belongs to.
        /// </summary>
        protected ILevel Level
        {
            get { return this.Map.Level; }
        }

        /// <summary>
        /// Sets/retrieves the Item's X-Coordinate on the Map.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Sets/retrieves the Item's Y-Coordinate on the Map.
        /// </summary>
        public int Y { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
