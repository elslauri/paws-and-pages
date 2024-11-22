using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Input;
using Project.Classes.Movement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects.Characters
{
    internal class Character : IGameObject, IMovable
    {
        protected Texture2D texture;
        protected Animation animation;


        public IInputReader InputReader { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }


        // scale adjusted for testing on my screen
        private float scale;

        public Character(Texture2D texture, int numberOfSprites, float scale, Vector2 position, Vector2 speed)
        {
            this.texture = texture;
            this.scale = scale;

            Position = position;
            Speed = speed;

            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, numberOfSprites, 1);


        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            // TODO: other things also needs drawing? move draw from character to abstract spriteDrawer class? 

        }
    }
}
