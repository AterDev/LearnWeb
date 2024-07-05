# 游戏开发：MonnoGame

许多游戏引擎都支持使用`C#`作为脚本语言，比如`Unity`,`Godot`等，它们主要将其作为"脚本"使用。

微软对游戏有很大的投入，包括收购了`动视暴雪`，推出`Xbox`游戏机，微软曾经也有自己的游戏开发框架，那就是`XNA`。

而`MonoGame`就是基于`XNA`开发的开源游戏框架，不像其他游戏引擎，它几乎可使用了.NET生态的所有功能优势，如`nuget包`，跨平台编译等等，使用它编写游戏代码跟编写其他软件没有什么本质区别。

## 准备

我们选择`MonoGame`来做示例，用纯代码的方式去实现一些简单的功能，为些我们要做一些准备。

- 在`VS`中安装`MonoGame`插件
- 创建项目，选择`MonoGame Cross-Platform Desktop Applicatoin`模板，解决方案名称`MonoGame`，项目名为`Sample`

### 代码实现

我们实现一个简单的功能，我们通过键盘操作一个物体对象，让他在屏幕上进行移动。

修改`Game1.cs`中的代码如下:

```csharp
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
```

运行项目，使用键盘上的`上、下、左、右`去控件球的移动。

这并不是一个完整的游戏，只是一个简单的示例，具体代码不做解释，简单的来说，我们可以通过封装好的一些类，对目标对象(2D/3D等资源)进行操作，从而形成游戏交互的效果。`Update`方法是每帧都会调用的，在每帧的时间内，我们要处理各种样的逻辑，最终刷新屏幕显示最新的内容。

完整项目，可在仓库`codes\MonoGame`中找到。

## 总结

很多游戏包括游戏引擎，是基于C++实现的，但很多引擎会选择C#作为脚本语言，因为C#的开发效率和性能都是非常不错的，并且强类型语言也非常适合游戏开发。

随着.NET的发展，C#会在游戏开发领域有更大的发展，有一些游戏引擎基于最新的`.NET Core`来实现，比如`Stride Game Engine`和`MonoGame`等。
