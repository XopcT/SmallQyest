using SmallQyest.World;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of a Factory which creates Items for the Game World.
    /// </summary>
    public interface IItemFactory
    {
        /// <summary>
        /// Retrieves a Level.
        /// </summary>
        /// <returns>Level Instance.</returns>
        ILevel GetLevel();

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

        /// <summary>
        /// Retrieves a Fall Trap.
        /// </summary>
        /// <returns>Fall Trap Instance.</returns>
        IItem GetFallTrap();

        /// <summary>
        /// Retrieves a one Time pass Obstacle.
        /// </summary>
        /// <returns>One Time pass Obstacle Instance.</returns>
        IItem GetOneTimePassObstacle();

        /// <summary>
        /// Retrieves a moveable Obstacle.
        /// </summary>
        /// <returns>Moveable Obstacle Instance.</returns>
        IItem GetMoveableObstacle();
    }
}
