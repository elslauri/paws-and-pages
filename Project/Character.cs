using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Character : IGameObject
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int moveX = 0;

        public Character(Texture2D texture)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(moveX, 0, 32, 32);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), rectangle, Color.White);
        }

        public void Update()
        {
            moveX += 32;
            if (moveX > 256)
            {
                moveX = 0;
            }
            rectangle.X = moveX;
        }
    }
}
