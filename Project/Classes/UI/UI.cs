using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects;
using Project.Classes.GameObjects.Characters;
using System.Diagnostics;
using System.Linq;

namespace Project.Classes.UI
{
    internal class UI : IDraw
    {
        private SpriteFont font;
        private int books;
        private string message;
        public Vector2 Position { get; set; }

        public UI(SpriteFont font, Vector2 position, MainCharacter player)
        {
            this.font = font;
            this.Position = position;
            player.OnPickUp += ObserveBooks;
            message = "test";
        }
        private void ObserveBooks(int bookCount)
        {
            books = bookCount;
            Debug.WriteLine("UI says: " + books);
            message = $"{books} + books";
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine("Drawing");
            spriteBatch.DrawString(font, message, Position, Color.White);
        }
    }
}
