using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project.Classes.Input;
using Project.Classes.Movement;
using Project.Classes.Visuals.Animations;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Items;
using Project.Classes.Visualize.Animations.AnimationStrategies;

namespace Project.Classes.GameObjects.Characters
{
    internal class MainCharacter : Character
    {
        private MovementManager movementManager;

        private int books;
        public int Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPickUp?.Invoke(books);
            }
        }


        public MainCharacter(AnimationManager animationManager, float scale, Vector2 startPos, Vector2 speed, float maxSpeed, IAnimationStrategy animationStrategy, List<ICollidable> obstacles = null) :
            base(animationManager, scale, startPos, speed, maxSpeed, obstacles, animationStrategy)
        {
            movementManager = new MovementManager();
            InputReader = new KeyboardReader();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Move();
        }

        private void Move()
        {
            movementManager.MoveWithKeys(this);
        }

        public delegate void ObserveBooks(int bookCount);
        public event ObserveBooks OnPickUp;

        public void PickUpBook()
        {
            Books++;
        }
        public void DeliverBooksTo(Order order)
        {
            if (Books >= order.BooksOrdered)
            {
                Books -= order.BooksOrdered;
                order.DeliverBooks(order.BooksOrdered);
            }
            else
            {
                order.DeliverBooks(Books);
                Books = 0;
            }
        }

    }
}
