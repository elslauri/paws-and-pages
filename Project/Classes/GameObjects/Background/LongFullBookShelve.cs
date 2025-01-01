using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Background
{
    internal class LongFullBookShelve : Bookshelve
    {
        public LongFullBookShelve(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Size = new Vector2(64, 48); //TODO: FOR THIS SHELVE ONLY SO MAKE A FACTORY?
            SourceRectangle = new Rectangle(0, 0, 64, 48);


            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y / 3), texture);

        }
    }
}
