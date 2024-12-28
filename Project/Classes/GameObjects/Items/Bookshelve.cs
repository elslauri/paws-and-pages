using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Items
{
    internal class Bookshelve : ICollidable, IDraw
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Color Color { get; set; }
        public CollisionBox ColBox { get; set; }

        public float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }

        public Bookshelve(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            Position = position + new Vector2(Texture.Width / 2, Texture.Height / 2);
            Color = Color.White;
            Scale = 3f;

            Origin = new Vector2(0, 0);

            Size = new Vector2(0, 0); //TODO: FOR THIS SHELVE ONLY SO MAKE A FACTORY?!
            SourceRectangle = new Rectangle(0,0, 128, 192); 


            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y) , texture);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(Texture, Position , SourceRectangle, Color.White, 0f, Origin, Scale, SpriteEffects.None, 0f);
           
           ColBox.Draw(spriteBatch);
        }
    }
}
