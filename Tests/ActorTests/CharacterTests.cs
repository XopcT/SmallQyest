using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallQyest.World.Actors;
using SmallQyest.World.Things;

namespace Tests.ActorTests
{
    /// <summary>
    /// Contains Tests for Characters.
    /// </summary>
    [TestClass()]
    public class CharacterTests
    {
        /// <summary>
        /// Tests the Character.Has Method.
        /// </summary>
        [TestMethod()]
        public void CharacterInventoryTest1()
        {
            Character tested = new Character();

            Assert.IsFalse(tested.Has<Bonus>());
            tested.Inventory.Add(new Bonus());
            Assert.IsTrue(tested.Has<Bonus>());
        }

        /// <summary>
        /// Tests the Character.Has Method.
        /// </summary>
        [TestMethod()]
        public void CharacterInventoryTest2()
        {
            Character tested = new Character();

            tested.Inventory.Add(new ColoredKey() { Color = ItemColor.Green });
            Assert.IsFalse(tested.Has<ColoredKey>(key => key.Color == ItemColor.Blue));
            Assert.IsTrue(tested.Has<ColoredKey>(key => key.Color == ItemColor.Green));
        }

        #region Properties

        #endregion

        #region Fields

        #endregion
    }
}
