using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes;
using Project.Classes.GameObjects;

namespace Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D npc_basicMan_Texture;
    private Character testChar;
    private Texture2D mcTexture;
    private MainCharacter player;
    private Texture2D catTexture;
    private Friend cat;

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

        testChar = new Character(npc_basicMan_Texture, 3f, new Vector2(0,0));
        player = new MainCharacter(mcTexture, 4f, new Vector2(0, 0));
        cat = new Friend(catTexture,new Vector2(100, 100), new Vector2(1, 1));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    
        // TODO: use this.Content to load your game content here

       npc_basicMan_Texture = Content.Load<Texture2D>("npc_basicMan_walkF");
       mcTexture = Content.Load<Texture2D>("mc_Idle_Down");
        catTexture = Content.Load<Texture2D>("cat_walk");
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
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}