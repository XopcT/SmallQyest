using Logging;

namespace SmallQyest.World
{
    /// <summary>
    /// Level Map with Debug Information.
    /// </summary>
    public class DebugMap : Map
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="logger">Logger for Map Messages</param>
        public DebugMap(ILogger logger)
        {
            this.Logger = logger;
            this.Logger.LogMessage("Map created");
        }

        /// <summary>
        /// Updates the State of the Map.
        /// </summary>
        public override void Update()
        {
            this.Logger.LogMessage("Updating Map...");
            base.Update();
            this.Logger.LogMessage("Map updated");
        }

        /// <summary>
        /// Adds Item on the Map.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public override void Add(Item item)
        {
            base.Add(item);
            this.Logger.LogMessage("{0} added to the Map", item);
        }

        /// <summary>
        /// Removes an Item from the Map.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>True if Item was removed, False otherwise.</returns>
        public override bool Remove(Item item)
        {
            bool result = base.Remove(item);
            this.Logger.LogMessage("{0} removed from the Map", item);
            return result;
        }

        #region Properties

        /// <summary>
        /// Retrieves a Logger for Map Messages.
        /// </summary>
        public ILogger Logger { get; private set; }

        #endregion
    }
}
