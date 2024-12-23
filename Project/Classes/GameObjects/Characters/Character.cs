using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Background;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters
{
    internal class Character : IGameObject, IMovable, ICollidable, IDraw
    {
        #region members

        public Sprite Sprite { get; set; } // TODO: use this instead of all the below? 
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
        public List<ICollidable> obstacles;

        #endregion


        public Character(Texture2D texture, int spriteColumns, int spriteRows, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture)
        {
            this.Texture = texture;
            this.Scale = scale;

            Position = position;
            Speed = speed;

            //Origin = new Vector2(texture.Width / 2, texture.Height /2);
            Origin = new Vector2(0, 0);


            animation = new AnimationManager();
            animation.LoadFramesFromSpriteSheet(texture.Width, texture.Height, spriteColumns, spriteRows);

            SourceRectangle = animation.CurrentFrame.SourceRectangle;

            this.Size = animation.getFrameSize(texture.Width, texture.Height, spriteColumns, spriteRows);

            BoxCollision = new CollisionBox(Position, scale * Size, blockTexture);
            this.obstacles = obstacles;
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            BoxCollision.Update(gameTime, this.Position);
       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White, 0f, Origin, Scale, SpriteEffects.None, 0f);
            // BoxCollision.Draw(spriteBatch); // TODO: remove after testing
            BoxCollision.Draw(spriteBatch);
        }
    }
}
