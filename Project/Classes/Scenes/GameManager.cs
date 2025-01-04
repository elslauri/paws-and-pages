
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Scenes.Levels;
using Project.Classes.Scenes.Screens;
using System.Diagnostics;


namespace Project.Classes.Scenes
{
    internal class GameManager : IGameManager
    {
        private SceneManager sceneManager;
        private Scene mainScene;
        private Scene levelCompleteScene;
        private Scene level1;
        private Scene level2;

        private int[,] floorPlan = new int[,]
             {
               { 1,1,0,1,1,1,1,0,1,1,1 },
               { 1,0,1,1,0,1,1,1,1,1,1 },
               { 1,1,0,0,1,1,1,1,0,1,1 },
               { 0,1,1,1,1,1,1,0,1,1,1 },
               { 1,0,0,1,1,0,1,1,0,0,1 },
               { 1,1,1,1,0,1,0,1,1,1,1 },
               { 1,1,1,1,0,1,1,1,0,1,1 }
                 };


        public GameManager()
        {
            sceneManager = new SceneManager(); // TODO: maybe move to parameter in constructor
        }

        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            mainScene = new MenuScene(graphics, spriteBatch, content, this);
            levelCompleteScene = new LevelCompleteScene(graphics, spriteBatch, content, this);
            level1 = new EasyLevel(graphics, spriteBatch, content, this, floorPlan, 1, 3);
            level2 = new AdvancedLevel(graphics, spriteBatch, content, this, floorPlan, 1, 5);

            sceneManager.ChangeScene(level1);
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
                ChangeScene(mainScene);
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                ChangeScene(level1);
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
                ChangeScene(level2);
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
            ChangeScene(levelCompleteScene);
        }
    }
}
