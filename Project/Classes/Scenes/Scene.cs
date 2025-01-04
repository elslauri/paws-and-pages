using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Classes.Scenes
{
    internal abstract class Scene
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected ContentManager content;
        protected GameManager gameManager;

        public Scene(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.gameManager = gameManager;
        }

        public abstract void Initialize();
        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
    }
}
