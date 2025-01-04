
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Scenes.Levels;
using System.Diagnostics;


namespace Project.Classes.Scenes
{
    internal class GameManager : IGameManager
    {
        private SceneManager sceneManager;
        private Scene mainScene;
        private Scene level1;


        public GameManager()
        {
            sceneManager = new SceneManager(); // TODO: maybe move to parameter in constructor
        }

        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            mainScene = new MainScreen(graphics, spriteBatch, content, this);
            level1 = new Level1(graphics, spriteBatch, content, this);
            

            sceneManager.ChangeScene(level1);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                ChangeScene(mainScene);
            Debug.WriteLine($"mainScene is null: {mainScene == null}");
            Debug.WriteLine($"level1 is null: {level1 == null}");
            sceneManager.Update(gameTime);
        }

        public void Draw()
        {
            sceneManager.Draw();
        }

        public void ChangeScene(Scene newScene)
        {
            sceneManager.ChangeScene(newScene);
        }

        public void OnLevelComplete()
        {
            ChangeScene(mainScene);
        }
    }
}
