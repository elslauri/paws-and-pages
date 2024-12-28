using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using Project.Classes.Collision;

namespace Project.Classes.GameObjects.Items
{
    // FOR TESTING - TODO: REMOVE
    internal class Box : ICollidable, IDraw
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

        public Box(Texture2D texture, Vector2 position, Vector2 size, Color color)
        {
            this.Texture = texture;
            Position = position;
            Size = size;
            Color = color;

            SourceRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

            ColBox = new CollisionBox(Position, Size, texture);
        }

        public void Update(GameTime gameTime)
        {
            SourceRectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, SourceRectangle, Color);
        }
    }
}
