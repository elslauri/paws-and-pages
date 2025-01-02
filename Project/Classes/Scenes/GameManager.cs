
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.Animations;
using Project.Classes.Collision;
using Project.Classes.GameObjects.Background;
using Project.Classes.GameObjects.Characters;
using Project.Classes.GameObjects.Items;
using Project.Classes.Visuals;
using Project.Classes.UI;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project.Classes.Scenes
{
    internal class GameManager : IGameManager
    {
        private List<IDraw> drawables;
        private List<ICollidable> obstacles;

        private DrawingManager drawingManager;

        // TODO: move loading textures
        // characters
        private Texture2D npc_basicMan_Texture;
        private NPC npcStill;
        private NPC npcWalk;
        private NPC npcRun;
        private Texture2D mcTextureIdleD;
        private Texture2D mcTextureWalkF;
        private MainCharacter player;
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

        //texture for box collision
        private Texture2D blockTexture;

        private AnimationFactory animationFactory;
        private AnimationManager animationMainCharManager;
        private AnimationManager animationCatManager;
        private AnimationManager animationNPCManager;

        private NPCFactory calmNPCFactory;
        private NPCFactory walkingNPCFactory;
        private NPCFactory panicNPCFactory;

        private BookshelveFactory bookshelveFactory;
        private Texture2D bookTexture;

        private List<Book> books;
        private List<Book> booksToBeDeleted;

        //UI
        private UIBookCount ui;
        private SpriteFont font;

        public void Initialize(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content)
        {
            drawingManager = new DrawingManager(spriteBatch);

            LoadContent(content);
            
            GetAnimations();

            InitializeGameObjects();

            Camera.GetTheCamera().Initialize(map, player);

        }

        private void LoadContent(ContentManager content)
        {
            tileTexture = content.Load<Texture2D>("Background/planks_H_3");
            npc_basicMan_Texture = content.Load<Texture2D>("npc_basicMan_walkF_fluid");
            catTextureIdle = content.Load<Texture2D>("Characters/friend/friend_idle");
            catTextureRunLeft = content.Load<Texture2D>("Characters/friend/friend_run_left");
            catTextureRunRight = content.Load<Texture2D>("Characters/friend/friend_run_right");

            mcTextureIdleD = content.Load<Texture2D>("Characters/MC/MC_Idle_Down");
            mcTextureWalkF = content.Load<Texture2D>("Characters/MC/MC_walk_Down");
            longBookshelveTexture = content.Load<Texture2D>("Background/longFilledBookshelve");
            shortBookshelveTexture = content.Load<Texture2D>("Background/shortFilledBookshelve");
            bookTexture = content.Load<Texture2D>("Items/bookClosed");

            font = content.Load<SpriteFont>("MenuFont");
        }
        private void GetAnimations()
        {
            animationFactory = new AnimationFactory();
            animationMainCharManager = new AnimationManager();
            var idleMC = animationFactory.CreateAnimationFromSpriteSheet(mcTextureIdleD, 8, 1);
            var runMC = animationFactory.CreateAnimationFromSpriteSheet(mcTextureWalkF, 8, 1);
            animationMainCharManager.AddAnimation("Idle", idleMC);
            animationMainCharManager.AddAnimation("Run", runMC);
            animationCatManager = new AnimationManager();
            var idleCat = animationFactory.CreateAnimationFromSpriteSheet(catTextureIdle, 8, 1);
            var runCat_left = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunLeft, 6, 1);
            var runCat_right = animationFactory.CreateAnimationFromSpriteSheet(catTextureRunRight, 6, 1);
            animationCatManager.AddAnimation("Idle", idleCat);
            animationCatManager.AddAnimation("Run_left", runCat_left);
            animationCatManager.AddAnimation("Run_right", runCat_right);
            animationNPCManager = new AnimationManager();
            var idleNpc = animationFactory.CreateAnimationFromSpriteSheet(npc_basicMan_Texture, 7, 1);
            animationNPCManager.AddAnimation("Idle", idleNpc);


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
                };  // 7,11
            bookshelveFactory = new BookshelveFactory(longBookshelveTexture);
            bookshelves = bookshelveFactory.CreateBookshelves(new Vector2(50, 250), floorPlan, 192, 200);

            obstacles = [.. bookshelves];

            booksToBeDeleted = new List<Book>();
            books = new List<Book>();
            for (int j = 530; j < 630; j += 100)
            {
                for (int i = 130; i <= 1300; i += 192)
                {
                    books.Add(new Book(bookTexture, new Vector2(0 + i, j)));
                }
            }

            // Initialize characters
            calmNPCFactory = new NPCFactory(3f, new Vector2(0, 0), obstacles, blockTexture);
            npcStill = calmNPCFactory.CreateNPC(animationNPCManager, new Vector2(150, 100));
            walkingNPCFactory = new NPCFactory(3f, new Vector2(1, 1), obstacles, blockTexture);
            npcWalk = walkingNPCFactory.CreateNPC(animationNPCManager, new Vector2(200, 100));
            panicNPCFactory = new NPCFactory(3f, new Vector2(3, 3), obstacles, blockTexture);
            npcRun = panicNPCFactory.CreateNPC(animationNPCManager, new Vector2(250, 100));


            player = new MainCharacter(animationMainCharManager, 4f, new Vector2(400, 100), new Vector2(4f, 4f), obstacles, blockTexture);
            cat = new Friend(animationCatManager, 2f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, obstacles, blockTexture);

            // UI
            ui = new UIBookCount(font, new Vector2(10, 10), player);


            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, cat, player, ui];
        }

        public void Update(GameTime gameTime)
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

        public void Draw(GameTime gameTime)
        {
            drawingManager.Draw(drawables);
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
