using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SmallQyest.World
{
    /// <summary>
    /// Base Class for all Items.
    /// </summary>
    public class Item : INotifyPropertyChanged
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
        public virtual bool CanPassThrough(Item item)
        {
            // An Item may be passed by any other Item by default:
            return true;
        }

        /// <summary>
        /// Handles Collision of this Item against another one.
        /// </summary>
        /// <param name="item">Collider Item.</param>
        public virtual void OnVisit(Item item)
        {
            // Nothing needs to be done in current Context.
        }

        /// <summary>
        /// Handles Leaving of this Item by another one.
        /// </summary>
        /// <param name="item">Item that lived.</param>
        public virtual void OnLeave(Item item)
        {
            // Nothing needs to be done in current Context.
        }

        #region Events

        /// <summary>
        /// Occurs when Property Value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged Event.
        /// </summary>
        protected void OnPropertyChanged(object sender, [CallerMemberName()]string propertyName = "")
        {
            var temp = this.PropertyChanged;
            if (temp != null)
                temp(sender, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets/retrieves the Level the Item belongs to.
        /// </summary>
        public ILevel Level { get; set; }

        /// <summary>
        /// Retrieves the Map the Item belongs to.
        /// </summary>
        public Map Map
        {
            get { return this.Level.Map; }
        }

        /// <summary>
        /// Sets/retrieves the Item's Position on the Map.
        /// </summary>
        public Vector Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                this.OnPropertyChanged(this);
            }
        }

        #endregion

        #region Fields
        private Vector position = Vector.Zero;

        #endregion
    }
}
