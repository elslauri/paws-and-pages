using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Visuals
{
    public class Sprite
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            Position = position;
            Origin = new(texture.Width / 2, texture.Height / 2); // center? 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
