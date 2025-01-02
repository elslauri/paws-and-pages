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
using Project.Classes.Scenes;


namespace Project;

public class Game1 : Game
{
    // TODO: make a game manager with draw and update instead of here ? levels 

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private GameManager gameManager;
    

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        gameManager = new GameManager();
    }

    protected override void Initialize()
    {
        ConfigureGraphics();

        base.Initialize();

        gameManager.Initialize(graphics, spriteBatch, Content);
        
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        gameManager.Update(gameTime);

        base.Update(gameTime);

    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52, 52, 79));

        gameManager.Draw(gameTime);

        base.Draw(gameTime);
    }
    private void ConfigureGraphics()
    {
        graphics.PreferredBackBufferWidth = Globals.windowSizeX;
        graphics.PreferredBackBufferHeight = Globals.windowSizeY;
        graphics.ApplyChanges();
    }
}