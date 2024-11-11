using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class Character : IGameObject
    {
        private Texture2D texture;
        Animation animation;

        private Vector2 startPos;

        // scale adjusted for testing on my screen
        private float scale;

        public Character(Texture2D texture, float scale, Vector2 startPos)
        {
            this.texture = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1);
            this.scale = scale;
            this.startPos = startPos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, startPos, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
