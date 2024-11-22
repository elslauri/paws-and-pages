using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Background
{
    internal class Floor : IGameObject
    {
        private Texture2D texture;
        private Vector2 position;

        private float scale;

        // TODO: refactor everything that needs to be drawn with / without animation
        public Floor(Texture2D texture, float scale, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, 16, 16), Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

       
    }
}
