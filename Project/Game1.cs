using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Background;
using Project.Classes.GameObjects.Characters;
using System.Diagnostics;
using Project.Classes.GameObjects.Items;
using Project.Classes.Collision;
using System.Collections.Generic;
using Project.Classes;


namespace Project;

public class Game1 : Game
{
    // TODO: make a game manager with draw and update instead of here ? levels 

    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private DrawingManager drawingManager;

    private List<Classes.GameObjects.IDraw> drawables;
    private List<ICollidable> obstaclesMC;

    // TODO: move loading textures
    // characters
    private Texture2D npc_basicMan_Texture;
    private NPC testChar;
    private Texture2D mcTextureIdleD;
    //private Texture2D mcTextureWalkF;
    private MainCharacter player;
    private Texture2D catTexture;
    private Friend cat;
    // background
    private Map map;
    private Texture2D tileTexture;
    private Bookshelve bookshelve;
    private Texture2D bookshelveTexture;

    //block FOR TESTING
    private Texture2D blockTexture;
    private Box test1;
    private Box test2;

    



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

        

        // obstacles
        test1 = new Box(blockTexture, new Vector2(300, 300), new Vector2(100, 100), new Color(4294633190u));
        test2 = new Box(blockTexture, new Vector2(500, 300), new Vector2(100, 100), new Color(4283465727u));

        obstaclesMC = new List<ICollidable> { test1, test2 };


        // Initialize characters
        testChar = new NPC(npc_basicMan_Texture, 7, 1, 3f, new Vector2(100, 100), new Vector2(2f, 2f), blockTexture);
        player = new MainCharacter(mcTextureIdleD, 8, 1, 4f, new Vector2(0, 0), new Vector2(4f, 4f), obstaclesMC, blockTexture);
        cat = new Friend(catTexture, 6, 1, 1f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, blockTexture);

        
        drawingManager = new DrawingManager(spriteBatch);

        // add background and blocks
        map = new Map([tileTexture]);

        bookshelve = new Bookshelve(bookshelveTexture, new Vector2(0,0) );

        drawables = [map, test1, test2, bookshelve, testChar, cat, player];

        // camera 
        Camera.GetTheCamera().Initialize(map, player);

    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        tileTexture = Content.Load<Texture2D>("Background/planks_H_3");
        npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF_fluid");
        catTexture = Content.Load<Texture2D>("Characters/friend_Walk");
        mcTextureIdleD = Content.Load<Texture2D>("Characters/MC/MC_Idle_Down (2)");
        bookshelveTexture = Content.Load<Texture2D>("Background/filledbookshelves");

        // TESTING REMOVE texture 1px 1px
        blockTexture = new Texture2D(GraphicsDevice, 1, 1);
        blockTexture.SetData([Color.LavenderBlush]);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        testChar.Update(gameTime);
        cat.Update(gameTime);
        player.Update(gameTime);

        //test1.Update(gameTime);
        //test2.Update(gameTime);

        Camera.GetTheCamera().Update(gameTime);

        base.Update(gameTime);

        // test collision TODO: move to other file
        if (player.BoxCollision.IsCollidingWith(test1.BoxCollision))
        {
            Debug.WriteLine("COLLISION 1");
        }
        if (player.BoxCollision.IsCollidingWith(test2.BoxCollision))
        {
            Debug.WriteLine("COLLISION 2");
        }
        if (player.BoxCollision.IsCollidingWith(testChar.BoxCollision))
        {
            Debug.WriteLine("PARDON ME");
        }      
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52, 52, 79)); // TODO: change background

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
        //// block
        //test1.Draw(spriteBatch);
        //test2.Draw(spriteBatch);

       // bookshelve.Draw(spriteBatch);
        //spriteBatch.End();



        base.Draw(gameTime);
    }

}