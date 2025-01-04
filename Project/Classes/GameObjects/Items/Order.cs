using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Classes.UI;
using Project.Classes.GameObjects.Characters;
using Project.Classes.Visuals;

namespace Project.Classes.GameObjects.Items
{
    internal class Order : IGameObject, IDraw
    {
        public Character Orderer { get; }
        public Bubble SpeechBubble { get; }
        public Vector2 Position { get; set; }

        public Order(Character orderer, Texture2D texture, SpriteFont font)
        {
            Orderer = orderer;
            SpeechBubble = new Bubble(texture, font);
            
        }

        public void SetOrderMessage(string message)
        {
            SpeechBubble.SetMessage(message);
        }

        private void UpdateBubblePosition()
        {
            Position = new Vector2(Orderer.Position.X-SpeechBubble.Width/2+8, Orderer.Position.Y - 70);
            SpeechBubble.SetPosition(Position);
        }

        public void Update(GameTime gameTime)
        {
            UpdateBubblePosition();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpeechBubble.Draw(spriteBatch);
        }
    }
}
