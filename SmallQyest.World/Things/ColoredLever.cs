using System.Linq;
using SmallQyest.World.Actors;

namespace SmallQyest.World.Things
{
    /// <summary>
    /// A Lever of the specified Color.
    /// </summary>
    public class ColoredLever : Thing
    {
        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public override void OnVisit(Item item)
        {
            base.OnVisit(item);

            // Only Characters can switch the Levers:
            if (!(item is Character))
                return;

            // Looking for a Door with the same Color:
            ColoredDoor targetDoor = this.Map.GetItems<ColoredDoor>()
                .Where(door => door.Color == this.Color)
                .FirstOrDefault();

            if (targetDoor != null)
            {
                // Opening the Door if it is closed, and closing it if it is opened:
                if (targetDoor.IsOpen)
                    targetDoor.Close();
                else
                    targetDoor.Open();
            }
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Color of the Lever.
        /// </summary>
        public ItemColor Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
                base.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private ItemColor color = ItemColor.Red;

        #endregion
    }
}
