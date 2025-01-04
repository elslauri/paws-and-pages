using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Background
{
    internal class LongFullBookshelve : Bookshelve
    {
        public LongFullBookshelve(Texture2D texture, Vector2 position) : base(texture, position)
        {
            // adjusted collisionbox so collision box is only top of the bookshelve
            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y / 4f));

        }
    }
}
