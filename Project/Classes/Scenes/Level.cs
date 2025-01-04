using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Background;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.GameObjects.Characters;
using Project.Classes.GameObjects.Items;
using Project.Classes.UI;
using Project.Classes.Visuals.Animations;
using Project.Classes.Visuals;
using System.Collections.Generic;
using Project.Classes.Visualize.Animations.AnimationStrategies;
using System.Diagnostics;
using Project.Classes.Scenes.Checkers;

namespace Project.Classes.Scenes
{
    internal class Level : Scene
    {
        #region members

        protected List<IDraw> drawables;
        protected List<ICollidable> obstacles;

        protected DrawingManager drawingManager;
        protected AnimationFactory animationFactory;

        protected LevelCompletionChecker levelCompletionChecker;
        protected PickUpChecker pickUpChecker;
        protected DeliveryChecker deliveryChecker;

        #region characters
        protected NPCFactory calmNPCFactory;
        protected NPCFactory walkingNPCFactory;
        protected NPCFactory panicNPCFactory;
        protected List<INPCStyle> npcStyles;

        protected MainCharacter player;
        protected AnimationManager animationMainCharManager;
        #region mcTextures
        protected Texture2D mcIdleTexture;
        protected Texture2D mcWalkDownTexture;
        protected Texture2D mcWalkLeftDownTexture;
        protected Texture2D mcWalkLeftUpTexture;
        protected Texture2D mcWalkRightDownTexture;
        protected Texture2D mcWalkRightUpTexture;
        protected Texture2D mcWalkUpTexture;
        #endregion

        protected Friend cat;
        protected AnimationManager animationCatManager;
        #region catTextures
        protected Texture2D catTextureIdle;
        protected Texture2D catTextureRunLeft;
        protected Texture2D catTextureRunRight;

        protected List<NPC> npcs;
        #region npcTextures
        protected Texture2D joggingIdleTexture;
        protected Texture2D joggingUpTexture;
        protected Texture2D joggingLeftTexture;
        protected Texture2D joggingDownTexture;
        protected Texture2D joggingRightTexture;

        protected Texture2D jeansIdleTexture;
        protected Texture2D jeansUpTexture;
        protected Texture2D jeansLeftTexture;
        protected Texture2D jeansDownTexture;
        protected Texture2D jeansRightTexture;

        protected Texture2D skirtIdleTexture;
        protected Texture2D skirtUpTexture;
        protected Texture2D skirtLeftTexture;
        protected Texture2D skirtDownTexture;
        protected Texture2D skirtRightTexture;

        protected Texture2D hatIdleTexture;
        protected Texture2D hatUpTexture;
        protected Texture2D hatLeftTexture;
        protected Texture2D hatDownTexture;
        protected Texture2D hatRightTexture;

        protected Texture2D dressIdleTexture;
        protected Texture2D dressUpTexture;
        protected Texture2D dressLeftTexture;
        protected Texture2D dressDownTexture;
        protected Texture2D dressRightTexture;

        protected Texture2D beardIdleTexture;
        protected Texture2D beardUpTexture;
        protected Texture2D beardLeftTexture;
        protected Texture2D beardDownTexture;
        protected Texture2D beardRightTexture;
        #endregion

        #endregion

        #endregion

        #region backgroundAndItems
        protected Map map;
        protected int[,] floorPlan;
        protected Texture2D tileTexture;

        protected BookshelveFactory bookshelveFactory;
        protected List<Bookshelve> bookshelves;
        protected Texture2D longBookshelveTexture;

        protected Texture2D bookTexture;
        protected BookSpawnManager bookSpawnManager;
        protected List<Book> books;
        protected List<Book> booksToBeDeleted;

        protected OrderManager orderManager;
        protected List<Order> orders;
        #endregion

        #region ui
        protected UIBookCount bookCount;
        protected SpriteFont font;
        protected SpriteFont orderFont;
        protected Texture2D bubbleTexture;
        #endregion

        #endregion

        public Level(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, int[,] floorPlan)
            : base(graphics, spriteBatch, content, gameManager)
        {
            this.floorPlan = floorPlan;
        }


        public override void Initialize()
        {
            drawingManager = new DrawingManager(spriteBatch);
        }

        public override void LoadContent()
        {
            LoadTextures();
            SetAnimations();
            InitializeGameObjects();
            InitializeCheckers();
            Camera.GetTheCamera().Initialize(map, player);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateGameObjects(gameTime);

            Camera.GetTheCamera().Update(gameTime);

            pickUpChecker.CheckBookPickUp();
            deliveryChecker.CheckBookDelivery();
            if (levelCompletionChecker.IsLevelComplete(orders))
            {
                gameManager.OnLevelComplete();
            }
        }
        public override void Draw()
        {
            drawingManager.Draw(drawables, true);
        }

