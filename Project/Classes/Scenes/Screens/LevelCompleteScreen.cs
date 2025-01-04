using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.GameObjects.Characters;
using Project.Classes.UI;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;

namespace Project.Classes.Scenes.Screens
{
    internal class LevelCompleteScreen : Scene
    {
        private List<IDraw> drawables;
        private DrawingManager drawingManager;

        private Texture2D catTextureIdle;
        private Texture2D catTextureLeft;
        private Texture2D catTextureRight;

        private MainCharacter friend;

        private AnimationFactory animationFactory;
        private AnimationManager animationManager;

        private SpriteFont titleFont;
        private Title congratsText;
        private SpriteFont congratsFont;
        private Title continueText;

        public LevelCompleteScreen(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager)
           : base(graphics, spriteBatch, content, gameManager) { }


        public override void Initialize()
        {
            drawingManager = new DrawingManager(spriteBatch);
        }

        public override void LoadContent()
        {
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");
            catTextureLeft = content.Load<Texture2D>("Characters/friend/friend_run_left");
            catTextureRight = content.Load<Texture2D>("Characters/friend/friend_run_right");

            titleFont = content.Load<SpriteFont>("titleFont");
            congratsFont = content.Load<SpriteFont>("congratsFont");

            animationFactory = new AnimationFactory();
            animationManager = new AnimationManager();
            var idleCat = animationFactory.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            var runCat_left = animationFactory.CreateAnimationFromSpriteSheet(catTextureLeft, 6, 1);
            var runCat_right = animationFactory.CreateAnimationFromSpriteSheet(catTextureRight, 6, 1);
            animationManager.AddAnimation(AnimationState.Idle, idleCat);
            animationManager.AddAnimation(AnimationState.Walk_Left, runCat_left);
            animationManager.AddAnimation(AnimationState.Walk_Right, runCat_right);


            friend = new MainCharacter(animationManager, 2f, new Vector2(Globals.windowSizeX / 2, Globals.windowSizeY / 2), new Vector2(2, 2), new TwoDirectionalAnimationStrategy());

            var message = "Level complete";
            congratsText = new Title(titleFont, message, new Vector2(Globals.windowSizeX / 2 - titleFont.MeasureString(message).X/2, Globals.windowSizeY / 3));
            message = "Press P to continue";
            continueText = new Title(congratsFont, message, new Vector2(Globals.windowSizeX/2 - congratsFont.MeasureString(message).X / 2, Globals.windowSizeY/3 + 400));

            drawables = [congratsText, continueText, friend];
        }

        public override void Update(GameTime gameTime)
        {
            friend.Update(gameTime);
        }
        public override void Draw()
        {
            drawingManager.Draw(drawables, false);
        }
    }
}
