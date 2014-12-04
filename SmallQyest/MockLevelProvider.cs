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

        //private Level CreateLevel(int levelId, int[,] numericMap)
        //{
        //    // Measuring the Map:
        //    int width = numericMap.GetLength(1);
        //    int height = numericMap.GetLength(0);
        //    // Creating Level Instance:
        //    Level level = this.ItemFactory.GetLevel();
        //    level.Tools.Add(new FallTrap());
        //    level.Tools.Add(new FallTrap());
        //    level.Tools.Add(new OneTimePassObstacle());
        //    level.Tools.Add(new OneTimePassObstacle());
        //    level.Tools.Add(new MoveableObstacle());
        //    level.Tools.Add(new MoveableObstacle());

        //    // Creating Map Items:
        //    IEnumerable<Item> items = Enumerable.Range(0, width)
        //        .SelectMany(x => Enumerable.Range(0, height)
        //            .SelectMany(y => this.CreateItems(numericMap[y, x], x, y)));
        //    // Filling Map Items:
        //    foreach (Item item in items)
        //        level.Map.Add(item);

        //    // Customizing special Map Items:
        //    if (levelId == 3)
        //        levelId = 0;
        //    level.Map.GetItems<LevelEndTrigger>().FirstOrDefault().NextLevelIndex = (levelId + 1);
        //    string tmp = this.LevelSerializer.Serialize(level);
        //    return level;
        //}

        //private IEnumerable<Item> CreateItems(int value, int x, int y)
        //{
        //    if ((value & 1) == 1)
        //    {
        //        Item item = this.ItemFactory.GetPath();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //    else
        //    {
        //        Item item = this.ItemFactory.GetGrass();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //    if ((value & 2) == 2)
        //    {
        //        Item item = this.ItemFactory.GetLevelStartTrigger();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //        Item player = this.ItemFactory.GetPlayer();
        //        player.Position = new Vector(x, y);
        //    }
        //    if ((value & 4) == 4)
        //    {
        //        Item item = this.ItemFactory.GetLevelEndTrigger();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //    if ((value & 8) == 8)
        //    {
        //        Item item = this.ItemFactory.GetFallTrap();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //    if ((value & 16) == 16)
        //    {
        //        Item item = this.ItemFactory.GetOneTimePassObstacle();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //    if ((value & 32) == 32)
        //    {
        //        Item item = this.ItemFactory.GetMoveableObstacle();
        //        item.Position = new Vector(x, y);
        //        yield return item;
        //    }
        //}

        #region Properties

        /// <summary>
        /// Sets/retrieves a Factory which creates World Items.
        /// </summary>
        public IItemFactory ItemFactory { get; set; }

        /// <summary>
        /// Sets/retrieves a Level Serialization Service.
        /// </summary>
        public ILevelSerializationService LevelSerializer { get; set; }

        #endregion
    }
}
