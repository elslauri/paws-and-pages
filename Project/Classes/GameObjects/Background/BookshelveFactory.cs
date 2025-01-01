using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Schema;

namespace Project.Classes.GameObjects.Background
{
    internal class BookshelveFactory
    {
        private Texture2D texture;
        public BookshelveFactory(Texture2D texture)
        {
            this.texture = texture;
        }
        public List<Bookshelve> CreateBookshelves(Vector2 startPosition,int rows, int columns, int spacingX, int spacingY)
        {
            List<Bookshelve> shelves = new List<Bookshelve>();
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    Vector2 pos = new Vector2(startPosition.X + spacingX * i, startPosition.Y + spacingY * j);
                    shelves.Add(new LongFullBookShelve(texture, pos));
                }
            }
            return shelves;
        }
    }
}
