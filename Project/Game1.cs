using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.GameObjects.Characters;
using System.Diagnostics;
using Project.Classes.GameObjects.Items;
using Project.Classes.Collision;
using System.Collections.Generic;
using Project.Classes;
using Project.Classes.Animations;
using Project.Classes.GameObjects.Background;
using Project.Classes.Visuals;
using Project.Classes.UI;


namespace Project;

public class Game1 : Game
{
    // TODO: make a game manager with draw and update instead of here ? levels 

    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private DrawingManager drawingManager;

    private List<IDraw> drawables;
    private List<ICollidable> obstacles;

    // TODO: move loading textures
    // characters
    private Texture2D npc_basicMan_Texture;
    private NPC testChar;
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
    private Texture2D bookshelveTexture;


    //texture for box collision
    private Texture2D blockTexture;
    
    private AnimationFactory animationFactory;
    private AnimationManager animationMainCharManager;
    private AnimationManager animationCatManager;
    private AnimationManager animationNPCManager;

    private BookshelveFactory bookshelveFactory;
    private Texture2D bookTexture;

    private List<Book> books;
    private List<Book> booksToBeDeleted;

    //UI
    private UI ui;
    private SpriteFont font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        // Rescale window -> TODO: move to a globals class?
        _graphics.PreferredBackBufferWidth = Globals.windowSizeX;
        _graphics.PreferredBackBufferHeight = Globals.windowSizeY;
        _graphics.ApplyChanges();

        base.Initialize();


        drawingManager = new DrawingManager(spriteBatch);

        // for animations
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
        var idleNpc = animationFactory.CreateAnimationFromSpriteSheet(npc_basicMan_Texture, 7,1);
        animationNPCManager.AddAnimation("Idle", idleNpc);

        

        // add background and blocks
        map = new Map([tileTexture]);


        bookshelveFactory = new BookshelveFactory(bookshelveTexture);
        bookshelves = bookshelveFactory.CreateBookshelves(new Vector2(50,300),5,6,192,200);

        obstacles = [.. bookshelves];

        booksToBeDeleted = new List<Book>();
        books = new List<Book>();
        for (int j = 450; j <550; j+=100)
        {
            for (int i = 150; i <= 1050; i+=200)
            {
                books.Add(new Book(bookTexture, new Vector2(0+i,j)));
            }
        }

        // Initialize characters
        testChar = new NPC(animationNPCManager, 3f, new Vector2(150, 100), new Vector2(2f, 2f), obstacles, blockTexture);
        
        player = new MainCharacter(animationMainCharManager, 4f, new Vector2(400, 100), new Vector2(4f, 4f), obstacles, blockTexture);
        cat = new Friend(animationCatManager, 2f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, obstacles, blockTexture);

        // UI
        ui = new UI(font, new Vector2(10,10), player);


        drawables = [map, .. bookshelves, .. books, testChar, cat, player, ui];

        // camera 
        Camera.GetTheCamera().Initialize(map, player);

    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        tileTexture = Content.Load<Texture2D>("Background/planks_H_3");
        npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF_fluid");
        catTextureIdle = Content.Load<Texture2D>("Characters/friend/friend_idle");
        catTextureRunLeft = Content.Load<Texture2D>("Characters/friend/friend_run_left");
        catTextureRunRight = Content.Load<Texture2D>("Characters/friend/friend_run_right");

        mcTextureIdleD = Content.Load<Texture2D>("Characters/MC/MC_Idle_Down");
        mcTextureWalkF = Content.Load<Texture2D>("Characters/MC/MC_walk_Down");
        bookshelveTexture = Content.Load<Texture2D>("Background/filledbookshelves");
        bookTexture = Content.Load<Texture2D>("Items/bookClosed");

        font = Content.Load<SpriteFont>("MenuFont");


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        testChar.Update(gameTime);
        cat.Update(gameTime);
        player.Update(gameTime);

        Camera.GetTheCamera().Update(gameTime);

        base.Update(gameTime);

        // test collision TODO: move to other file
        if (player.ColBox.IsCollidingWith(testChar.ColBox))
        {
            Debug.WriteLine("PARDON ME");
        }

        CheckBookPickUp();
        drawables = [map, .. bookshelves, .. books, testChar, cat, player, ui];

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52, 52, 79)); 

        // TODO: Add your drawing code here

        drawingManager.Draw(drawables);

        //spriteBatch.Begin();
        //// background
        //foreach (var block in blocks)
        //{
        //    block.Draw(spriteBatch);
        //}
        //testChar.Draw(spriteBatch);
        //cat.Draw(spriteBatch);
        //player.Draw(spriteBatch);
        //spriteBatch.End();


        base.Draw(gameTime);
    }

    private void CheckBookPickUp()
    {
        foreach(Book book in books)
        {
            if (player.ColBox.IsCollidingWith(book.ColBox))
            {
                booksToBeDeleted.Add(book);
                player.PickUpBook();
            }
        }
        foreach(Book book in booksToBeDeleted)
        {
            books.Remove(book);
        }
        booksToBeDeleted.Clear();
    }

}