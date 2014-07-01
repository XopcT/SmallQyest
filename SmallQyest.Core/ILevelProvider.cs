using System.Threading.Tasks;

namespace SmallQyest.Core
{
    /// <summary>
    /// Defines an Interface which retrieves Game Levels.
    /// </summary>
    public interface ILevelProvider
    {
        /// <summary>
        /// Asynchronously loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        Task<Level> LoadLevelAsync(int levelId);
    }
}
