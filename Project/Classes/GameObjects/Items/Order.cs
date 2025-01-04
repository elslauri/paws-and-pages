using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Classes.UI;
using Project.Classes.GameObjects.Characters;
using Project.Classes.Visuals;

namespace Project.Classes.GameObjects.Items
{
    internal class Order : IGameObject, IDraw
    {
        public Character Orderer { get; }
        public Bubble SpeechBubble { get; }
        public Vector2 Position { get; set; }

        public int BooksOrdered { get; set; }

        public Order(Character orderer, Texture2D texture, SpriteFont font, int amountOfBooks)
        {
            Orderer = orderer;
            SpeechBubble = new Bubble(texture, font);
            BooksOrdered = amountOfBooks;
            SpeechBubble.SetMessage(BooksOrdered.ToString());
        }

        public void DeliverBooks(int booksTobeDelivered)
        {
            if (booksTobeDelivered >= BooksOrdered)
            {
                BooksOrdered = 0;
                SetThankYouMessage();
            }
            else
            {
                BooksOrdered -= booksTobeDelivered;
                SetOrderMessage(BooksOrdered);
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateBubblePosition();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpeechBubble.Draw(spriteBatch);
        }

        /// <summary>
        /// Updates the position of the speechbubble with the postition of the orderer
        /// </summary>
        private void UpdateBubblePosition()
        {
            Position = new Vector2(Orderer.Position.X - SpeechBubble.Width / 2 + 8, Orderer.Position.Y - 70);
            SpeechBubble.SetPosition(Position);
        }
        /// <summary>
        /// Sets the order message to a string with the amount of books ordered
        /// </summary>
        /// <param name="amount">int with the amount of books ordered</param>
        private void SetOrderMessage(int amount)
        {
            if (amount == 1)
            {
                SpeechBubble.SetMessage($"{amount} book please");
            }
            else
            {
                SpeechBubble.SetMessage($"{amount} books please");
            }

        }
        private void SetThankYouMessage()
        {
            SpeechBubble.SetMessage("Thank you");
        }
    }
}
