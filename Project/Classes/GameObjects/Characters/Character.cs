using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
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
    internal class Character : IGameObject, IMovable, ICollidable
    {
        protected Texture2D texture;
        protected Animation animation;


        public IInputReader InputReader { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public Vector2 Size { get; set; }

        // scale adjusted for testing on my screen
        private float scale;

        public CollisionBox BoxCollision { get; set; }

        public Character(Texture2D texture, int spriteColumns, int spriteRows, float scale, Vector2 position, Vector2 speed, Texture2D blockTexture)
        {
            this.texture = texture;
            this.scale = scale;

            Position = position;
            Speed = speed;

            

            animation = new Animation();
            animation.LoadFramesFromSpriteSheet(texture.Width, texture.Height, spriteColumns, spriteRows);

            this.Size = animation.getFrameSize(texture.Width, texture.Height, spriteColumns, spriteRows);

            BoxCollision = new CollisionBox(Position, scale * Size, blockTexture); 
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            BoxCollision.Update(gameTime, this.Position);
       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            BoxCollision.Draw(spriteBatch);
            // TODO: other things also needs drawing? move draw from character to abstract spriteDrawer class? 
            
        }
    }
}
