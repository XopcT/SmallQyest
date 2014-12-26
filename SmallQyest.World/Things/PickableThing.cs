using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// Base Class for Things which can be picked up by someone.
    /// </summary>
    /// <typeparam name="PickerType">Type of a Character which can pick up this Thing.</typeparam>
    public class PickableThing<PickerType> : Thing
        where PickerType : Character
    {
        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);
            PickerType picker = item as PickerType;
            if (picker != null)
            {
                this.Map.Remove(this);
                picker.Inventory.Add(this);
            }
        }
    }
}
