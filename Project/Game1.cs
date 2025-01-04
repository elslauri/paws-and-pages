using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes;
using Project.Classes.Scenes;
using Project.Classes.Sound;


namespace Project;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private GameManager gameManager;
    private MusicManager soundManager;
    private SceneManager scenemanager;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;

        scenemanager = new SceneManager();
        soundManager = new MusicManager();
        gameManager = new GameManager(scenemanager, soundManager);

    }

    protected override void Initialize()
    {
        ConfigureGraphics();

        spriteBatch = new SpriteBatch(GraphicsDevice);

        gameManager.Initialize(graphics, spriteBatch, Content);
        
        base.Initialize();

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
        GraphicsDevice.Clear(Globals.BackGroundColor);

        gameManager.Draw();

        base.Draw(gameTime);
    }
    private void ConfigureGraphics()
    {
        graphics.PreferredBackBufferWidth = Globals.WindowSizeX;
        graphics.PreferredBackBufferHeight = Globals.WindowSizeY;
        graphics.ApplyChanges();
    }
}