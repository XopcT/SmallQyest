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
        Item GetPlayer();

        /// <summary>
        /// Retrieves a Grass Item.
        /// </summary>
        /// <returns>Grass Instance.</returns>
        Item GetGrass();

        /// <summary>
        /// Retrieves a Path Item.
        /// </summary>
        /// <returns>Path Instance.</returns>
        Item GetPath();

        /// <summary>
        /// Retrieves a Trigger which starts the Level.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        Item GetLevelStartTrigger();

        /// <summary>
        /// Retrieves a Trigger which ends the Level.
        /// </summary>
        /// <returns>Trigger Instance.</returns>
        Item GetLevelEndTrigger();

        /// <summary>
        /// Retrieves a Fall Trap.
        /// </summary>
        /// <returns>Fall Trap Instance.</returns>
        Item GetFallTrap();

        /// <summary>
        /// Retrieves a one Time pass Obstacle.
        /// </summary>
        /// <returns>One Time pass Obstacle Instance.</returns>
        Item GetOneTimePassObstacle();

        /// <summary>
        /// Retrieves a moveable Obstacle.
        /// </summary>
        /// <returns>Moveable Obstacle Instance.</returns>
        Item GetMoveableObstacle();
    }
}
