using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collison_Tiles
{
  public class NewAnimations
  {
    private int currentFrame;

    public readonly Texture2D texture;
    private Rectangle srcRect;

    public int frameWidth;
    public int frameHeight;
    private int frameCount;
    private float frameTime;

    private float elapsed;
    private List<Rectangle> frames = new List<Rectangle>();

    public NewAnimations(Texture2D texture, int width, int height, int frameCount, float scale = 1.0f, float frameTime = 100f)
    {
      this.texture = texture;

      frameWidth = (int)(width / frameCount);
      frameHeight = height;
      this.frameCount = frameCount;
      this.frameTime = frameTime;

      srcRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

      for (int i = 0; i < frameCount; i++)
        frames.Add(new Rectangle(i * frameWidth, 0, frameWidth, frameHeight));
    }

    public void Update(GameTime gameTime)
    {
      elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

      if (elapsed >= frameTime)
      {
        currentFrame++;
        if (currentFrame >= frameCount)
          currentFrame = 0;

        elapsed = 0;
      }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, int direction)
    {
      srcRect = frames[currentFrame];

      if (direction == 1)
        spriteBatch.Draw(texture, position, srcRect, Color.White);
      else
        spriteBatch.Draw(texture, position, srcRect, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);
    }
  }
}
