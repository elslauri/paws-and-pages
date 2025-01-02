
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.GameObjects.Characters;
using Project.Classes.Visuals;
using System.Collections.Generic;

namespace Project.Classes.Scenes
{
    internal class MainScreen : Level
    {
        private List<IDraw> drawables;
        private DrawingManager drawingManager;


        private Texture2D catTextureIdle;
        private MainCharacter friend;

        private AnimationFactory animationFactoryMain;
        private AnimationManager animationManagerMain;

        private SpriteFont font;

        public MainScreen(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content) : base(graphics, spriteBatch, content)
        {
        }

        public override void Initialize()
        {
            drawingManager = new DrawingManager(spriteBatch);
        }

        public override void LoadContent()
        {
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");

            font = content.Load<SpriteFont>("MenuFont");

            animationFactoryMain = new AnimationFactory();
            animationManagerMain = new AnimationManager();
            var idleCat = animationFactoryMain.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            animationManagerMain.AddAnimation("Idle", idleCat);
            animationManagerMain.SetAnimation("Idle"); // to be sure


            friend = new MainCharacter(animationManagerMain, 2f, new Microsoft.Xna.Framework.Vector2(50, 50), new Vector2(2,2), null);
            drawables = [ friend ];

            //Camera.GetTheCamera().Initialize(map, friend);

        }

        public override void Update(GameTime gameTime)
        {
            friend.Update(gameTime);
            //Camera.GetTheCamera().Update(gameTime);

        }
        public override void Draw()
        {
            drawingManager.Draw(drawables);
        }

    }
}
