using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Collison_Tiles
{
  internal class KnightRed : Knight
  {
    public KnightRed() {}

    public override void Load(ContentManager Content)
    {
      // Old knight texture (not animated)
      // base.knightTexture = Content.Load<Texture2D>("Sprites/Knight_Red");

      Texture2D texture;

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Walk");
      WalkAnimation = new NewAnimations(texture, texture.Width, texture.Height, 8);

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Idle");
      IdleAnimation = new NewAnimations(texture, texture.Width, texture.Height, 4);

      texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Jump");
      JumpAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      // todo for adding other textures
      // texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Attack 1");
      // AttackAnimation = new NewAnimations(texture, texture.Width, texture.Height, 5);

      // texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Hurt");
      // HurtAnimation = new NewAnimations(texture, texture.Width, texture.Height, 2);

      // texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Protect");
      // ProtectAnimation = new NewAnimations(texture, texture.Width, texture.Height, 1);

      // texture = Content.Load<Texture2D>("SpriteSheets/Knight/Red/Dead");
      // DeadAnimation = new NewAnimations(texture, texture.Width, texture.Height, 6);

      base.Load(Content);
    }

    protected override void Input(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Left))
      {
        velocity.X = -3.5f;
        
        currentAnimation = WalkAnimation;
        direction = -1;
      }
      else if (Keyboard.GetState().IsKeyDown(Keys.Right))
      {
        velocity.X = +3.5f;

        currentAnimation = WalkAnimation;
        direction = 1;
      }
      else
      {
        currentAnimation = IdleAnimation;
        velocity.X = 0f;
      }

      if (Keyboard.GetState().IsKeyDown(Keys.Up) && HasJumped == false)
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
