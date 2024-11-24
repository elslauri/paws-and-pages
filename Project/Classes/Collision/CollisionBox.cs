using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Collision
{
    internal class CollisionBox
    {
        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        // scale

        public CollisionBox(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;

            UpdateRectangle();
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            Position = position;
            UpdateRectangle();
        }

        public void UpdateRectangle()
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }

        /// <summary>
        /// Checks if a collision box is colliding with another collision box.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCollidingWith(CollisionBox other)
        {
            return Rectangle.Intersects(other.Rectangle);
        }
    }
}
