using System.Collections.Generic;
using System.Linq;

namespace SmallQyest.World.Characters
{
    /// <summary>
    /// The most simple Behavior Strategy to move a Character over the Map.
    /// </summary>
    public class BasicMovementStrategy : CharacterBehaviorStrategy
    {
        /// <summary>
        /// Selectes a Direction for a Character.
        /// </summary>
        /// <param name="character">Character to navigate.</param>
        public override void Navigate(CharacterBase character)
        {
            // Checking if a Character can keep moving forward:
            if (!character.CanGoTo(character.Direction))
            {
                // Trying to turn right or left:
                Vector right = character.Direction.GetRight();
                Vector left = character.Direction.GetLeft();

                // Trying to turn right:
                if (character.CanGoTo(right))
                    character.Direction = right;
                // Trying to go left:
                else if (character.CanGoTo(left))
                    character.Direction = left;
                // Going back:
                else
                    character.Direction = character.Direction.GetBackward();
            }
        }

        /// <summary>
        /// Moves a Character over the Map.
        /// </summary>
        /// <param name="character">Character to move.</param>
        public override void Move(CharacterBase character)
        {
            if (character.Direction.X == Vector.Left.X && character.Direction.Y == Vector.Left.Y)
                character.CurrentState = "MoveLeft";
            else if (character.Direction.X == Vector.Up.X && character.Direction.Y == Vector.Up.Y)
                character.CurrentState = "MoveUp";
            else if (character.Direction.X == Vector.Right.X && character.Direction.Y == Vector.Right.Y)
                character.CurrentState = "MoveRight";
            else if (character.Direction.X == Vector.Down.X && character.Direction.Y == Vector.Down.Y)
                character.CurrentState = "MoveDown";
            else
                throw new System.InvalidOperationException();
            // Leaving previous Location:
            foreach (Item item in character.Map.GetItems<Item>(character.Position))
                item.OnLeave(character);
            // Updating Coordinates:
            character.Position += character.Direction;
        }

    }
}
