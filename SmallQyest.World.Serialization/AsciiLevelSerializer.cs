using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmallQyest.World.Serialization
{
    public class AsciiLevelSerializer : ILevelSerializationService
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="itemFactory">Factory for Map Items.</param>
        public AsciiLevelSerializer(IItemFactory itemFactory)
        {
            if (itemFactory == null)
                throw new ArgumentNullException("itemFactory");
            this.itemFactory = itemFactory;
            this.Register('☺', () => this.itemFactory.GetLevelStartTrigger());
            this.Register('█', () => this.itemFactory.GetGrass());
            this.Register(' ', () => this.itemFactory.GetPath());
            this.Register('•', () => this.itemFactory.GetMoveableObstacle());
            this.Register('≡', () => this.itemFactory.GetOneTimePassObstacle());
            this.Register('◘', () => this.itemFactory.GetFallTrap());
            this.Register('a', () => { var item = (Triggers.LevelEndTrigger)this.itemFactory.GetLevelEndTrigger(); item.NextLevelIndex = 1; return item; });
            this.Register('b', () => { var item = (Triggers.LevelEndTrigger)this.itemFactory.GetLevelEndTrigger(); item.NextLevelIndex = 2; return item; });
            this.Register('c', () => { var item = (Triggers.LevelEndTrigger)this.itemFactory.GetLevelEndTrigger(); item.NextLevelIndex = 3; return item; });
        }

        /// <summary>
        /// Retrieves a String Representation of a Level.
        /// </summary>
        /// <param name="level">Level to serialize.</param>
        /// <returns>String Representation of a Level.</returns>
        public string Serialize(Level level)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Item item in level.Tools)
            {
                builder.Append(this.ItemToCode(item));
            }
            builder.AppendLine();
            for (int y = 0; y <= level.Map.GetHeight(); ++y)
            {
                for (int x = 0; x <= level.Map.GetWidth(); ++x)
                {
                    builder.Append(this.ItemsToCode(level.Map.GetItems(new Vector(x, y))));
                }
                builder.AppendLine();
            }
            string result = builder.ToString();
            return result;
        }

        /// <summary>
        /// Deserializes a Level.
        /// </summary>
        /// <param name="source">String to deserialize a Level from.</param>
        /// <returns>Deserialized Level Instance.</returns>
        public Level Deserialize(string source)
        {
            Level level = this.itemFactory.GetLevel();
            using (StringReader reader = new StringReader(source))
            {
                // Deserializing Tools:
                string tools = reader.ReadLine();
                foreach (char code in tools)
                {
                    level.Tools.Add(this.CodeToItem(code));
                }
                // Deserializing Map:
                int y = -1;
                string nextLine = string.Empty;
                while (true)
                {
                    ++y;
                    nextLine = reader.ReadLine();
                    if (string.IsNullOrEmpty(nextLine))
                        break;
                    int x = 0;
                    foreach (char code in nextLine)
                    {
                        Item item = this.CodeToItem(code);
                        item.Position = new Vector(x, y);
                        level.Map.Add(item);
                        if (!(item is Tiles.Tile))
                        {
                            Item tile = this.itemFactory.GetPath();
                            tile.Position = new Vector(x, y);
                            level.Map.Add(tile);
                        }
                        ++x;
                    }
                }
            }
            return level;
        }

        /// <summary>
        /// Maps a Char to an Item Constructor.
        /// </summary>
        /// <typeparam name="T">Type of Item.</typeparam>
        /// <param name="code">Character Code.</param>
        /// <param name="creationFunc">Item Constructor.</param>
        private void Register<T>(char code, Func<T> creationFunc)
            where T : Item
        {
            this.codeToItem.Add(code, creationFunc);
        }

        private Item CodeToItem(char code)
        {
            return this.codeToItem[code]();
        }

        private char ItemsToCode(IEnumerable<Item> items)
        {
            Triggers.Trigger trigger = items.Where(item => item is Triggers.Trigger).Cast<Triggers.Trigger>().FirstOrDefault();
            Actors.Actor actor = items.Where(item => item is Actors.Actor).Cast<Actors.Actor>().FirstOrDefault();
            Things.Thing thing = items.Where(item => item is Things.Thing).Cast<Things.Thing>().FirstOrDefault();
            Tiles.Tile tile = items.Where(item => item is Tiles.Tile).Cast<Tiles.Tile>().FirstOrDefault();
            if (trigger != null) return this.ItemToCode(trigger);
            if (actor != null) return this.ItemToCode(actor);
            if (thing != null) return this.ItemToCode(thing);
            if (tile != null) return this.ItemToCode(tile);
            throw new ArgumentException();
        }

        private char ItemToCode(Item item)
        {
            char code = this.codeToItem
                .Where(arg => this.Compare(item, arg.Value()) == true)
                .Select(arg => arg.Key)
                .FirstOrDefault();
            return code;
        }

        private bool Compare(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;
            if (obj1.GetType() != obj2.GetType())
                return false;

            IEnumerable<PropertyInfo> properties = obj1.GetType().GetTypeInfo().DeclaredProperties
                .Where(property => property.Name != "Level" && property.Name != "Map" && property.Name != "Position" && property.Name != "Origin");
            foreach (PropertyInfo property in properties)
            {
                object value1 = property.GetValue(obj1);
                object value2 = property.GetValue(obj2);
                if (!value1.Equals(value2))
                    return false;
            }
            return true;
        }

        #region Properties

        #endregion

        #region Fields
        private readonly IItemFactory itemFactory = null;
        private readonly IDictionary<char, Func<Item>> codeToItem = new Dictionary<char, Func<Item>>();
        private readonly IDictionary<Type, char> itemToCode = new Dictionary<Type, char>();

        #endregion
    }
}
