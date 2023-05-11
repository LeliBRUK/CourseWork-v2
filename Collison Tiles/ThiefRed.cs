using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Collison_Tiles
{
  internal class ThiefRed : Thief
  {
    public ThiefRed() {}

    public override void Load(ContentManager Content)
    {
      // old spritesheet
      // Thief_R = Content.Load<Texture2D>("Sprites/Thief_Red");

      Texture2D texture;

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/walk");
      walkAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/idle");
      idleAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/jump");
      jumpAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);
      
      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Red/shuriken");
      throwingAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6, 1.0f, 30f);

      base.Load(Content);
    }

    protected override void Input(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Left))
      {
        velocity.X = -4f;

        currentAnimation = walkAnimation;
        direction = -1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.Right))
      {
        velocity.X = +4f;
        
        currentAnimation = walkAnimation;
        direction = 1;
      }
      else
      {
        if (!HasJumped && !throwing)
          currentAnimation = idleAnimation;
        velocity.X = 0f;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Up) && HasJumped == false)
      {
        position.Y -= 1f;
        velocity.Y = -11f;
        HasJumped = true;
        jumpSound.SOUND_INSTANCE.Play();
        currentAnimation = jumpAnimation;
      }

      if (currentKeyboardState.IsKeyDown(Keys.RightShift) && previousKeyboardState.IsKeyUp(Keys.RightShift) &&
          HasJumped == true && HasDoubleJumped == false && CurrentDoubleJump > 0)
      {
        position.Y -= 1f;
        velocity.Y = -9f;
        HasDoubleJumped = true;
        jumpSound.SOUND_INSTANCE.Play();
        CurrentDoubleJump--;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Down))
      {
        throwing = true;
        currentAnimation = throwingAnimation;
      }
    }
  }
}
