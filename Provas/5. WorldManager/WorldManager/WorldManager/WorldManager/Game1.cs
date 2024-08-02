using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WorldManager.Worlds;

namespace WorldManager
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        enum Worlds
        {
            House,
            Windmill,
            Model,
        };
        Worlds currentWorld;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;
        BaseWorld world;
        public Dictionary<string, Texture2D> Textures { get; private set; }
        public Dictionary<string, Model> Models { get; private set; }

        const float DELAY = .5f;
        float timeSinceLastChange = 3f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "WORLD MANAGER";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;
            camera = new Camera(this);

            currentWorld = Worlds.House;

            Textures = new Dictionary<string, Texture2D>();
            Textures["rocks"] = Content.Load<Texture2D>(@"Images\rocks");
            Textures["wood"] = Content.Load<Texture2D>(@"Images\wood");
            Textures["grass"] = Content.Load<Texture2D>(@"Images\grass");
            Textures["bricks"] = Content.Load<Texture2D>(@"Images\bricks");

            Models = new Dictionary<string, Model>();
            Models["tower"] = Content.Load<Model>(@"Models\tower");
            Models["hero"] = Content.Load<Model>(@"Models\hero");
            Models["building"] = Content.Load<Model>(@"Models\building");
            Models["blade"] = Content.Load<Model>(@"Models\blade");

            world = new HouseWorld(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSinceLastChange += deltaTime;

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && timeSinceLastChange >= DELAY)
            {
                currentWorld = (Worlds)(((int)currentWorld + 1) % Enum.GetValues(typeof(Worlds)).Length);
                SwitchWorld();
                timeSinceLastChange = 0f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && timeSinceLastChange >= DELAY)
            {
                currentWorld = (Worlds)((((int)currentWorld - 1) + Enum.GetValues(typeof(Worlds)).Length) % Enum.GetValues(typeof(Worlds)).Length);
                SwitchWorld();
                timeSinceLastChange = 0f;
            } 

            camera.Update(gameTime);
            world.Update(gameTime, camera);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            world.Draw(camera);
            base.Draw(gameTime);
        }

        private void SwitchWorld()
        {
            switch (currentWorld)
            {
                case Worlds.House:
                    world = new HouseWorld(this);
                    break;
                case Worlds.Windmill:
                    world = new WindmillWorld(this);
                    break;
                case Worlds.Model:
                    world = new ModelWorld(this);
                    break;
            }
        }
    }
}
