using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.GameObjects
{
    internal class CollisionBox
    {
        public Rectangle Rectangle { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        // scale

        public CollisionBox(Vector2 position, Vector2 size)
        {
            this.Position = position;
            this.Size = size;

            UpdateRectangle();
        }

        public void Update(GameTime gameTime, Vector2 position )
        {
            this.Position = position;
            UpdateRectangle();
        }

        public void UpdateRectangle()
        {
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
    }
}
