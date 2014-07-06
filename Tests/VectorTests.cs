using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallQyest.World;

namespace Tests
{
    /// <summary>
    /// Contains Tests for the Vector.
    /// </summary>
    [TestClass()]
    public class VectorTests
    {
        /// <summary>
        /// Tests computing the forward Vector.
        /// </summary>
        [TestMethod()]
        public void GetForwardTest()
        {
            this.Compare(Vector.Up, Vector.Up.GetForward());
            this.Compare(Vector.Right, Vector.Right.GetForward());
            this.Compare(Vector.Down, Vector.Down.GetForward());
            this.Compare(Vector.Left, Vector.Left.GetForward());
        }

        /// <summary>
        /// Tests computing the right Vector.
        /// </summary>
        [TestMethod()]
        public void GetRightTest()
        {
            this.Compare(Vector.Right, Vector.Up.GetRight());
            this.Compare(Vector.Down, Vector.Right.GetRight());
            this.Compare(Vector.Left, Vector.Down.GetRight());
            this.Compare(Vector.Up, Vector.Left.GetRight());
        }

        /// <summary>
        /// Tests computing the left Vector.
        /// </summary>
        [TestMethod()]
        public void GetLeftTest()
        {
            this.Compare(Vector.Left, Vector.Up.GetLeft());
            this.Compare(Vector.Down, Vector.Left.GetLeft());
            this.Compare(Vector.Right, Vector.Down.GetLeft());
            this.Compare(Vector.Up, Vector.Right.GetLeft());
        }

        /// <summary>
        /// Tests computing the backward Vector.
        /// </summary>
        [TestMethod()]
        public void GetBackwardTest()
        {
            this.Compare(Vector.Down, Vector.Up.GetBackward());
            this.Compare(Vector.Left, Vector.Right.GetBackward());
            this.Compare(Vector.Up, Vector.Down.GetBackward());
            this.Compare(Vector.Right, Vector.Left.GetBackward());
        }

        /// <summary>
        /// Compares two Vectors.
        /// </summary>
        /// <param name="expected">Vector with expected Coordinates.</param>
        /// <param name="computed">Computed Vector to compare.</param>
        private void Compare(Vector expected, Vector computed)
        {
            Assert.AreEqual(expected.X, computed.X);
            Assert.AreEqual(expected.Y, computed.Y);
        }
    }
}
