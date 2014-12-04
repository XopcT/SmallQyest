using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmallQyest.World;
using SmallQyest.World.Triggers;
using SmallQyest.World.Things;

namespace SmallQyest
{
    /// <summary>
    /// Level Factory for Test Purposes.
    /// </summary>
    public class MockLevelProvider : ILevelProvider
    {
        /// <summary>
        /// Loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public Level LoadLevel(int levelId)
        {
            switch (levelId)
            {
                case 1: return this.LoadLevel1();
                case 2: return this.LoadLevel2();
                case 3: return this.LoadLevel3();
                default:
                    throw new ArgumentException("levelId");
            }
        }

        private Level LoadLevel1()
        {
            return this.LevelSerializer.Deserialize(
                "◘◘≡≡••\n" +
                "██████████\n" +
                "██████   █\n" +
                "█   ██ █ █\n" +
                "█ █ ██ █ █\n" +
                "█      █ █\n" +
                "███ ████ █\n" +
                "███ ████ █\n" +
                " ☺   ███ █\n" +
                "████████ b\n" +
                "██████████");
        }

        private Level LoadLevel2()
        {
            return this.LevelSerializer.Deserialize(
                "◘◘≡≡••\n" +
                "██████████\n" +
                "██ ███████\n" +
                "██ ███████\n" +
                "██ ███████\n" +
                "██ ██   ██\n" +
                "██    █  c\n" +
                "██ ███████\n" +
                "☺  ███████\n" +
                "██ ███████\n" +
                "██████████");
        }

        private Level LoadLevel3()
        {
            return this.LevelSerializer.Deserialize(
                "◘◘≡≡••\n" +
                "██████████\n" +
                "██████████\n" +
                "██████████\n" +
                "██████████\n" +
                "██████████\n" +
                " ☺    ◘  a\n" +
                "██████████\n" +
                "██████████\n" +
                "██████████\n" +
                "██████████");
        }

        /// <summary>
        /// Asynchronously loads the specified Level.
        /// </summary>
        /// <param name="levelId">ID of the Level to load.</param>
        /// <returns>Loaded Level Instance.</returns>
        public Task<Level> LoadLevelAsync(int levelId)
        {
            throw new NotImplementedException();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Level Serialization Service.
        /// </summary>
        public ILevelSerializationService LevelSerializer { get; set; }

        #endregion
    }
}
