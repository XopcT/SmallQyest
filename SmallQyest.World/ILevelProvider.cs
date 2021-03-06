﻿using System.Threading.Tasks;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of a Factory which retrieves Game Levels.
    /// </summary>
    public interface ILevelProvider
    {
        /// <summary>
        /// Loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        Level LoadLevel(int levelId);

        /// <summary>
        /// Asynchronously loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        Task<Level> LoadLevelAsync(int levelId);
    }
}
