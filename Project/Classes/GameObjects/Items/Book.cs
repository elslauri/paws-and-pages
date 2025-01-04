using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Collision;
using Project.Classes.Visuals;
using System;

namespace Project.Classes.GameObjects.Items
{
    internal class Book : IDraw, ICollidable
    {
        public Boolean IsOpen;

        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Color Color { get; set; }

        public float Rotation { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }
        public CollisionBox ColBox { get; set ; }

        public Book(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position + new Vector2(Texture.Width / 2, Texture.Height / 2);
            Color = Color.White;
            Scale = 3f;

            Origin = new Vector2(0, 0);

            Size = new Vector2(Texture.Width, Texture.Height);
            SourceRectangle = new Rectangle(0, 0, 128, 192);


            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White, 0f, Origin, Scale, SpriteEffects.None, 0f);

            if (Globals.showCollision)
            {
                ColBox.Draw(spriteBatch);

            }
        }
    }
}
