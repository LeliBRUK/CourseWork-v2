using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Audio;

namespace Collison_Tiles
{
  internal class Thief
  {
    public static Sound shurikenSound;
    protected static Sound jumpSound;

    protected NewAnimations idleAnimation;
    protected NewAnimations walkAnimation;
    protected NewAnimations jumpAnimation;
    protected NewAnimations throwingAnimation;

    protected NewAnimations currentAnimation;

    protected Boolean throwing;
    protected int direction = 1;

    protected Vector2 position = new Vector2(576, 764);
    protected Vector2 velocity;
    private Rectangle rectangle;

    protected bool HasJumped;
    protected bool HasDoubleJumped;

    static TimeSpan DoubleJumpRecharge = TimeSpan.FromSeconds(10);
    private TimeSpan elapsedTime;

    int MaxDoubleJump = 3;
    protected int CurrentDoubleJump = 3;

    protected KeyboardState currentKeyboardState;
    protected KeyboardState previousKeyboardState;

    public Thief() {}
    public Vector2 Position { get { return position; } }

    public virtual void Load(ContentManager Content)
    {
      SoundEffect soundEffect;

      soundEffect = Content.Load<SoundEffect>("audio/thiefJump");
      jumpSound = new Sound(soundEffect);

      soundEffect = Content.Load<SoundEffect>("audio/shuriken");
      shurikenSound = new Sound(soundEffect);

      currentAnimation = idleAnimation;
    }

    protected virtual void Input(GameTime gameTime)
    {
      currentAnimation = idleAnimation;
    }

    public void Update(GameTime gameTime)
    {
      position += velocity;
      rectangle = new Rectangle((int)position.X, (int)position.Y, currentAnimation.frameWidth, currentAnimation.frameHeight);
      currentAnimation.Update(gameTime);

      previousKeyboardState = currentKeyboardState;
      currentKeyboardState = Keyboard.GetState();

      elapsedTime += gameTime.ElapsedGameTime;
      if (elapsedTime >= DoubleJumpRecharge)
      {
        elapsedTime -= DoubleJumpRecharge;
        if (CurrentDoubleJump < MaxDoubleJump)
        {
          CurrentDoubleJump++;
        }
      }

      Input(gameTime);

      if (velocity.Y < 10)
        velocity.Y += 0.4f;

      if (throwing)
        if (currentAnimation.Completed(gameTime))
          throwing = false;
    }

    public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
    {
      if (rectangle.TouchTopOf(newRectangle))
      {
        rectangle.Y = newRectangle.Y - rectangle.Height;
        velocity.Y = 0f;
        HasJumped = false;
        HasDoubleJumped = false;
      }

      if (rectangle.TouchLeftOf(newRectangle))
        position.X = newRectangle.X - rectangle.Width - 2;

      if (rectangle.TouchRightOf(newRectangle))
        position.X = newRectangle.X + newRectangle.Width + 2;

      if (rectangle.TouchBottomOf(newRectangle))
        velocity.Y = Math.Max(velocity.Y, 1f);

      position.X = MathHelper.Clamp(position.X, 0f, xOffset - rectangle.Width);
      position.Y = MathHelper.Clamp(position.Y, 0f, yOffset - rectangle.Height);

      if (position.Y >= yOffset - rectangle.Height)
        velocity.Y = Math.Max(velocity.Y, 1f);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      currentAnimation.Draw(spriteBatch, position, direction);
    }
  }
}
