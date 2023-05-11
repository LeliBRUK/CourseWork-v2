using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Collison_Tiles
{
  internal class Knight
  {
    public static Sound spikeSound;
    protected static Sound jumpSound;

    protected NewAnimations IdleAnimation;
    protected NewAnimations WalkAnimation;
    protected NewAnimations JumpAnimation;

    protected NewAnimations currentAnimation;

    // todo add these maybe
    // protected NewAnimations AttackAnimation;
    // protected NewAnimations HurtAnimation;
    // protected NewAnimations ProtectAnimation;
    // protected NewAnimations DeadAnimation;

    protected int direction = 1;

    protected Vector2 position = new Vector2(576, 764);
    protected Vector2 velocity;
    private Rectangle rectangle;

    protected bool HasJumped;

    //Not used yet
    private int Health = 5;

    public Knight() {}
    public Vector2 Position { get { return position; } }

    public virtual void Load(ContentManager Content)
    {
      SoundEffect soundEffect;

      soundEffect = Content.Load<SoundEffect>("audio/knightJump");
      jumpSound = new Sound(soundEffect);

      soundEffect = Content.Load<SoundEffect>("audio/spike");
      spikeSound = new Sound(soundEffect);

      currentAnimation = IdleAnimation;
    }

    protected virtual void Input(GameTime gameTime)
    {
      currentAnimation = IdleAnimation;
    }

    public void Update(GameTime gameTime)
    {
      position += velocity;
      rectangle = new Rectangle((int)position.X, (int)position.Y, currentAnimation.frameWidth, currentAnimation.frameHeight);
      currentAnimation.Update(gameTime);

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
