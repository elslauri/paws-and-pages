
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Characters;
using Project.Classes.UI;
using Project.Classes.Visuals;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;

namespace Project.Classes.Scenes
{
    internal class MainScreen : Level
    {
        private List<IDraw> drawables;
        private List<ICollidable> obstacels;

        private DrawingManager drawingManager;


        private Texture2D catTextureIdle;
        private MainCharacter friend;

        private AnimationFactory animationFactoryMain;
        private AnimationManager animationManagerMain;

        private SpriteFont font;
        private Title title; 

        public MainScreen(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager) 
            : base(graphics, spriteBatch, content, gameManager)
        {
        }

        public override void Initialize()
        {
            drawingManager = new DrawingManager(spriteBatch);
        }

        public override void LoadContent()
        {
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");

            font = content.Load<SpriteFont>("TitleFont");

            animationFactoryMain = new AnimationFactory();
            animationManagerMain = new AnimationManager();
            var idleCat = animationFactoryMain.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            animationManagerMain.AddAnimation(AnimationState.Idle, idleCat);


            friend = new MainCharacter(animationManagerMain, 2f, new Vector2(Globals.windowSizeX/2, Globals.windowSizeY/2), new Vector2(2,2), obstacels);
            
            title = new Title(font, "Paws and Pages", new Vector2(Globals.windowSizeX/2-220, Globals.windowSizeY/3));

            drawables = [title, friend];

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
