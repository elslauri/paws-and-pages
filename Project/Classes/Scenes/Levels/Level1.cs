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
using Project.Classes.Visualize.Animations.AnimationStrategies;
using Project.Classes.Visuals;
using Project.Classes.Visuals.Animations;
using System.Collections.Generic;


namespace Project.Classes.Scenes.Levels
{
    internal class Level1 : Level
    {
       
        // AAADFA


        
        private NPC npcStill;
        private NPC npcWalk;
        private NPC npcRun;

        // background
       private Texture2D shortBookshelveTexture; // TODO: do something with this

       

        public Level1(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, int[,] floorPlan)
            : base(graphics, spriteBatch, content, gameManager, floorPlan)
        { }

        public override void Initialize()
        {
            base.Initialize();
        }
        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            npcStill.Update(gameTime);
            npcWalk.Update(gameTime);
            npcRun.Update(gameTime);
            


            drawables = [map, .. bookshelves, .. books, npcStill, npcWalk, npcRun, .. orders, cat, player, bookCount];

            
        }
        public override void Draw()
        {
            base.Draw();
        }

        
        protected override void InitializeGameObjects()
        {
            base.InitializeGameObjects(); // TODO: check this works

            bookSpawnManager = new BookSpawnManager(); // TODO: add chance back to contructor? levelspecific
            books.AddRange(bookSpawnManager.SpawnBooks(bookTexture, bookshelves));

            // TODO: initialize npcs list / loop
            npcStill = calmNPCFactory.CreateRandomNPC(new Vector2(150, 100));
            npcWalk = walkingNPCFactory.CreateRandomNPC(new Vector2(200, 100));
            npcRun = panicNPCFactory.CreateRandomNPC(new Vector2(250, 100));

            npcs.AddRange([npcStill, npcWalk, npcRun]);

            orderManager = new OrderManager(npcs, bubbleTexture, orderFont);
            orders = orderManager.GenerateOrders(1, 1); // TODO: this is levelspecific

            drawables.AddRange([.. books, .. orders, .. npcs]);

        }
    }
}
