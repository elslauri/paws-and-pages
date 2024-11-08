using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _charTexture;
    private Rectangle _charTextureRectangle;
    private int moveCharTextureX = 0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _charTextureRectangle = new Rectangle(moveCharTextureX, 0, 32, 32);

        // Rescale window
        _graphics.PreferredBackBufferWidth = 1600;
        _graphics.PreferredBackBufferHeight = 960;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
    

        // TODO: use this.Content to load your game content here
        _charTexture = Content.Load<Texture2D>("char_global");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(_charTexture, new Vector2(0, 0),_charTextureRectangle, Color.White);
        _spriteBatch.End();

        moveCharTextureX += 32;
        if (moveCharTextureX > 256)
        {
            moveCharTextureX = 0;
        }
        _charTextureRectangle.X = moveCharTextureX;


        base.Draw(gameTime);
    }
}