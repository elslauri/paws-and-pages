using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects.Items
{
    internal class Block : IGameObject
    {
        private Texture2D blockTexture;
        private Rectangle rectangle;
        private Vector2 position;

        public Block(Texture2D blockTexture, Rectangle rectangle, Vector2 position)
        {
            this.blockTexture = blockTexture;
            this.rectangle = rectangle;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void Update(GameTime gameTime)
        {
          //  throw new NotImplementedException();
        }
    }
}
