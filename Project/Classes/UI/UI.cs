using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects;
using Project.Classes.GameObjects.Characters;

namespace Project.Classes.UI
{
    internal class UI : IDraw
    {
        private SpriteFont font;
        private int books;
        private string message;
        private Color pearl;
        public Vector2 Position { get; set; }

        public UI(SpriteFont font, Vector2 position, MainCharacter player)
        {
            this.font = font;
            Position = position;
            pearl = new Color(234,224,204);
            player.OnPickUp += ObserveBooks;
            UpdateMessage();
        }
        private void ObserveBooks(int bookCount)
        {
            books = bookCount;
            UpdateMessage();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, message, Position, pearl);
        }
        private string UpdateMessage()
        {
            if (books > 0)
            {
                return message = $"Books: {books}";
            }
            else
            {
                return message = "No books";
            }
        }
    }
}
