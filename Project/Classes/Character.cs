using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    internal class Character : IGameObject
    {
        private Texture2D texture;
        private Vector2 startPos = new Vector2(0, 0);
        private Rectangle rectangle;
        private int moveX = 0;

        // scale adjusted for testing on my screen
        private float scale = 3f;

        public Character(Texture2D texture)
        {
            this.texture = texture;
            rectangle = new Rectangle(moveX, 0, 32, 32);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, startPos, rectangle, Color.White, 0f,Vector2.Zero, scale, SpriteEffects.None, 0f );
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
