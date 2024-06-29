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

namespace HelicopterWorld
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;

        Quad plane;
        Cube[] cubes;
        Helicopter helicopter;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO HELICOPTERO";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera();

            plane = new Quad(GraphicsDevice);

            cubes = new Cube[2];
            for (int i = 0; i < cubes.Length; i++) cubes[i] = new Cube(GraphicsDevice);

            helicopter = new Helicopter(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            camera.Update(gameTime);

            plane.SetIdentity();
            plane.Scale(new Vector3(10, 0, 10));

            foreach (Cube c in cubes) c.SetIdentity();
            cubes[1].Scale(new Vector3(1, 2, 1));
            cubes[0].Translation(new Vector3(-7, 1, 0));
            cubes[1].Translation(new Vector3( 7, 2, 0));

            helicopter.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            //GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);
            foreach (Cube c in cubes) c.Draw(camera);
            helicopter.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
