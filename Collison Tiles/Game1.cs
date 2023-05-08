    using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Collison_Tiles
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        //Controls
        //If Character is Blue then controls are wasd if Character id Red then controls are arrowkeys
        //W=jump,A=Left,D=Right,S=Spikeor SHuriken,Q=After jumping DoubleJumping for Thief
        //Up=Jump,Left=Left,Right=Right,Dowwn=Shuriken or Spikes,Right SHift=Jumping

        //TODO Make a so that shuriken is thrown in the direcction facing
        //Will Send the Tutorial Levels As Seperate cause I do not know how to add level progression
        //Mellee Attacks
        //The Dueling Room should be Done by doing Interactive elements and AI as it consist of Moving Walls and treasure




        KnightBlue Player1_B;
        ThiefRed Player2_R;

        KnightRed Player1_R;
        Thief Player2_B;

        Texture2D SpikeTexture;
        SpikeManager Spike_B;
        SpikeManager Spike_R;

        Texture2D ShurikenTexture;
        ShurikenManager Shuriken_R;
        ShurikenManager Shuriken_B;
        GraphicsDevice details;

        int mapswitcher; //switches map generated
        Random random = new Random();

        int characterswitcher;


        Map1 map;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            map = new Map1();
            Player1_B = new KnightBlue();
            Player2_R = new ThiefRed();

            Player1_R = new KnightRed();
            Player2_B = new ThiefBlue();

            Spike_R = new SpikeManager();
            Spike_B = new SpikeManager();

            Shuriken_R = new ShurikenManager();
            Shuriken_B= new ShurikenManager();

            mapswitcher = random.Next(0, 2);
            characterswitcher = random.Next(0, 2);

            //graphics.PreferredBackBufferWidth = 800;
            //graphics.PreferredBackBufferHeight = 950;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;
            // TODO: use this.Content to load your game content here

            if(mapswitcher == 0)
            {
                map.Generate(new int[,]{
              {4,4,4,4,4,4,4,4,4,4,2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,1,5,5,5,4,0,0,0,0,0,0,0,0,0,0,0,5,1,5,5,1,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,5,5,5,0,0,0,0,0,0,0,0,5,0,7,7,7,1,1,1,1,0,0,5,5,0,0,1,5,5,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,5,1,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,7,7,7,0,0,0,1,5,1,0,0,5,0,0,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,5,1,1,0,0,6,6,6,6,6,6,6,6,6,6,6,0,0,1,1,1,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,1,1,0,0,5,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,0,0,0,0,1,1,1,1,1,4,0,0,0,5,0,0,1,1,0,0,1,1,0,0,0,0,5,5,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
               }, 48);
            }
            if (mapswitcher == 1)
            {
                map.Generate(new int[,]{
              {4,4,4,4,4,4,4,4,4,4,2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,0,0,0,0,0,0,0,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,7,7,0,1,7,7,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,4,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,7,7,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,7,7,0,0,7,7,0,0,0,0,0,0,0,0,0,1,5,1,5,1,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,7,7,0,0,7,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,7,7,0,0,7,7,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,1,0,0,0,7,7,0,0,7,7,1,0,0,5,1,5,0,0,0,0,0,0,0,0,5,5,5,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,6,6,6,6,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,7,7,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,5,1,0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,1,1,0,0,1,5,5,1,0,0,0,5,5,0,0,1,1,5,0,0,0,1,1,1,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,5,5,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,5,1,5,5,0,0,0,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,4,4,4,4,4,4,4,4,4,4},
              {4,4,4,4,4,4,4,4,4,4,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,4,4,4,4,4,4,4,4,4,4},
               }, 48);
            }

            //Where 5 is we need to make a timed Platform
            //Where 6 is we need Horizontal moving Platform
            //Where 7 is we need Vertical moving Platform

            //48 is Gold


            SpikeTexture = Content.Load<Texture2D>("Weapons/Spikes");
            ShurikenTexture = Content.Load<Texture2D>("Weapons/Shuriken");

            //After Each level Update switcher to change the controls of the character here

            if (characterswitcher == 0)
            {
                Player1_B.Load(Content);
                Player2_R.Load(Content);
                Spike_B.Initialize(SpikeTexture);
                Shuriken_R.Initialize(ShurikenTexture);

            }
            else if (characterswitcher == 1)
            {
                Player1_R.Load(Content);
                Player2_B.Load(Content);
                Spike_R.Initialize(SpikeTexture);
                Shuriken_B.Initialize(ShurikenTexture);
            }

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(characterswitcher == 0)
            {
                Player1_B.Update(gameTime);
                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    Player1_B.Collision(tile.Rectangle, map.Width, map.Height);
                }

                Player2_R.Update(gameTime);
                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    Player2_R.Collision(tile.Rectangle, map.Width, map.Height);
                }

                Spike_B.UpdateSpikeManager(gameTime, Player1_B);
                base.Update(gameTime);

                Shuriken_R.UpdateShurikenManager(gameTime, Player2_R);
                base.Update(gameTime);
            }
            // TODO: Add your update logic here
            
            else if(characterswitcher == 1) 
            {
                Player1_R.Update(gameTime);
                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    Player1_R.Collision(tile.Rectangle, map.Width, map.Height);
                }

                Player2_B.Update(gameTime);
                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    Player2_B.Collision(tile.Rectangle, map.Width, map.Height);
                }

                Spike_R.UpdateSpikeManager2(gameTime, Player1_R);
                base.Update(gameTime);

                Shuriken_B.UpdateShurikenManager2(gameTime, Player2_B);
                base.Update(gameTime);

                base.Update(gameTime);

            }
     
        }

        protected override void Draw(GameTime gameTime)
        {
            if (mapswitcher == 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            if (mapswitcher == 1)
            {
                GraphicsDevice.Clear(Color.DarkGray);
            }

            spriteBatch.Begin();

            map.Draw(spriteBatch);

            if (characterswitcher == 0)
            {
                Player1_B.Draw(spriteBatch);
                Player2_R.Draw(spriteBatch);
            }
           else if (characterswitcher == 1)
            {
                Player1_R.Draw(spriteBatch);
                Player2_B.Draw(spriteBatch);
            }
            
            Spike_B.DrawSpikes(spriteBatch);
            Shuriken_R.DrawShuriken(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here
            // Player1_B.Draw(spriteBatch)

            base.Draw(gameTime);
        }
    }
}
