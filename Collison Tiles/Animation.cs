using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collison_Tiles
{
    internal class Animation
    {
        Texture2D spritestrip;
        float scale;
        int elapsedTime;
        int frametime;
        int frameCount;
        int CurrentFrame;
        Color color;
        Rectangle sourcerect = new Rectangle();
        private Rectangle destinationrect;
        public int FrameWidth;
        public int FrameHeight;
        public bool Active;
        public bool Looping;
        public Vector2 Position;

        private List<Rectangle> frames = new List<Rectangle>();



        public void Initialize(Texture2D texture, Vector2 position, int frameWidth,
            int frameHeight, int frameCount, int frametime, Color color, float scale, bool looping)
        {
            this.color = color;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frametime = frametime;
            this.scale = scale;

            Looping = looping;
            Position = position;
            spritestrip = texture;

            elapsedTime = 0;
            CurrentFrame = 0;

            Active = true;

            sourcerect = new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight);

            destinationrect = new Rectangle(
                (int)Position.X - (int)(FrameWidth * scale) / 2,
                (int)Position.Y - (int)(FrameHeight * scale) / 2,
                (int)(FrameWidth * scale),
                (int)(FrameHeight * scale));


            for (int x = 0; x < frameCount; x++)
            {
                frames.Add(new Rectangle(
                (FrameWidth * x),
                0,
                FrameWidth, FrameHeight));
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Active == false) return;

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedTime > frametime)
            {

                CurrentFrame++;
                if (CurrentFrame == frameCount)
                {
                    CurrentFrame = 0;
                    if (Looping == false)
                    {
                        Active = false;
                    }
                }
                elapsedTime = 0;

            }

            sourcerect = frames[CurrentFrame];
            destinationrect = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                FrameWidth,
                FrameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(spritestrip, destinationrect, sourcerect, color);
            }
        }
    }
}
