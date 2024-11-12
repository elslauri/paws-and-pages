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

        public Vector2 Position { get; set; } 
        public Vector2 Speed { get; set; }


        // scale adjusted for testing on my screen
        private float scale;

        public Character(Texture2D texture, float scale, Vector2 position)
        {
            this.texture = texture;
            this.scale = scale;
            this.Position = position;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 8, 1); // TODO: variable numberOfFrames

            Speed = new Vector2(1, 1);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            //Move(Position, Speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        

        private void Move(Vector2 position, Vector2 speed)
        {
            Position += speed;
            // TODO: collision box
            if (position.X > 1600 - texture.Height || position.X < 0) 
            {
                speed.X *= -1;
            }
            if (position.Y > 960 - texture.Width/8 || position.Y < 0)
            {
                speed.Y *= -1;
            }
        }
    }
}
