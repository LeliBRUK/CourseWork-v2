using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Collison_Tiles
{
  internal class ThiefBlue : Thief
  {
    public ThiefBlue() {}

    public override void Load(ContentManager Content)
    {
      // old spritesheet
      // Thief_B = Content.Load<Texture2D>("Sprites/Thief_Blue");

      Texture2D texture;

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Blue/walk");
      walkAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Blue/idle");
      idleAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Blue/jump");
      jumpAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Thief/Blue/shuriken");
      throwingAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6, 1.0f, 30f);

      base.Load(Content);
    }

    protected override void Input(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.A))
      {
        velocity.X = -4f;

        currentAnimation = walkAnimation;
        direction = -1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.D))
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

      if (Keyboard.GetState().IsKeyDown(Keys.W) && HasJumped == false)
      {
        position.Y -= 1f;
        velocity.Y = -11f;
        HasJumped = true;
        jumpSound.SOUND_INSTANCE.Play();
        currentAnimation = jumpAnimation;
      }

      if (currentKeyboardState.IsKeyDown(Keys.Q) && previousKeyboardState.IsKeyUp(Keys.Q) &&
          HasJumped == true && HasDoubleJumped == false && CurrentDoubleJump > 0)
      {
        position.Y -= 1f;
        velocity.Y = -9f;
        HasDoubleJumped = true;
        jumpSound.SOUND_INSTANCE.Play();
        CurrentDoubleJump--;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.S))
      {
        throwing = true;
        currentAnimation = throwingAnimation;
      }
    }
  }
}
