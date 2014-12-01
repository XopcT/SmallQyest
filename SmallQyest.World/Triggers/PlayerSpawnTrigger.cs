using SmallQyest.World.Actors;

namespace SmallQyest.World.Triggers
{
    public class PlayerSpawnTrigger : Trigger
    {
        /// <summary>
        /// Initializes the Trigger.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            if (!base.Map.Contains(this.player))
                base.Map.Add(this.player);
            this.player.Position = this.Position;
            this.player.Direction = Vector.Right;
        }

        #region Properties

        #endregion

        #region Fields
        private Player player = new Player();

        #endregion
    }
}
