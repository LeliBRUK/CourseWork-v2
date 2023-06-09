using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

namespace Collison_Tiles
{
  internal class Knight
  {
    // old knight texture
    // protected Texture2D knightTexture;

    protected NewAnimations IdleAnimation;
    protected NewAnimations WalkAnimation;
    protected NewAnimations JumpAnimation;

    // todo add these maybe
    // protected NewAnimations AttackAnimation;
    // protected NewAnimations HurtAnimation;
    // protected NewAnimations ProtectAnimation;
    // protected NewAnimations DeadAnimation;

    protected NewAnimations currentAnimation;

    protected int direction = 1;

    protected Vector2 position = new Vector2(576, 764);
    protected Vector2 velocity;
    protected bool HasJumped = false;

    private Rectangle rectangle;

    //Not used yet
    private int Health = 5;

    public Knight() { }
    public Vector2 Position { get { return position; } }

    public virtual void Load(ContentManager Content)
    {
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
