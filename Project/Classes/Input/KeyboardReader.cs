using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Project.Classes.Input
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                direction.X += 1;
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                direction.Y += 1;
            if (direction != null)
            {
                direction.Normalize();
            }
            return direction;
        }
    }
}
