using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project.Classes.GameObjects.Characters.NPC;
using Project.Classes.GameObjects.Items;


namespace Project.Classes.Scenes.Levels
{
    internal class EasyLevel : Level
    {
        public EasyLevel(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, ContentManager content, GameManager gameManager, LevelConfiguration config)
            : base(graphics, spriteBatch, content, gameManager, config)
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

            foreach (NPC npc in npcs)
            {
                npc.Update(gameTime);
            }

            drawables = [map, .. bookshelves, .. books, .. npcs, .. orders, cat, player, bookCount];

        }
        public override void Draw()
        {
            base.Draw();
        }


        protected override void InitializeGameObjects()
        {
            base.InitializeGameObjects();


            books.AddRange(bookSpawnManager.SpawnBooks(bookTexture, bookshelves, 0.6f));



            foreach (var (position, moveType) in npcData)
            {
                var npc = npcFactory.CreateRandomNPC(position, moveType);
                npcs.Add(npc);
            }


            orderManager = new OrderManager(npcs, bubbleTexture, orderFont);
            orders = orderManager.GenerateOrders(minBooksPerOrder, maxBooksPerOrder);

            drawables.AddRange([.. books, .. orders, .. npcs]);

        }
    }
}
