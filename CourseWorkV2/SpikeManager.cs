using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CourseWorkV2
{
    internal class SpikeManager
    {
        static Texture2D SpikeTexture;
        static Rectangle SpikeRectangle;
        static public List<Falling_Spikes> Spikes;
        const float SecondsInMin = 60f;

        const float RateOfFire = 500f;

        static TimeSpan SpikeSpawnTime = TimeSpan.FromSeconds(SecondsInMin / RateOfFire);
        static TimeSpan previousSpikeSpawn;

        static TimeSpan SpikeRecharge = TimeSpan.FromSeconds(5);
        private TimeSpan elapsedTime;

        int c_ammo = 3;
        int max_ammo = 3;

        GraphicsDeviceManager graphics;

        static Vector2 graphicsinfo;

        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public void Initialize(Texture2D texture)
        {
            Spikes = new List<Falling_Spikes>();
            previousSpikeSpawn = TimeSpan.Zero;
            SpikeTexture = texture;
        }

        private static void ActivateFallingSpike(GameTime gameTime, KnightBlue p)
        {
            if (gameTime.TotalGameTime - previousSpikeSpawn > SpikeSpawnTime)
            {
                previousSpikeSpawn = gameTime.TotalGameTime;
                AddSpike(p);
            }
        }
        private static void ActivateFallingSpike2(GameTime gameTime, KnightRed k)
        {
            if (gameTime.TotalGameTime - previousSpikeSpawn > SpikeSpawnTime)
            {
                previousSpikeSpawn = gameTime.TotalGameTime;
                AddSpike2(k);
            }
        }

        private static void AddSpike(KnightBlue p)
        {
            Animation SpikesAnimation = new Animation();

            SpikesAnimation.Initialize(SpikeTexture, p.Position,
                SpikeTexture.Width,
                SpikeTexture.Height,
                1,
                30,
                Color.White,
                1f,
                true);

            {
                Falling_Spikes spikes = new Falling_Spikes();
                var SpikePosition = p.Position;
                SpikePosition.Y += 67;
                SpikePosition.X -= 11;

                spikes.Initalise(SpikesAnimation, SpikePosition);
                Spikes.Add(spikes);
            }
        }

        private static void AddSpike2(KnightRed p)
        {
            Animation SpikesAnimation = new Animation();

            SpikesAnimation.Initialize(SpikeTexture, p.Position,
                SpikeTexture.Width,
                SpikeTexture.Height,
                1,
                30,
                Color.White,
                1f,
                true);

            {
                Falling_Spikes spikes = new Falling_Spikes();
                var SpikePosition = p.Position;
                SpikePosition.Y += 67;
                SpikePosition.X -= 11;

                spikes.Initalise(SpikesAnimation, SpikePosition);
                Spikes.Add(spikes);
            }
        }

        public void UpdateSpikeManager(GameTime gameTime, KnightBlue p,ThiefRed k)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime >= SpikeRecharge)
            {
                elapsedTime -= SpikeRecharge;
                if (c_ammo < max_ammo)
                {
                    c_ammo++;
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.S) && c_ammo > 0)
            {
                Knight.spikeSound.SOUND_INSTANCE.Play();
                ActivateFallingSpike(gameTime, p);
                c_ammo--;
            }

            for (var i = 0; i < Spikes.Count; i++)
            {
                Spikes[i].Update(gameTime);

                if (!Spikes[i].Active || Spikes[i].Position.Y > 5000)
                {
                    Spikes.Remove(Spikes[i]);
                }
            }

            foreach (Falling_Spikes S in SpikeManager.Spikes)
            {
                SpikeRectangle = new Rectangle(
                    (int)S.Position.X,
                    (int)S.Position.Y,
                    S.Width, S.Height);

                Rectangle EnemyRectangle = new Rectangle(
                    (int)k.Position.X,
                    (int)k.Position.Y,
                    45, 90);

                if (SpikeRectangle.Intersects(EnemyRectangle))
                {
                    if (k.Overshield > 0)
                    {
                        k.Overshield--;
                        Thief.hurtSound.SOUND_INSTANCE.Play();
                    }
                    else if (k.Overshield == 0 && k.Health > 0)
                    {
                        k.Health--;
                        if (k.Health > 0)
                          Thief.hurtSound.SOUND_INSTANCE.Play();
                        else
                          Thief.deathSound.SOUND_INSTANCE.Play();
                    }
                    S.Active = false;
                }
            }
        }
        public void UpdateSpikeManager2(GameTime gameTime, KnightRed p,ThiefBlue k)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime >= SpikeRecharge)
            {
                elapsedTime -= SpikeRecharge;
                if (c_ammo < max_ammo)
                {
                    c_ammo++;
                }
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Down) && c_ammo > 0)
            {
                Knight.spikeSound.SOUND_INSTANCE.Play();
                ActivateFallingSpike2(gameTime, p);
                c_ammo--;
            }

            for (var i = 0; i < Spikes.Count; i++)
            {
                Spikes[i].Update(gameTime);

                if (!Spikes[i].Active || Spikes[i].Position.Y > 5000)
                {
                    Spikes.Remove(Spikes[i]);
                }
            }

            foreach(Falling_Spikes S in SpikeManager.Spikes)
            {
                SpikeRectangle = new Rectangle(
                    (int)S.Position.X,
                    (int)S.Position.Y,
                    S.Width,S.Height);

                Rectangle EnemyRectangle = new Rectangle(
                    (int)k.Position.X,
                    (int)k.Position.Y,
                    45, 90);

                if (SpikeRectangle.Intersects(EnemyRectangle))
                {
                    if (k.Overshield > 0)
                    {
                        k.Overshield--;
                        if (k.Health > 1)
                          Thief.hurtSound.SOUND_INSTANCE.Play();
                    }
                    else if(k.Overshield == 0 && k.Health > 0)
                    {
                        k.Health--;
                        if (k.Health > 0)
                          Thief.hurtSound.SOUND_INSTANCE.Play();
                        else
                          Thief.deathSound.SOUND_INSTANCE.Play();
                    }
                    S.Active = false;
                }
            }
        }

        public void DrawSpikes(SpriteBatch spriteBatch)
        {
            foreach (var S in Spikes)
            {
                S.Draw(spriteBatch);
            }
        }
    }
}
