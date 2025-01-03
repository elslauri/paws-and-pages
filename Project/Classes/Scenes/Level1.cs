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

        // npc
        private Texture2D joggingIdleTexture;
        private Texture2D joggingUpTexture;
        private Texture2D joggingLeftTexture;
        private Texture2D joggingDownTexture;
        private Texture2D joggingRightTexture;

        private Texture2D dressIdleTexture;


        private NPC npcStill;
        private NPC npcWalk;
        private NPC npcRun;
        //mc
        private Texture2D mcIdleTexture;
        private Texture2D mcWalkDownTexture;
        private Texture2D mcWalkLeftDownTexture;
        private Texture2D mcWalkLeftUpTexture;
        private Texture2D mcWalkRightDownTexture;
        private Texture2D mcWalkRightUpTexture;
        private Texture2D mcWalkUpTexture;
        private MainCharacter player;
        //cat
        private Texture2D catTextureIdle;
        private Texture2D catTextureRunLeft;
        private Texture2D catTextureRunRight;
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
//        private AnimationManager animationNPCManager;

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
        private UIBookCount ui;
        private SpriteFont font;

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
            tileTexture = content.Load<Texture2D>("Background/planks_H_3");
            joggingIdleTexture = content.Load<Texture2D>("Characters/npc/jogging_idle");
            joggingUpTexture = content.Load<Texture2D>("Characters/npc/jogging_up");
            joggingLeftTexture = content.Load<Texture2D>("Characters/npc/jogging_left");
            joggingDownTexture = content.Load<Texture2D>("Characters/npc/jogging_down");
            joggingRightTexture = content.Load<Texture2D>("Characters/npc/jogging_right");

            dressIdleTexture = content.Load<Texture2D>("Characters/npc/dress_idle");
            
            
            
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");
            catTextureRunLeft = content.Load<Texture2D>("Characters/friend/friend_run_left");
            catTextureRunRight = content.Load<Texture2D>("Characters/friend/friend_run_right");

            mcIdleTexture = content.Load<Texture2D>("Characters/MC/idle_down");
            mcWalkDownTexture = content.Load<Texture2D>("Characters/MC/walk_down");
            mcWalkLeftDownTexture = content.Load<Texture2D>("Characters/MC/walk_left_down");
            mcWalkLeftUpTexture = content.Load<Texture2D>("Characters/MC/walk_left_up");
            mcWalkRightDownTexture = content.Load<Texture2D>("Characters/MC/walk_right_down");
            mcWalkRightUpTexture = content.Load<Texture2D>("Characters/MC/walk_right_up");
            mcWalkUpTexture = content.Load<Texture2D>("Characters/MC/walk_up");

            longBookshelveTexture = content.Load<Texture2D>("Background/longFilledBookshelve");
            shortBookshelveTexture = content.Load<Texture2D>("Background/shortFilledBookshelve");
            bookTexture = content.Load<Texture2D>("Items/bookClosed");

            font = content.Load<SpriteFont>("LevelFont");
            
            
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

            Camera.GetTheCamera().Update(gameTime);


            // test collision TODO: move to other file
            if (player.ColBox.IsCollidingWith(npcStill.ColBox))
            {
                Debug.WriteLine("PARDON ME");
            }

            CheckBookPickUp();
            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, cat, player, ui];

        }
        public override void Draw()
        {
            drawingManager.Draw(drawables, true);
        }

        private void SetAnimations()
        {
            animationFactory = new AnimationFactory();

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


            animationCatManager = new AnimationManager();
            var idleCat = animationFactory.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            var runCat_left = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunLeft, 6, 1);
            var runCat_right = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunRight, 6, 1);
            animationCatManager.AddAnimation(AnimationState.Idle, idleCat);
            animationCatManager.AddAnimation(AnimationState.Walk_Left, runCat_left);
            animationCatManager.AddAnimation(AnimationState.Walk_Right, runCat_right);

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
            books = bookSpawnManager.SpawnBooks(bookTexture,bookshelves);

            // initialize NPC styles
            npcStyles = new List<INPCStyle>()
            { //TODO: add all them styles here after loading their textures AND write new animation strategy
                new NPCStyle(joggingIdleTexture,joggingUpTexture,joggingLeftTexture,joggingRightTexture,joggingDownTexture),
              //  new NPCStyle(dressIdleTexture, dressIdleTexture, dressIdleTexture, dressIdleTexture, dressIdleTexture)
            };

            // Initialize npc factories
            calmNPCFactory = new NPCFactory(3f, new Vector2(0, 0), obstacles, animationFactory, npcStyles);
            walkingNPCFactory = new NPCFactory(3f, new Vector2(1, 1), obstacles, animationFactory, npcStyles);
            panicNPCFactory = new NPCFactory(3f, new Vector2(3, 3), obstacles, animationFactory, npcStyles);

            // initialize characters
            npcStill = calmNPCFactory.CreateRandomNPC(new Vector2(150, 100));
            npcWalk = walkingNPCFactory.CreateRandomNPC(new Vector2(200, 100));
            npcRun = panicNPCFactory.CreateRandomNPC(new Vector2(250, 100));

            player = new MainCharacter(animationMainCharManager, 4f, new Vector2(400, 100), new Vector2(4f, 4f), obstacles);
            cat = new Friend(animationCatManager, 2f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, obstacles);

            // UI
            ui = new UIBookCount(font, new Vector2(10, 10), player);


            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, cat, player, ui];
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
