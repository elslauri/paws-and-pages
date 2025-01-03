using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Visuals.Animations;
using Project.Classes.Collision;
using System.Diagnostics;

namespace Project.Classes.GameObjects.Characters
{
    internal class MainCharacter : Character
    {
        private MovementManager movementManager;

        private int books;
        

        public int Books
        {
            get { return books; }
            set { 
                books = value;
                OnPickUp?.Invoke(books);
            }
        }


        public MainCharacter(AnimationManager animationManager, float scale, Vector2 startPos, Vector2 speed, List<ICollidable> obstacles) :
            base(animationManager, scale, startPos, speed, obstacles, new SixDirectionalAnimationStrategy())
        {
            movementManager = new MovementManager();
            InputReader = new KeyboardReader();
            
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            movementManager.MoveWithKeys(this);
            Debug.WriteLine("speed of mc: "+Speed);
        }
        public delegate void ObserveBooks(int bookCount);
        public event ObserveBooks OnPickUp;

        public void PickUpBook()
        {
            Books++;
        }
        public void GiveAwayBook()
        {
            Books--;
        }

    }
}
