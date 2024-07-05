using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sample;
public class Game1 : Game
{
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 200f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        ballTexture = Content.Load<Texture2D>("ball");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        // 判断是否移出边界
        if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
        {
            ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
        }
        else if (ballPosition.X < ballTexture.Width / 2)
        {
            ballPosition.X = ballTexture.Width / 2;
        }

        if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
        {
            ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
        }
        else if (ballPosition.Y < ballTexture.Height / 2)
        {
            ballPosition.Y = ballTexture.Height / 2;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(
            ballTexture,
            ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
