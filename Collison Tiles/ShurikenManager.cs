using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collison_Tiles
{
    internal class ShurikenManager
    {

        static Texture2D ShurikenTexture;
        static Rectangle ShurikenRectangle;
        static public List<Shurikens> Shuriken;
        const float SecondsInMin = 60f;

        const float RateOfFire = 500f;

        static TimeSpan ShurikenSpawnTime = TimeSpan.FromSeconds(SecondsInMin / RateOfFire);
        static TimeSpan previousShurikenSpawn;

        static TimeSpan ShurikenRecharge = TimeSpan.FromSeconds(5);
        private TimeSpan elapsedTime;

        int c_ammo = 3;
        int max_ammo = 3;

        GraphicsDeviceManager graphics;

        static Vector2 graphicsinfo;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public void Initialize(Texture2D texture)
        {
            Shuriken = new List<Shurikens>();
            previousShurikenSpawn = TimeSpan.Zero;
            ShurikenTexture = texture;
        }

        private static void ActivateShuriken(GameTime gameTime, ThiefRed p)
        {
            if (gameTime.TotalGameTime - previousShurikenSpawn > ShurikenSpawnTime)
            {
                previousShurikenSpawn = gameTime.TotalGameTime;
                AddShuriken(p);
            }
        }
        private static void ActivateShuriken2(GameTime gameTime, Thief p)
        {
            if (gameTime.TotalGameTime - previousShurikenSpawn > ShurikenSpawnTime)
            {
                previousShurikenSpawn = gameTime.TotalGameTime;
                AddShuriken2(p);
            }
        }

        private static void AddShuriken(ThiefRed p)
        {
            Animation ShurikenAnimation = new Animation();

            ShurikenAnimation.Initialize(ShurikenTexture, p.Position,
                63,
                16,
                1,
                30,
                Color.White,
                1f,
                true);

            {
                Shurikens shuriken = new Shurikens();
                var ShurikenPosition = p.Position;
                ShurikenPosition.Y += 67;
                ShurikenPosition.X -= 11;

                shuriken.Initialise(ShurikenAnimation, ShurikenPosition);
                Shuriken.Add(shuriken);
            }
        }
        private static void AddShuriken2(Thief p)
        {
            Animation ShurikenAnimation = new Animation();

            ShurikenAnimation.Initialize(ShurikenTexture, p.Position,
                63,
                16,
                1,
                30,
                Color.White,
                1f,
                true);

            {
                Shurikens shuriken = new Shurikens();
                var ShurikenPosition = p.Position;
                ShurikenPosition.Y += 67;
                ShurikenPosition.X -= 11;

                shuriken.Initialise(ShurikenAnimation, ShurikenPosition);
                Shuriken.Add(shuriken);
            }
        }

        public void UpdateShurikenManager(GameTime gameTime,ThiefRed p)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime >= ShurikenRecharge)
            {
                elapsedTime -= ShurikenRecharge;
                if (c_ammo < max_ammo)
                {
                    c_ammo++;
                }
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Down) && c_ammo > 0)
            {
                ActivateShuriken(gameTime, p);
                c_ammo--;
            }
            for (var i = 0; i < Shuriken.Count; i++)
            {
                Shuriken[i].Update(gameTime);

                if (!Shuriken[i].Active || Shuriken[i].Position.X > 2550)
                {
                    Shuriken.Remove(Shuriken[i]);
                }
            }
        }
        public void UpdateShurikenManager2(GameTime gameTime, Thief p)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime >= ShurikenRecharge)
            {
                elapsedTime -= ShurikenRecharge;
                if (c_ammo < max_ammo)
                {
                    c_ammo++;
                }
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.S) && c_ammo > 0)
            {
                ActivateShuriken2(gameTime, p);
                c_ammo--;
            }
            for (var i = 0; i < Shuriken.Count; i++)
            {
                Shuriken[i].Update(gameTime);

                if (!Shuriken[i].Active || Shuriken[i].Position.X > 2550)
                {
                    Shuriken.Remove(Shuriken[i]);
                }
            }
        }
        public void DrawShuriken(SpriteBatch spriteBatch)
        {
            foreach (var S in Shuriken)
            {
                S.Draw(spriteBatch);
            }
        }
    }
}
