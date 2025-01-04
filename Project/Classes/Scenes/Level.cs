using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project.Classes.Scenes
{
    internal class Level : Scene
    {
        protected GameManager gameManager;

        public Level(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager) 
            : base(graphics, spriteBatch, content)
        {
            this.gameManager = gameManager;
        }


        public override void Initialize()
        {
            
        }

        public override void LoadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw()
        {
            
        }
    }
}
