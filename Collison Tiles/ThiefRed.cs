using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Collison_Tiles
{
  internal class ThiefRed : Thief
  {
    public ThiefRed() { }

    public override void Load(ContentManager Content)
    {
      // old spritesheet
      // Thief_R = Content.Load<Texture2D>("Sprites/Thief_Red");

      Texture2D texture;

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/Walk");
      WalkAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/Idle");
      IdleAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/Jump");
      JumpAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      base.Load(Content);
    }

    protected override void Input(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Left))
      {
        velocity.X = -4f;

        currentAnimation = WalkAnimation;
        direction = -1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.Right))
      {
        velocity.X = +4f;
        
        currentAnimation = WalkAnimation;
        direction = 1;
      }
      else
      {
        if (!HasJumped)
          currentAnimation = IdleAnimation;
        velocity.X = 0f;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Up) && HasJumped == false)
      {
        position.Y -= 1f;
        velocity.Y = -11f;
        HasJumped = true;
        // currentAnimation = JumpAnimation;
      }

      if (currentKeyboardState.IsKeyDown(Keys.RightShift) && previousKeyboardState.IsKeyUp(Keys.RightShift) &&
          HasJumped == true && HasDoubleJumped == false && CurrentDoubleJump > 0)
      {
        position.Y -= 1f;
        velocity.Y = -9f;
        HasDoubleJumped = true;
        CurrentDoubleJump--;
      }
    }
  }
}
