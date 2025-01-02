using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Visuals;

namespace Project.Classes.UI
{
    internal class Title : IDraw
    {
        private SpriteFont font;
        private string title;
        private Color sage;

        public Vector2 Position { get; set; }

        public Title(SpriteFont font, string title, Vector2 position)
        {
            this.font = font;
            this.title = title;
            sage = new Color(160, 160, 131);
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, title, Position, sage);
        }
    }
}
