using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class NPC : Character
    {
       
        public NPC(Texture2D texture, int numberOfSprites, Vector2 position,float scale) : base(texture, numberOfSprites, position, scale)
        {
            base.Speed = new Vector2(0.5f, 0.5f);
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move(Position, Speed);
        }

        private void Move(Vector2 position, Vector2 speed)
        {
            Position += speed;
            // TODO: collision box
            if (position.X > 1600 - base.texture.Height || position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y > 960 - base.texture.Width / 8 || position.Y < 0)
            {
                speed.Y *= -1;
            }
        }
    }
}
