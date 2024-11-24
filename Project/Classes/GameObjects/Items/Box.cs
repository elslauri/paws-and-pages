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
    internal class Box : ICollidable
    {
        private Texture2D texture;


        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Color Color { get; set; }
        public CollisionBox BoxCollision { get; set; }


        public Box(Texture2D texture, Vector2 position, Vector2 size, Color color)
        {
            this.texture = texture;
            Position = position;
            Size = size;
            Color = color;

            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

            BoxCollision = new CollisionBox(Position, Size);
        }

        public void Update(GameTime gameTime)
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color);
        }
    }
}
