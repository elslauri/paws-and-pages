using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals;
using Project.Classes.Visuals.Animations;
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

        private AnimationState currentState;
        protected IAnimationStrategy animationStrategy;

        public IInputReader InputReader { get; set; }

        public CollisionBox ColBox { get; set; }
        public List<ICollidable> obstacles;

        #endregion


        public Character(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, IAnimationStrategy animationStrategy = null)
        {
            Scale = scale;

            Position = position;
            Speed = speed;


            this.animationManager = animationManager;
            this.animationStrategy = animationStrategy ?? new DefaultAnimationStrategy();
            currentState = AnimationState.Idle;
            this.animationManager.SetAnimation(currentState);


            var size = this.animationManager.GetCurrentFrameSize();

            ColBox = new CollisionBox(Position, Scale * size);
            this.obstacles = obstacles;

        }

        public void Update(GameTime gameTime)
        {
            animationStrategy.SetAnimation(animationManager, currentState, Speed);

            animationManager.Update(gameTime);
            ColBox.Update(gameTime, Position);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, Position, Scale);
            if (Globals.showCollision)
                ColBox.Draw(spriteBatch);
        }
    }
}
