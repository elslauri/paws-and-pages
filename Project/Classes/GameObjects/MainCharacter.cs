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
        
        public MainCharacter(IInputReader inputReader,Texture2D texture, int numberOfSprites, Vector2 startPos, float scale) : base(texture, numberOfSprites,startPos, scale)
        {
            this.inputReader = inputReader;
            base.Speed = new Vector2(2, 2);
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
