using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class Character : IGameObject
    {
        protected Texture2D texture;
        protected Animation animation;

        protected Vector2 Position { get; set; } 
        protected Vector2 Speed { get; set; }


        // scale adjusted for testing on my screen
        private float scale;

        public Character(Texture2D texture, int numberOfSprites, Vector2 position, float scale)
        {
            this.texture = texture;
            this.Position = position;
            this.scale = scale;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, numberOfSprites, 1); // TODO: variable numberOfFrames

            Speed = new Vector2(0.5f, 0.5f);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
