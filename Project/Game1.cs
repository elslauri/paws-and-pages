using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes;
using Project.Classes.Input;
using Project.Classes.Background;
using Project.Classes.GameObjects.Characters;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using Project.Classes.GameObjects;
using System;
using System.Diagnostics;


namespace Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;

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

    //block
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

        // Rescale window
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 960;
        _graphics.ApplyChanges();

        base.Initialize();

        // Initialize characters
        tile = new Floor(tileTexture, 2f, new Vector2(50, 50));
        testChar = new NPC(npc_basicMan_Texture, 7, 3f, new Vector2(100, 100), new Vector2(2f, 2f));
        player = new MainCharacter(mcTextureIdleD, 8, 4f, new Vector2(0, 0), new Vector2(4f, 4f));
        cat = new Friend(catTexture, 6, 1f, new Vector2(200, 200), new Vector2(0.5f, 0.5f), player);

        // block
        test1 = new Box(blockTexture, new Vector2(300, 300), new Vector2(100, 100), new Color(4294633190u));
        test2 = new Box(blockTexture, new Vector2(500, 300), new Vector2(100, 100), new Color(4283465727u));

    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        tileTexture = Content.Load<Texture2D>("Background/planks_H");
        npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF_fluid");
        catTexture = Content.Load<Texture2D>("Characters/friend_Walk");
        mcTextureIdleD = Content.Load<Texture2D>("Characters/MC/MC_Idle_Down");

        // texture 1px 1px
        blockTexture = new Texture2D(GraphicsDevice, 1, 1);
        blockTexture.SetData(new[] { Color.LavenderBlush });
        
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

        base.Update(gameTime);

        // test collision
        if (test1.Rectangle.Intersects(player.BoxCollission.Rectangle))
        {
            Debug.WriteLine("COLLISION");
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52, 52, 79)); // TODO: change background

        // TODO: Add your drawing code here
        spriteBatch.Begin();
        tile.Draw(spriteBatch);
        testChar.Draw(spriteBatch);
        cat.Draw(spriteBatch);
        player.Draw(spriteBatch);
        // block
        test1.Draw(spriteBatch);
        test2.Draw(spriteBatch);
        spriteBatch.End();

        

        base.Draw(gameTime);
    }
}