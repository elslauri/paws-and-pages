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

        public Texture2D texture; // Placeholder texture for drawing

        public CollisionBox(Vector2 position, Vector2 size, Texture2D blockTexture)
        {
            Position = position;
            Size = size;

            this.texture = blockTexture;

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
        /// Draw collision box for testing purposes
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texture, Rectangle, Color.Red); // sprite with red overlay
            Texture2D border = makeBordersCollisionBox(spriteBatch, (int)Rectangle.Width, (int)Rectangle.Height);
            spriteBatch.Draw(border, Rectangle, Color.White);
 
      
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


        /// <summary>
        /// Draws a collision box that shows the borders
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private Texture2D makeBordersCollisionBox(SpriteBatch spriteBatch, int width, int height)
        {
            Color[] data = new Color[width * height];
            Texture2D collisionTexture = new Texture2D(spriteBatch.GraphicsDevice, width, height);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Transparent;
            }
            for (int i = 0; i < width; i++)
            {
                data[i] = Color.Violet;
            }
            for (int i = data.Length - width -1; i < data.Length; i++)
            {
                data[i] = Color.Violet;
            }
            for (int i = width; i < data.Length; i+= width)
            {
                data[i - 1] = Color.Violet;
                data[i] = Color.Violet;
            }
            data[data.Length - 1] = Color.Violet;
            collisionTexture.SetData(data);

            return collisionTexture;
        }
    }
}
