using SmallQyest.Core;

namespace SmallQyest.World
{
    /// <summary>
    /// Base Class for World Items.
    /// </summary>
    public class WorldItem : ItemBase
    {
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
    }
}
