using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
