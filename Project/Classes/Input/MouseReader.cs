using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Input
{
    internal class MouseReader : IInputReader
    {
        // TODO: change into a script that follows the main character (friend)
        public Vector2 ReadInput()
        {
            MouseState state = Mouse.GetState();
            Vector2 mouseVector = new Vector2(state.X, state.Y);

            if (mouseVector != Vector2.Zero)
            {
                mouseVector.Normalize();
            }
            return mouseVector;
        }
    }
}
