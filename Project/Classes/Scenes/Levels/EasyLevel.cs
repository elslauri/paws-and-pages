using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.GameObjects.Items;


namespace Project.Classes.Scenes.Levels
{
    internal class EasyLevel : Level
    {
        
        private NPC npcStill;
        private NPC npcWalk;
        private NPC npcRun;


        public EasyLevel(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, int[,] floorPlan, int minBooksPerOrder, int maxBooksPerOrder)
            : base(graphics, spriteBatch, content, gameManager, floorPlan, minBooksPerOrder, maxBooksPerOrder)
        {
        }

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
            base.InitializeGameObjects();


            books.AddRange(bookSpawnManager.SpawnBooks(bookTexture, bookshelves, 0.7f)); // TODO: make less for levl2

            // TODO: initialize npcs list / loop
            npcStill = calmNPCFactory.CreateRandomNPC(new Vector2(150, 100));
            npcWalk = walkingNPCFactory.CreateRandomNPC(new Vector2(200, 100));
            npcRun = panicNPCFactory.CreateRandomNPC(new Vector2(500, 700));

            npcs.AddRange([npcStill, npcWalk, npcRun]);

            orderManager = new OrderManager(npcs, bubbleTexture, orderFont);
            orders = orderManager.GenerateOrders(minBooksPerOrder, maxBooksPerOrder); 

            drawables.AddRange([.. books, .. orders, .. npcs]);

        }
    }
}
