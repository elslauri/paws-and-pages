using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Background;
using System;
using System.Collections.Generic;

namespace Project.Classes.GameObjects.Items
{
    internal class BookSpawnManager
    {
        private Random rng;

        public BookSpawnManager()
        {
            rng = new Random();
        }
        public List<Book> SpawnBooks(Texture2D bookTexture, List<Bookshelve> bookshelves, float chance = 0.5f)
        {
            List <Book> books = new List<Book>();
            foreach (var bookshelve in bookshelves)
            {
                if (rng.NextDouble() <= chance)
                {
                    var bookPosition = bookshelve.Position + new Vector2(bookshelve.Size.X, bookshelve.Size.Y / 2);
                    books.Add(new Book(bookTexture, bookPosition));
                }
            }

            return books;
        }


    }
}
