using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Visuals;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Project.Classes.GameObjects.Characters
{
    internal class Character : IGameObject, IMovable, ICollidable, IDraw
    {
        #region members

         
        // TODO: remove Texture from IDraw
        public Texture2D Texture { get; }  

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public Color Color { get; }
        public float Rotation { get; }
        public Vector2 Origin { get; }


        public float Scale { get; }



        protected AnimationManager animationManager;
        // TODO: make enum STATE
        private string currentState;

        public IInputReader InputReader { get; set; }

        public CollisionBox ColBox { get; set; }
        public List<ICollidable> obstacles;

        #endregion


        public Character(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture)
        {
            Scale = scale;

            Position = position;
            Speed = speed;

            //Origin = new Vector2(texture.Width / 2, texture.Height /2);
            Origin = new Vector2(0, 0);


            this.animationManager = animationManager; 
            currentState = "Idle";
            animationManager.SetAnimation(currentState);

            var size = animationManager.getCurrentFrameSize();
            ColBox = new CollisionBox(Position, scale * size, blockTexture);
            this.obstacles = obstacles;


        }

        public void Update(GameTime gameTime)
        {
            UpdateState();
            animationManager.SetAnimation(currentState);

            animationManager.Update(gameTime);
            ColBox.Update(gameTime, this.Position);

        }



        public void UpdateState()
        {
            currentState = IsMoving() ? "Run" : "Idle";
        }
         private bool IsMoving()
        {
            // TODO: ah yes faith programming
            return Speed.X > 0 && Speed.Y > 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Texture, Position, animationManager.GetCurrentFrameSourceRectangle(), Color.White, 0f, Origin, Scale, SpriteEffects.None, 0f);
            animationManager.Draw(spriteBatch, Position, Scale);

            // BoxCollision.Draw(spriteBatch); // TODO: remove after testing
            ColBox.Draw(spriteBatch); // TODO: remove after testing
        }
    }
}
