using Microsoft.Xna.Framework;

namespace Project.Classes.Scenes
{
    internal class SceneManager
    {
        private Scene currentScene;
        public void ChangeScene(Scene newScene)
        {
            currentScene = newScene;
            currentScene.Initialize();
            currentScene.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }
        public void Draw()
        {
            currentScene.Draw();
        }
    }
}
