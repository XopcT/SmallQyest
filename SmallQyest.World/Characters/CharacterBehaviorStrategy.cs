
namespace SmallQyest.World.Characters
{
    /// <summary>
    /// Base Class for Character Behavior Strategy.
    /// </summary>
    public class CharacterBehaviorStrategy
    {
        /// <summary>
        /// Selects a Direction for a Character.
        /// </summary>
        /// <param name="character">Character to navigate.</param>
        public virtual void Navigate(CharacterBase character)
        {
        }

        /// <summary>
        /// Moves a Character over the Map.
        /// </summary>
        /// <param name="character">Character to move.</param>
        public virtual void Move(CharacterBase character)
        {
        }
    }
}
