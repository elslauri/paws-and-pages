using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes;
using Project.Classes.GameObjects;
using Project.Classes.Input;
using Project.Classes.Background;

namespace Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // TODO: move loading textures
    // characters
    private Texture2D npc_basicMan_Texture;
    private NPC testChar;
    private Texture2D mcTexture;
    private MainCharacter player;
    private Texture2D catTexture;
    private Friend cat;
    // background
    private Floor tile;
    private Texture2D tileTexture;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
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
        testChar = new NPC(npc_basicMan_Texture, 7, new Vector2(0, 0), 3f);
        player = new MainCharacter(new KeyboardReader(),mcTexture,8, new Vector2(0, 0), 4f);
        cat = new Friend(catTexture, 6,1f,new Vector2(100, 100), new Vector2(0.5f, 0.5f));
        tile = new Floor(tileTexture, new Vector2(50,50),2f);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    
        // TODO: use this.Content to load your game content here

       npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF_fluid");
       mcTexture = Content.Load<Texture2D>("Characters/MC/MC_Idle_Down");
        catTexture = Content.Load<Texture2D>("Characters/friend_Walk");
        tileTexture = Content.Load<Texture2D>("Background/planks_H");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        testChar.Update(gameTime);
        player.Update(gameTime);
        cat.Update(gameTime);
        tile.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(52,52,79)); // TODO: change background

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        testChar.Draw(_spriteBatch);
        player.Draw(_spriteBatch);
        cat.Draw(_spriteBatch);
        tile.Draw(_spriteBatch);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}