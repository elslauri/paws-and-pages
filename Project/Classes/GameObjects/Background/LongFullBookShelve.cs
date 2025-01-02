using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Background
{
    internal class LongFullBookshelve : Bookshelve
    {
        public LongFullBookshelve(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Size = new Vector2(64, 48); // TODO: refactor? see factory? 
            SourceRectangle = new Rectangle(0, 0, 64, 48);


            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y / 4f), texture);

        }
    }
}
