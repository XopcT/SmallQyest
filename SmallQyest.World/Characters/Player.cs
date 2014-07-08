
namespace SmallQyest.World.Characters
{
    /// <summary>
    /// Character controller by the Player.
    /// </summary>
    public class Player : CharacterBase
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
