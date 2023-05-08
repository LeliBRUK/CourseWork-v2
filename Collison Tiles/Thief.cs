using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collison_Tiles
{
  internal class Thief
  {
    protected Texture2D Thief_B;

    protected NewAnimations IdleAnimation;
    protected NewAnimations WalkAnimation;
    protected NewAnimations JumpAnimation;

    protected NewAnimations currentAnimation;

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

    public bool Left;
    public Vector2 Position
    {
      get { return position; }
    }

    public Thief() { }

    public virtual void Load(ContentManager Content)
    {
      currentAnimation = IdleAnimation;
      // Thief_B = Content.Load<Texture2D>("Sprites/Thief_Blue");
    }

    protected virtual void Input(GameTime gameTime)
    {
      currentAnimation = IdleAnimation;
    }

    public void Update(GameTime gameTime)
    {
      position += velocity;
      rectangle = new Rectangle((int)position.X, (int)position.Y, currentAnimation.texture.Width, currentAnimation.texture.Height);
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
      {
        position.X = newRectangle.X - rectangle.Width - 2;
      }
      if (rectangle.TouchRightOf(newRectangle))
      {
        position.X = newRectangle.X + rectangle.Width + 2;
      }
      if (rectangle.TouchBottomOf(newRectangle))
      {
        velocity.Y = 1f;
      }

      if (position.X < 0)
      {
        position.X = 0f;
      }
      if (position.X > xOffset - rectangle.Width)
      {
        position.X = xOffset - rectangle.Width;
      }
      if (position.Y < 0)
      {
        velocity.Y = 1f;
      }
      if (position.Y > yOffset - rectangle.Height)
      {
        position.Y = yOffset - rectangle.Height;
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      currentAnimation.Draw(spriteBatch, position, direction);
    }
  }
}
