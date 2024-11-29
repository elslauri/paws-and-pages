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
    internal class Character : IGameObject, IMovable, ICollidable, Animations.IDrawable
    {
        public Texture2D Texture { get; }

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public Color Color { get; }
        public float Rotation { get; }
        public Vector2 Origin { get; }

        public Rectangle SourceRectangle { get; }
        public Vector2 Size { get; set; }


        // scale adjusted for testing on my screen
        public float Scale { get; }


        protected AnimationManager animation;

        public IInputReader InputReader { get; set; }

        public CollisionBox BoxCollision { get; set; }

        

        public Character(Texture2D texture, int spriteColumns, int spriteRows, float scale, Vector2 position, Vector2 speed, Texture2D blockTexture)
        {
            this.Texture = texture;
            this.Scale = scale;

            Position = position;
            Speed = speed;

            
            animation = new AnimationManager();
            animation.LoadFramesFromSpriteSheet(texture.Width, texture.Height, spriteColumns, spriteRows);

            SourceRectangle = animation.CurrentFrame.SourceRectangle;

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
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
            BoxCollision.Draw(spriteBatch);
            // TODO: other things also needs drawing? move draw from character to abstract spriteDrawer class? 
            
        }
    }
}
