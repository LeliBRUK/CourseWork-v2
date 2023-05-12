using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace CourseWorkV2
{
  internal class KnightBlue : Knight
  {
    public KnightBlue() { }

    public override void Load(ContentManager Content)
    {
      Texture2D texture;

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Blue/Walk");
      WalkAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Blue/Idle");
      IdleAnimation = new NewAnimations(texture, texture.Width, texture.Height, 4);

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Blue/Jump");
      JumpAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Blue/death");
      DeathAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      base.Load(Content);
    }

    protected override void Input(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.A))
      {
        velocity.X = -3.5f;

        currentAnimation = WalkAnimation;
        direction = -1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.D))
      {
        velocity.X = +3.5f;

        currentAnimation = WalkAnimation;
        direction = 1;
      }
      else
      {
        if (!HasJumped)
          currentAnimation = IdleAnimation;
        velocity.X = 0f;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.W) && HasJumped == false)
      {
        position.Y -= 1f;
        velocity.Y = -11f;   //9==2 11==3 tiles worth of jump
        HasJumped = true;
        currentAnimation = JumpAnimation;
        jumpSound.SOUND_INSTANCE.Play();
      }
    }
  }
}
