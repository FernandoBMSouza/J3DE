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
        Random random;

        Screen screen;
        Camera camera;

        Quad plane;
        Windmill windmill;

        List<ICollider> colliders;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 02";
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
            windmill = new Windmill(this, GraphicsDevice);

            plane.Scale = new Vector3(20, 0, 20);
            windmill.Position = new Vector3(0, 2, 0);
            windmill.Scale = new Vector3(1, 1, 1);
            colliders = new List<ICollider>() { plane, windmill };

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

            foreach (ICollider obj in colliders)
            {
                if (camera.IsColliding(obj.BBox))
                {
                    camera.RestorePosition();
                    obj.SetColliderColor(Color.Red);
                }
                else obj.SetColliderColor(Color.Green);
            }

            Window.Title = "BoundingBox Tests: " + windmill.BBox.Contains(camera.BBox);

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
            windmill.Draw(camera);
            base.Draw(gameTime);
        }
    }
}