        protected virtual void LoadTextures()
        {
            #region cat
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");
            catTextureRunLeft = content.Load<Texture2D>("Characters/friend/friend_run_left");
            catTextureRunRight = content.Load<Texture2D>("Characters/friend/friend_run_right");
            #endregion

            #region player
            mcIdleTexture = content.Load<Texture2D>("Characters/MC/idle_down");
            mcWalkDownTexture = content.Load<Texture2D>("Characters/MC/walk_down");
            mcWalkLeftDownTexture = content.Load<Texture2D>("Characters/MC/walk_left_down");
            mcWalkLeftUpTexture = content.Load<Texture2D>("Characters/MC/walk_left_up");
            mcWalkRightDownTexture = content.Load<Texture2D>("Characters/MC/walk_right_down");
            mcWalkRightUpTexture = content.Load<Texture2D>("Characters/MC/walk_right_up");
            mcWalkUpTexture = content.Load<Texture2D>("Characters/MC/walk_up");
            #endregion

            #region npc
            joggingIdleTexture = content.Load<Texture2D>("Characters/npc/jogging_idle");
            joggingUpTexture = content.Load<Texture2D>("Characters/npc/jogging_up");
            joggingLeftTexture = content.Load<Texture2D>("Characters/npc/jogging_left");
            joggingDownTexture = content.Load<Texture2D>("Characters/npc/jogging_down");
            joggingRightTexture = content.Load<Texture2D>("Characters/npc/jogging_right");

            jeansIdleTexture = content.Load<Texture2D>("Characters/npc/jeans_idle");
            jeansUpTexture = content.Load<Texture2D>("Characters/npc/jeans_up");
            jeansLeftTexture = content.Load<Texture2D>("Characters/npc/jeans_left");
            jeansDownTexture = content.Load<Texture2D>("Characters/npc/jeans_down");
            jeansRightTexture = content.Load<Texture2D>("Characters/npc/jeans_right");

            skirtIdleTexture = content.Load<Texture2D>("Characters/npc/skirt_idle");
            skirtUpTexture = content.Load<Texture2D>("Characters/npc/skirt_up");
            skirtLeftTexture = content.Load<Texture2D>("Characters/npc/skirt_left");
            skirtDownTexture = content.Load<Texture2D>("Characters/npc/skirt_down");
            skirtRightTexture = content.Load<Texture2D>("Characters/npc/skirt_right");

            hatIdleTexture = content.Load<Texture2D>("Characters/npc/hat_idle");
            hatUpTexture = content.Load<Texture2D>("Characters/npc/hat_up");
            hatLeftTexture = content.Load<Texture2D>("Characters/npc/hat_left");
            hatDownTexture = content.Load<Texture2D>("Characters/npc/hat_down");
            hatRightTexture = content.Load<Texture2D>("Characters/npc/hat_right");

            dressIdleTexture = content.Load<Texture2D>("Characters/npc/dress_idle");
            dressUpTexture = content.Load<Texture2D>("Characters/npc/dress_up");
            dressLeftTexture = content.Load<Texture2D>("Characters/npc/dress_left");
            dressDownTexture = content.Load<Texture2D>("Characters/npc/dress_down");
            dressRightTexture = content.Load<Texture2D>("Characters/npc/dress_right");

            beardIdleTexture = content.Load<Texture2D>("Characters/npc/beard_idle");
            beardUpTexture = content.Load<Texture2D>("Characters/npc/beard_up");
            beardLeftTexture = content.Load<Texture2D>("Characters/npc/beard_left");
            beardDownTexture = content.Load<Texture2D>("Characters/npc/beard_down");
            beardRightTexture = content.Load<Texture2D>("Characters/npc/beard_right");
            #endregion

            #region background
            tileTexture = content.Load<Texture2D>("Background/planks_H_3");

            longBookshelveTexture = content.Load<Texture2D>("Background/longFilledBookshelve");
            bookTexture = content.Load<Texture2D>("Items/bookClosed");

            #endregion

            #region UI
            font = content.Load<SpriteFont>("LevelFont");
            bubbleTexture = content.Load<Texture2D>("UI/roundedBox");
            orderFont = content.Load<SpriteFont>("OrderFont");
            #endregion
        }
        protected virtual void SetAnimations()
        {
            animationFactory = new AnimationFactory();

            #region player
            animationMainCharManager = new AnimationManager();
            // create animations from spritesheet
            var mcIdle = animationFactory.CreateAnimationFromSpriteSheet(mcIdleTexture, 8, 1);
            var mcWalkDown = animationFactory.CreateAnimationFromSpriteSheet(mcWalkDownTexture, 8, 1);
            var mcWalkLeftDown = animationFactory.CreateAnimationFromSpriteSheet(mcWalkLeftDownTexture, 8, 1);
            var mcWalkLeftUp = animationFactory.CreateAnimationFromSpriteSheet(mcWalkLeftUpTexture, 8, 1);
            var mcWalkRightDown = animationFactory.CreateAnimationFromSpriteSheet(mcWalkRightDownTexture, 8, 1);
            var mcWalkRightUp = animationFactory.CreateAnimationFromSpriteSheet(mcWalkRightUpTexture, 8, 1);
            var mcWalkUp = animationFactory.CreateAnimationFromSpriteSheet(mcWalkUpTexture, 8, 1);
            // add animations to their corresponding animationState
            animationMainCharManager.AddAnimation(AnimationState.Idle, mcIdle);
            animationMainCharManager.AddAnimation(AnimationState.Walk_Down, mcWalkDown);
            animationMainCharManager.AddAnimation(AnimationState.Walk_LeftDown, mcWalkLeftDown);
            animationMainCharManager.AddAnimation(AnimationState.Walk_LeftUp, mcWalkLeftUp);
            animationMainCharManager.AddAnimation(AnimationState.Walk_RightDown, mcWalkRightDown);
            animationMainCharManager.AddAnimation(AnimationState.Walk_RightUp, mcWalkRightUp);
            animationMainCharManager.AddAnimation(AnimationState.Walk_Up, mcWalkUp);
            #endregion

            #region cat
            animationCatManager = new AnimationManager();
            var idleCat = animationFactory.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            var runCat_left = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunLeft, 6, 1);
            var runCat_right = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunRight, 6, 1);
            animationCatManager.AddAnimation(AnimationState.Idle, idleCat);
            animationCatManager.AddAnimation(AnimationState.Walk_Left, runCat_left);
            animationCatManager.AddAnimation(AnimationState.Walk_Right, runCat_right);
            #endregion
        }
        protected virtual void InitializeCheckers()
        {
            levelCompletionChecker = new LevelCompletionChecker();
            pickUpChecker = new PickUpChecker(player, books, booksToBeDeleted);
            deliveryChecker = new DeliveryChecker(player, orders);
        }
        protected virtual void InitializeGameObjects()
        {
            map = new Map([tileTexture]);
            bookshelveFactory = new BookshelveFactory(longBookshelveTexture);
            bookshelves = bookshelveFactory.CreateBookshelves(new Vector2(50, 250), floorPlan, 192, 200);

            obstacles = [.. bookshelves];

            books = new List<Book>();
            booksToBeDeleted = new List<Book>();

            player = new MainCharacter(animationMainCharManager, 4f, new Vector2(400, 100), new Vector2(2, 2), 4f, new SixDirectionalAnimationStrategy(), obstacles);
            cat = new Friend(animationCatManager, 2f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), 2f, player, new TwoDirectionalAnimationStrategy(), obstacles);

            InitializeNpcStyles();
            calmNPCFactory = new NPCFactory(3f, new Vector2(0, 0), 0f, obstacles, animationFactory, npcStyles);
            walkingNPCFactory = new NPCFactory(3f, new Vector2(-0.5f, 0.5f), 1f, obstacles, animationFactory, npcStyles);
            panicNPCFactory = new NPCFactory(3f, new Vector2(0.5f, 0.5f), 3f, obstacles, animationFactory, npcStyles);
            npcs = new List<NPC>();

            bookCount = new UIBookCount(font, new Vector2(10, 10), player);

            drawables = [map, .. bookshelves, cat, player, bookCount];

        }
        private void InitializeNpcStyles()
        {
            npcStyles = new List<INPCStyle>()
            {
                new NPCStyle(joggingIdleTexture,joggingUpTexture,joggingLeftTexture,joggingRightTexture,joggingDownTexture),
                new NPCStyle(jeansIdleTexture, jeansUpTexture, jeansLeftTexture, jeansRightTexture, jeansDownTexture),
                new NPCStyle(skirtIdleTexture, skirtUpTexture, skirtLeftTexture, skirtRightTexture, skirtDownTexture),
                new NPCStyle(hatIdleTexture, hatUpTexture, hatLeftTexture, hatRightTexture, hatDownTexture),
                new NPCStyle(dressIdleTexture, dressUpTexture, dressLeftTexture, dressRightTexture, dressDownTexture),
                new NPCStyle(beardIdleTexture, beardUpTexture, beardLeftTexture, beardRightTexture, beardDownTexture),
            };
        }

        protected virtual void UpdateGameObjects(GameTime gameTime)
        {
            cat.Update(gameTime);
            player.Update(gameTime);
            if (orders.Count > 0)
            {
                foreach (Order order in orders)
                {
                    order.Update(gameTime);
                }
            }
        }
    }
}
