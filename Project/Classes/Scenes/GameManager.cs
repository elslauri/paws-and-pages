
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.Scenes.Levels;
using Project.Classes.Scenes.Screens;
using System.Collections.Generic;


namespace Project.Classes.Scenes
{
    internal class GameManager : IGameManager
    {
        private SceneManager sceneManager;
        private Scene mainScene;
        private Scene levelCompleteScene;
        private Scene level1;
        private Scene level2;

        private LevelConfiguration configEasy;
        private LevelConfiguration configAdvanced;

        private int minBooksPerOrderEasy;
        private int maxBookPerOrderEasy;
        private int minBooksPerOrderAdvanced;
        private int maxBookPerOrderAdvanced;

        private int[,] floorPlanEasy = new int[,]
             {
               { 1,1,0,1,1,1,1,0,1,1,1 },
               { 1,0,1,1,0,1,1,1,1,1,1 },
               { 1,1,0,0,1,1,1,1,0,1,1 },
               { 0,1,1,1,1,1,1,0,1,1,1 },
               { 1,0,0,1,1,0,1,1,0,0,1 },
               { 1,1,1,1,0,1,0,1,1,1,1 },
               { 1,1,1,1,0,1,1,1,0,1,1 }
                 };
        private int[,] floorPlanAdvanced = new int[,]
             {
               { 1,0,1,1,0,1,1,1,1,0,1 },
               { 1,1,0,1,1,1,0,1,1,1,0 },
               { 0,1,1,1,1,0,1,1,1,0,1 },
               { 1,1,0,1,1,0,1,1,1,1,1 },
               { 1,1,1,1,0,1,1,0,1,1,0 },
               { 1,1,0,1,1,1,0,1,1,0,1 },
               { 1,1,1,1,0,1,1,1,0,1,1 }
                 };
        private List<(Vector2 position, NpcMoveType moveType)> npcDataEasy = new List<(Vector2 position, NpcMoveType moveType)>
        {
            (new Vector2(150, 100), NpcMoveType.Calm),
            (new Vector2(550, 700), NpcMoveType.Calm),
            (new Vector2(850, 350), NpcMoveType.Walk),
            (new Vector2(1450, 850), NpcMoveType.Walk),
            (new Vector2(2050, 1550), NpcMoveType.Walk)
        };
        private List<(Vector2 position, NpcMoveType moveType)> npcDataAdvanced = new List<(Vector2 position, NpcMoveType moveType)>
        {
            (new Vector2(384, 200), NpcMoveType.Walk),
            (new Vector2(1110, 540), NpcMoveType.Walk),
            (new Vector2(1152, 350), NpcMoveType.Walk),
            (new Vector2(1536, 350), NpcMoveType.Walk),
            (new Vector2(195, 600), NpcMoveType.Walk),
            (new Vector2(730, 925), NpcMoveType.Panic),
            (new Vector2(1340, 445), NpcMoveType.Panic),
            (new Vector2(2050, 1550), NpcMoveType.Panic),
            (new Vector2(1030, 1140), NpcMoveType.Panic),
            (new Vector2(1900, 1200), NpcMoveType.Panic),
        };

        public GameManager()
        {
            sceneManager = new SceneManager(); // TODO: maybe move to parameter in constructor
        }

        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            minBooksPerOrderEasy = 1;
            maxBookPerOrderEasy = 4;
            minBooksPerOrderAdvanced = 1;
            maxBookPerOrderAdvanced = 3;

            mainScene = new MenuScene(graphics, spriteBatch, content, this);
            levelCompleteScene = new LevelCompleteScene(graphics, spriteBatch, content, this);

            configEasy = new LevelConfiguration(floorPlanEasy, minBooksPerOrderEasy, maxBookPerOrderEasy, npcDataEasy);
            configAdvanced = new LevelConfiguration(floorPlanAdvanced, minBooksPerOrderAdvanced, maxBookPerOrderAdvanced, npcDataAdvanced);

            level1 = new EasyLevel(graphics, spriteBatch, content, this, configEasy);
            level2 = new AdvancedLevel(graphics, spriteBatch, content, this, configAdvanced);

            sceneManager.ChangeScene(mainScene);
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
