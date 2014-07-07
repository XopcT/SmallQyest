using SmallQyest.Core;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of a Factory which creates Items for the Game World.
    /// </summary>
    public interface IItemFactory
    {
        /// <summary>
        /// Retrieves a Player Item.
        /// </summary>
        /// <returns>Player Instance.</returns>
        IItem GetPlayer();

        /// <summary>
        /// Retrieves a Grass Item.
        /// </summary>
        /// <returns>Grass Instance.</returns>
        IItem GetGrass();

        /// <summary>
        /// Retrieves a Path Item.
        /// </summary>
        /// <returns>Path Instance.</returns>
        IItem GetPath();

        /// <summary>
        /// Retrieves a Trigger which starts the Level.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        IItem GetLevelStartTrigger();

        /// <summary>
        /// Retrieves a Trigger which ends the Level.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        IItem GetLevelEndTrigger();
    }
}
