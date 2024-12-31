using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Visuals;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Characters
{
    internal class Character : IGameObject, IMovable, ICollidable, IDraw
    {
        #region members

         
        // TODO: remove Texture. Origin, Color, Rotation from IDraw
        public Texture2D Texture { get; }
        public Color Color { get; }
        public float Rotation { get; }
        public Vector2 Origin { get; }





        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }

        public float Scale { get; }



        protected AnimationManager animationManager;
        // TODO: make enum STATE
        private string currentState;
        protected IAnimationStrategy animationStrategy; 

        public IInputReader InputReader { get; set; }

        public CollisionBox ColBox { get; set; }
        public List<ICollidable> obstacles;

        #endregion


        public Character(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture, IAnimationStrategy animationStrategy = null)
        {
            Scale = scale;

            Position = position;
            Speed = speed;

           
            this.animationManager = animationManager; 
            this.animationStrategy = animationStrategy ?? new DefaultAnimationStrategy();
            currentState = "Idle";
            this.animationManager.SetAnimation(currentState);


            var size = this.animationManager.GetCurrentFrameSize();

            ColBox = new CollisionBox(Position, Scale * size, blockTexture);
            this.obstacles = obstacles;

        }

        public void Update(GameTime gameTime)
        {
            UpdateState();
            animationStrategy.SetAnimation(animationManager, currentState, Speed);

            animationManager.Update(gameTime);
            ColBox.Update(gameTime, Position );

        }



        public void UpdateState()
        {
            currentState = IsMoving() ? "Run" : "Idle";
        }
         private bool IsMoving()
        {
            return Speed.X != 0 || Speed.Y != 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, Position, Scale);
            
            ColBox.Draw(spriteBatch); // TODO: remove after testing
        }
    }
}
