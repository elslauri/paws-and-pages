using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Background;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Items
{
    internal class BookSpawnManager
    {
        public List<Book> SpawnBooks(Texture2D bookTexture, List<Bookshelve> bookshelves)
        {
            List <Book> books = new List<Book>();
            foreach (var bookshelve in bookshelves)
            {
                var bookPosition = bookshelve.Position + new Vector2(bookshelve.Size.X / 2, bookshelve.Size.Y / 2);
                books.Add(new Book(bookTexture, bookPosition));
            }

            return books;
        }


    }
}
