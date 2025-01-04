using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Background;
using Project.Classes.GameObjects.Characters;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.GameObjects.Items;
using Project.Classes.UI;
using Project.Classes.Visuals;
using Project.Classes.Visuals.Animations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project.Classes.Scenes
{
    internal class Level1 : Level
    {
        #region members

        private List<IDraw> drawables;
        private List<ICollidable> obstacles;

        private DrawingManager drawingManager;

        #region npcTextures
        private Texture2D joggingIdleTexture;
        private Texture2D joggingUpTexture;
        private Texture2D joggingLeftTexture;
        private Texture2D joggingDownTexture;
        private Texture2D joggingRightTexture;

        private Texture2D jeansIdleTexture;
        private Texture2D jeansUpTexture;
        private Texture2D jeansLeftTexture;
        private Texture2D jeansDownTexture;
        private Texture2D jeansRightTexture;

        private Texture2D skirtIdleTexture;
        private Texture2D skirtUpTexture;
        private Texture2D skirtLeftTexture;
        private Texture2D skirtDownTexture;
        private Texture2D skirtRightTexture;

        private Texture2D hatIdleTexture;
        private Texture2D hatUpTexture;
        private Texture2D hatLeftTexture;
        private Texture2D hatDownTexture;
        private Texture2D hatRightTexture;

        private Texture2D dressIdleTexture;
        private Texture2D dressUpTexture;
        private Texture2D dressLeftTexture;
        private Texture2D dressDownTexture;
        private Texture2D dressRightTexture;

        private Texture2D beardIdleTexture;
        private Texture2D beardUpTexture;
        private Texture2D beardLeftTexture;
        private Texture2D beardDownTexture;
        private Texture2D beardRightTexture;
        #endregion
        private NPC npcStill;
        private NPC npcWalk;
        private NPC npcRun;
        private List<NPC> npcs;

        #region mcTextures
        private Texture2D mcIdleTexture;
        private Texture2D mcWalkDownTexture;
        private Texture2D mcWalkLeftDownTexture;
        private Texture2D mcWalkLeftUpTexture;
        private Texture2D mcWalkRightDownTexture;
        private Texture2D mcWalkRightUpTexture;
        private Texture2D mcWalkUpTexture;
        #endregion
        private MainCharacter player;
        #region catTextures
        private Texture2D catTextureIdle;
        private Texture2D catTextureRunLeft;
        private Texture2D catTextureRunRight;
        #endregion
        private Friend cat;

        // background
        private Map map;
        private Texture2D tileTexture;
        private List<Bookshelve> bookshelves;
        private Texture2D longBookshelveTexture;
        private Texture2D shortBookshelveTexture; // TODO: do something with this

        private AnimationFactory animationFactory;
        private AnimationManager animationMainCharManager;
        private AnimationManager animationCatManager;

        private NPCFactory calmNPCFactory;
        private NPCFactory walkingNPCFactory;
        private NPCFactory panicNPCFactory;
        private List<INPCStyle> npcStyles;

        private BookshelveFactory bookshelveFactory;
        private Texture2D bookTexture;
        private BookSpawnManager bookSpawnManager;

        private List<Book> books;
        private List<Book> booksToBeDeleted;

        //UI
        private UIBookCount bookCount;
        private SpriteFont font;
        private SpriteFont orderFont;
        private Texture2D bubbleTexture;
        private Bubble bubble;

        private OrderManager orderManager;
        private List<Order> orders;

        #endregion
        public Level1(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
            : base(graphics, spriteBatch, content)
        {

        }

        public override void Initialize()
        {
            drawingManager = new DrawingManager(spriteBatch);

        }
        public override void LoadContent()
        {
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

            #region background
            tileTexture = content.Load<Texture2D>("Background/planks_H_3");

            longBookshelveTexture = content.Load<Texture2D>("Background/longFilledBookshelve");
            shortBookshelveTexture = content.Load<Texture2D>("Background/shortFilledBookshelve");
            bookTexture = content.Load<Texture2D>("Items/bookClosed");

            #endregion

            #region UI
            font = content.Load<SpriteFont>("LevelFont");
            bubbleTexture = content.Load<Texture2D>("UI/rectangleBox");
            orderFont = content.Load<SpriteFont>("OrderFont");
            #endregion

            SetAnimations();

            InitializeGameObjects();

            Camera.GetTheCamera().Initialize(map, player);

        }

        public override void Update(GameTime gameTime)
        {
            npcStill.Update(gameTime);
            npcWalk.Update(gameTime);
            npcRun.Update(gameTime);
            cat.Update(gameTime);
            player.Update(gameTime);
            foreach (Order order in orders)
            {
                order.Update(gameTime);
            }

            Camera.GetTheCamera().Update(gameTime);


            // test collision TODO: move to other file
            if (player.ColBox.IsCollidingWith(npcStill.ColBox))
            {
                Debug.WriteLine("PARDON ME");
            }

            CheckBookPickUp();
            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, .. orders, cat, player, bookCount, bubble];

        }
        public override void Draw()
        {
            drawingManager.Draw(drawables, true);
        }

        private void SetAnimations()
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
            var mcWalkUp = animationFactory.CreateAnimationFromSpriteSheet(mcWalkDownTexture, 8, 1);
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
        private void InitializeGameObjects()
        {
            // add background and blocks
            map = new Map([tileTexture]);

            int[,] floorPlan = new int[,]
                {
               { 1,1,0,1,1,1,1,0,1,1,1 },
               { 1,0,1,1,0,1,1,1,1,1,1 },
               { 1,1,0,0,1,1,1,1,0,1,1 },
               { 0,1,1,1,1,1,1,0,1,1,1 },
               { 1,0,0,1,1,0,1,1,0,0,1 },
               { 1,1,1,1,0,1,0,1,1,1,1 },
               { 1,1,1,1,0,1,1,1,0,1,1 }
                };  // 7,11 // TODO: move to members
            bookshelveFactory = new BookshelveFactory(longBookshelveTexture);
            bookshelves = bookshelveFactory.CreateBookshelves(new Vector2(50, 250), floorPlan, 192, 200);

            obstacles = [.. bookshelves];

            booksToBeDeleted = new List<Book>();
            bookSpawnManager = new BookSpawnManager();
            books = bookSpawnManager.SpawnBooks(bookTexture, bookshelves);

            // initialize NPC styles
            npcStyles = new List<INPCStyle>()
            { 
                new NPCStyle(joggingIdleTexture,joggingUpTexture,joggingLeftTexture,joggingRightTexture,joggingDownTexture),
                new NPCStyle(jeansIdleTexture, jeansUpTexture, jeansLeftTexture, jeansRightTexture, jeansDownTexture),
                new NPCStyle(skirtIdleTexture, skirtUpTexture, skirtLeftTexture, skirtRightTexture, skirtDownTexture),
                new NPCStyle(hatIdleTexture, hatUpTexture, hatLeftTexture, hatRightTexture, hatDownTexture),
                new NPCStyle(dressIdleTexture, dressUpTexture, dressLeftTexture, dressRightTexture, dressDownTexture),
                new NPCStyle(beardIdleTexture, beardUpTexture, beardLeftTexture, beardRightTexture, beardDownTexture),
            };

            // Initialize npc factories
            calmNPCFactory = new NPCFactory(3f, new Vector2(0, 0), obstacles, animationFactory, npcStyles);
            walkingNPCFactory = new NPCFactory(3f, new Vector2(1, 1), obstacles, animationFactory, npcStyles);
            panicNPCFactory = new NPCFactory(3f, new Vector2(3, 3), obstacles, animationFactory, npcStyles);

            // initialize characters
            npcStill = calmNPCFactory.CreateRandomNPC(new Vector2(150, 100));
            npcWalk = walkingNPCFactory.CreateRandomNPC(new Vector2(200, 100));
            npcRun = panicNPCFactory.CreateRandomNPC(new Vector2(250, 100));

            npcs = new List<NPC> { npcStill, npcWalk, npcRun };
            orderManager = new OrderManager(npcs, bubbleTexture, orderFont);
            orders = orderManager.GenerateOrders(1, 5);

            player = new MainCharacter(animationMainCharManager, 4f, new Vector2(400, 100), new Vector2(4f, 4f), obstacles);
            cat = new Friend(animationCatManager, 2f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, obstacles);

            // UI
            bookCount = new UIBookCount(font, new Vector2(10, 10), player);
            bubble = new Bubble(bubbleTexture, orderFont);
            bubble.SetPosition(new Vector2(400, 400));
            bubble.SetMessage("This is a test test test"+Environment.NewLine +"  akjajaa;kadga;kfg;angjakg;agjn;");

            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, ..orders, cat, player, bookCount, bubble];
        }

        /// <summary>
        /// Checks if the player has picked up a book and removes it from the drawn books
        /// </summary>
        private void CheckBookPickUp()
        {
            foreach (Book book in books)
            {
                if (player.ColBox.IsCollidingWith(book.ColBox))
                {
                    booksToBeDeleted.Add(book);
                    player.PickUpBook();
                }
            }
            foreach (Book book in booksToBeDeleted)
            {
                books.Remove(book);
            }
            booksToBeDeleted.Clear();
        }
    }
}
