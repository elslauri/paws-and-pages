
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project.Classes.Scenes
{
    internal class GameManager : IGameManager
    {
        private Scene currentScene;


        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            currentScene = new Level1(graphics, spriteBatch, content);
            currentScene.Initialize();
        }

        public void LoadContent()
        {
            if (currentScene != null)
            {
                currentScene.LoadContent();
            }
            else
            {
                throw new InvalidOperationException("currentScene is not initialized.");
            }
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw()
        {
            currentScene.Draw();
        }

        // TODO: method to change scene here I guess


    }
}
