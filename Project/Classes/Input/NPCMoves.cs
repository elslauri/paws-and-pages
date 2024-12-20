using Microsoft.Xna.Framework;

namespace Project.Classes.Input
{
    internal class NPCMoves : IInputReader
    {
        public Vector2 ReadInput()
        {
            // TODO:create input for npc to move
            return new Vector2(800, 480);
        }
    }
}
