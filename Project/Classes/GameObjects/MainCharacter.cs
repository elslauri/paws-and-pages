using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Classes.Input;

namespace Project.Classes.GameObjects
{
    internal class MainCharacter : Character
    {
        private IInputReader inputReader;
        
        public MainCharacter(IInputReader inputReader,Texture2D texture, float scale, Vector2 startPos) : base(texture, scale, startPos)
        {
            this.inputReader = inputReader; 
        }
        
        public void Update(GameTime gametime)
        {
            var direction = inputReader.ReadInput();
            direction *= base.Speed;
            base.Position += direction;

            base.Update(gametime);
        }
    }
}
