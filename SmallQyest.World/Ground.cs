using SmallQyest.Core;

namespace SmallQyest.World
{
    /// <summary>
    /// Represents a Ground on the Map.
    /// </summary>
    public class Ground : ItemBase
    {
        /// <summary>
        /// Checks whether the Ground can be passed by a Character.
        /// </summary>
        /// <returns>True if Ground can be passed, False otherwise.</returns>
        public virtual bool CanPassThrough()
        {
            // Most of the Grounds can not be passed. False is default Value:
            return false;
        }

        #region Properties

        #endregion

        #region Fields

        #endregion
    }
}
