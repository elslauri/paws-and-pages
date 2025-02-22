﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Classes.Visuals;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Background
{
    internal class Bookshelve : ICollidable, IDraw
    {
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public float Scale { get; set; }
        public CollisionBox ColBox { get; set; }

        public Bookshelve(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position + new Vector2(Texture.Width / 2, Texture.Height / 2);

            Scale = 3f;

            Size = new Vector2(texture.Width, texture.Height);
            SourceRectangle = new Rectangle(0, 0, (int)Size.X, (int)Size.Y);


            ColBox = new CollisionBox(Position, new Vector2(Scale * Size.X, Scale * Size.Y));
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRectangle, Color.White, 0f, new Vector2(0,0), Scale, SpriteEffects.None, 0f);

            if (Globals.ShowCollision)
            {
                ColBox.Draw(spriteBatch);
            }
        }
    }
}
