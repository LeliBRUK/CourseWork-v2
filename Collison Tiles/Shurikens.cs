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
    internal class Shurikens
    {
        public Animation Shuriken;
        float ShurikenSpeed = 0.5f;
        public Vector2 Position;
        int Damage = 1;
        public bool Active;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public int Width
        {
            get { return Shuriken.FrameWidth; }
        }
        public int Height
        {
            get { return Shuriken.FrameHeight; }
        }

        public void Initialise(Animation animation,Vector2 position)
        {
            Shuriken = animation;
            Position = position;
            Active = true;
        }

        public void Update(GameTime gameTime)
        {

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

                int i = 10;
                Position.X += ShurikenSpeed*i;
                Shuriken.Position = Position;
                Shuriken.Update(gameTime);
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Shuriken.Draw(spriteBatch);
        }

    }
}
