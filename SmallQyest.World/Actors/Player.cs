using System.Collections.Generic;

namespace SmallQyest.World.Actors
{
    /// <summary>
    /// Character controller by the Player.
    /// </summary>
    public class Player : Character
    {
        /// <summary>
        /// Kills the Player.
        /// </summary>
        public override void Kill()
        {
            base.Kill();
            base.Level.Fail();
        }

    }
}
