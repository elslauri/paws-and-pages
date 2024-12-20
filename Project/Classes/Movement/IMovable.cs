using Microsoft.Xna.Framework;
using Project.Classes.Input;

namespace Project.Classes.Movement
{
    internal interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; } 
    }
}
