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
        Cube[] buildings;

        Helicopter helicopter;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "Helicopter World";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera();

            plane = new Quad(GraphicsDevice);

            buildings = new Cube[2];
            for (int i = 0; i < buildings.Length; i++) 
                buildings[i] = new Cube(GraphicsDevice);

            helicopter = new Helicopter(GraphicsDevice, buildings[0], buildings[1]);

            plane.Scale = new Vector3(20, 1, 20);
            buildings[0].Position = new Vector3(-10, 1, 0);
            buildings[1].Position = new Vector3( 10, 2, 0);

            buildings[1].Scale = new Vector3(1, 2, 1);
            helicopter.Position = new Vector3(buildings[0].Position.X,
                                              buildings[0].Position.Y + helicopter.Size.Y,
                                              buildings[0].Position.Z);

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

            camera.Update(gameTime);
            helicopter.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RasterizerState rs = new RasterizerState();
            // rs.CullMode = CullMode.None;
            // rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);

            foreach (Cube building in buildings)
                building.Draw(camera);

            helicopter.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
