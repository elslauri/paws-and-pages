using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace Project.Classes.GameObjects.Background
{
    internal class BookshelveFactory
    {
        private Texture2D texture;
        private int notDrawn;
        private Random rng;
        public BookshelveFactory(Texture2D texture)
        {
            this.texture = texture;
            rng = new Random();
        }


        public List<Bookshelve> CreateBookshelves(Vector2 startPosition,int rows, int columns, int spacingX, int spacingY)
        {
            List<Bookshelve> shelves = new List<Bookshelve>();
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    notDrawn = rng.Next(0,11);
                    if (notDrawn < 8)
                    {
                        Vector2 pos = new Vector2(startPosition.X + spacingX * i, startPosition.Y + spacingY * j);
                        shelves.Add(new LongFullBookShelve(texture, pos));
                    }
                }
            }
            return shelves;
        }
        
    }
}
