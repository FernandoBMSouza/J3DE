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

namespace Mundo02
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;

        Quad plane;
        Cube house;
        List<GameObject> colliders;

        Shovel shovel;
        Building building;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 01";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera(this);

            plane = new Quad(this, GraphicsDevice);
            house = new Cube(this, GraphicsDevice);

            shovel = new Shovel(this, GraphicsDevice);
            building = new Building(this, GraphicsDevice);

            plane.Scale = new Vector3(20, 0, 20);
            house.Position = new Vector3(0, 1, 0);
            house.Scale = new Vector3(2, 2, 2);

            shovel.Position = new Vector3(10, 10, 0);
            building.Position = new Vector3(-10, 10, 0);

            colliders = new List<GameObject>() { plane, house, shovel, building };

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

            foreach (GameObject obj in colliders)
            {
                if (camera.IsColliding(obj.BBox))
                {
                    camera.RestorePosition();
                    obj.LBox.SetColor(Color.Red);
                }
                else obj.LBox.SetColor(Color.Green);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);
            house.Draw(camera);

            shovel.Draw(camera);
            building.Draw(camera);

            base.Draw(gameTime);
        }
    }
}