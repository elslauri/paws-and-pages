using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Scenes
{
    internal interface IGameManager
    {
        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content);
        public void LoadContent();
        public void Update(GameTime gameTime);
        public void Draw();
    }
}
