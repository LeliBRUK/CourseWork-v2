using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collison_Tiles
{
    internal class Falling_Spikes
    {

        public Animation FallingSpike;
        float SpikeFallingSpeed = 0.25f;
        public Vector2 Position;
        int Damage = 1;
        public bool Active;

        public int Width
        {
            get { return FallingSpike.FrameWidth; }

        }

        public int Height
        {
            get { return FallingSpike.FrameHeight; }
        }

        public void Initalise(Animation animation, Vector2 position)
        {
            FallingSpike = animation;
            Position = position;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {
            int i = 10;
            Position.Y += SpikeFallingSpeed * i;
            FallingSpike.Position = Position;
            FallingSpike.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            FallingSpike.Draw(spriteBatch);
        }
    }
}
