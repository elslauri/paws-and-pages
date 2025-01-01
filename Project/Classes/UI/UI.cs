using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Characters;
using System.Diagnostics;

namespace Project.Classes.UI
{
    internal class UI
    {
        private SpriteFont font;
        private int books;
        private Vector2 position;

        public UI(SpriteFont font, Vector2 position, MainCharacter player)
        {
            this.font = font;
            this.position = position;
            player.OnPickUp += ObserveBooks;
        }
        private void ObserveBooks(int bookCount)
        {
            books = bookCount;
            Debug.WriteLine("UI says: " + books);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.DrawString(font, books.ToString(), position, Color.White);
        }
    }
}
