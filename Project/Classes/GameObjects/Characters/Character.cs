using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.Input;
using Project.Classes.Movement;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

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

        public IInputReader InputReader { get; set; }

        public CollisionBox ColBox { get; set; }
        public List<ICollidable> obstacles;

        #endregion


        public Character(AnimationManager animationManager, float scale, Vector2 position, Vector2 speed, List<ICollidable> obstacles, Texture2D blockTexture)
        {
            Scale = scale;

            Position = position;
            Speed = speed;

            


            this.animationManager = animationManager;
            currentState = "Idle";
            this.animationManager.SetAnimation(currentState);

            // Origin is here not used
            //Origin = new Vector2(this.animationManager.GetCurrentFrameSize().X / 2, this.animationManager.GetCurrentFrameSize().Y / 2);
            //Origin = new Vector2(0, 0); 

            var size = this.animationManager.GetCurrentFrameSize();

            ColBox = new CollisionBox(Position, Scale * size, blockTexture);
            this.obstacles = obstacles;


        }

        public void Update(GameTime gameTime)
        {
            UpdateState();
            animationManager.SetAnimation(currentState);

            animationManager.Update(gameTime);
            ColBox.Update(gameTime, Position );

        }



        public void UpdateState()
        {
            currentState = IsMoving() ? "Run" : "Idle";
        }
         private bool IsMoving()
        {
            return Speed.X > 0 || Speed.Y > 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animationManager.Draw(spriteBatch, Position, Scale);
            
            ColBox.Draw(spriteBatch); // TODO: remove after testing
        }
    }
}
