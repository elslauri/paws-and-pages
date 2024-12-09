using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Input;
using Project.Classes.Background;
using Project.Classes.GameObjects.Characters;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using System;
using System.Diagnostics;
using Project.Classes.GameObjects.Items;
using Project.Classes.Collision;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using Project.Classes.Animations;
using System.Runtime.InteropServices.ObjectiveC;


namespace Project;

public class Game1 : Game
{
    // TODO: make a game manager with draw and update instead of here

    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private DrawingManager drawingManager;

    private List<Classes.GameObjects.IDrawable> drawables;

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
    private Floor tile;
    private Texture2D tileTexture;
    int[,] gameboard = new int[,]
{
    { 1,1,1,1,1,1,1,1 },
    { 0,0,1,1,0,1,1,1 },
    { 1,0,0,0,0,0,0,1 },
    { 1,1,1,1,1,1,0,1 },
    { 1,0,0,0,0,0,0,2 },
    { 1,0,1,1,1,1,1,2 },
    { 1,0,0,0,0,0,0,0 },
    { 1,1,1,1,1,1,1,1 }
};
    private List<Box> blocks;

    private Map map;
    private Matrix translation;

    private int windowSizeX = 1600;
    private int windowSizeY = 960;

    //block
    private Texture2D blockTexture;
    private Box test1;
    private Box test2;
    private List<ICollidable> obstaclesMC;



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
        _graphics.PreferredBackBufferWidth = windowSizeX;
        _graphics.PreferredBackBufferHeight = windowSizeY;
        _graphics.ApplyChanges();

        base.Initialize();

        
       

        // block

        test1 = new Box(blockTexture, new Vector2(300, 300), new Vector2(100, 100), new Color(4294633190u));
        test2 = new Box(blockTexture, new Vector2(500, 300), new Vector2(100, 100), new Color(4283465727u));

        obstaclesMC = new List<ICollidable> { test1, test2 };

        // background
        blocks = new List<Box>();

        // Initialize characters
        tile = new Floor(tileTexture, 2f, new Vector2(50, 50));
        testChar = new NPC(npc_basicMan_Texture, 7, 1, 3f, new Vector2(100, 100), new Vector2(2f, 2f), blockTexture);
        player = new MainCharacter(mcTextureIdleD, 8, 1, 4f, new Vector2(0, 0), new Vector2(4f, 4f), obstaclesMC, blockTexture);
        cat = new Friend(catTexture, 6, 1, 1f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player, blockTexture);

        drawables = new List<Classes.GameObjects.IDrawable>();
        drawingManager = new DrawingManager(spriteBatch);

        // add background and blocks
        map = new Map([tileTexture]);
        drawables.Add(map);

        drawables.Add(player);
        drawables.Add(testChar);
        drawables.Add(cat);
        drawables.Add(test1);
    


    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        tileTexture = Content.Load<Texture2D>("Background/planks_H_3");
        npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF_fluid");
        catTexture = Content.Load<Texture2D>("Characters/friend_Walk");
        mcTextureIdleD = Content.Load<Texture2D>("Characters/MC/MC_Idle_Down (2)");

        // texture 1px 1px
        blockTexture = new Texture2D(GraphicsDevice, 1, 1);
        blockTexture.SetData([Color.LavenderBlush]);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        tile.Update(gameTime);
        testChar.Update(gameTime);
        cat.Update(gameTime);
        player.Update(gameTime);

        test1.Update(gameTime);
        test2.Update(gameTime);

        // blocks

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

        CalculateTranslation(); // moves camera        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52, 52, 79)); // TODO: change background

        // TODO: Add your drawing code here

        drawingManager.Draw(drawables, translation);

        //spriteBatch.Begin();
        //// background
        //foreach (var block in blocks)
        //{
        //    block.Draw(spriteBatch);
        //}
        //tile.Draw(spriteBatch);
        //testChar.Draw(spriteBatch);
        //cat.Draw(spriteBatch);
        //player.Draw(spriteBatch);
        //// block
        //test1.Draw(spriteBatch);
        //test2.Draw(spriteBatch);

        //spriteBatch.End();



        base.Draw(gameTime);
    }

    private void CalculateTranslation()
    {
        var dx = (windowSizeX / 2) - player.Position.X;
        var dy = (windowSizeY / 2) - player.Position.Y;
        translation = Matrix.CreateTranslation(dx, dy, 0);
    }

    private void CreateBlocks()
    {
        blocks = new List<Box>();
        for (int l = 0; l < gameboard.GetLength(0); l++)
        {
            for (int c = 0; c < gameboard.GetLength(1); c++)
            {
                if (gameboard[l, c] == 1)
                {
                    blocks.Add(new Box(blockTexture, new Vector2((c * 100), (l * 100)), new Vector2(100, 100), Color.LightGoldenrodYellow));

                }
                else if (gameboard[l, c] == 2)
                {
                    blocks.Add(new Box(blockTexture, new Vector2((c * 100), (l * 100)), new Vector2(100, 100), Color.MediumOrchid));

                }

            }
        }

    }

}