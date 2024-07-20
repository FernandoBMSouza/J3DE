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

namespace Helicopter
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random;

        Screen screen;
        Camera camera;

        Quad plane;
        Cube[] cubes;

        Helicopter helicopter;

        List<GameObject> colliders;

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
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            camera = new Camera(this);

            plane = new Quad(this, GraphicsDevice);
            cubes = new Cube[]
            {
                new Cube(this, GraphicsDevice),
                new Cube(this, GraphicsDevice),
            };

            plane.Scale = new Vector3(20, 1, 20);
            cubes[0].Position = new Vector3(-10, 1, 0);
            cubes[1].Position = new Vector3(10, 2, 0);
            cubes[0].Scale = new Vector3(3, 1, 3);
            cubes[1].Scale = new Vector3(3, 2, 3);

            helicopter = new Helicopter(this, GraphicsDevice, cubes[0], cubes[1]);
            helicopter.Position = cubes[0].Position + new Vector3(0, helicopter.Size.Y, 0);
            colliders = new List<GameObject>() { plane, helicopter, cubes[0], cubes[1] };

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

            foreach (GameObject obj in colliders)
            {
                if (camera.IsColliding(obj.BBox))
                {
                    camera.RestorePosition();
                    obj.SetColliderColor(Color.Red);
                }
                else obj.SetColliderColor(Color.Green);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            // GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);
            helicopter.Draw(camera);
            foreach (Cube cube in cubes)
                cube.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
