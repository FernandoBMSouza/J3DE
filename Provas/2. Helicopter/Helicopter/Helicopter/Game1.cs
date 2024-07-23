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

        Camera[] cameras;

        Quad plane;
        Cube[] cubes;

        Helicopter helicopter;

        List<GameObject> colliders;

        private Viewport topViewport;
        private Viewport frontViewport;
        private Viewport leftViewport;
        private Viewport rightViewport;

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

            //camera = new Camera(this);
            cameras = new Camera[4]
            {
                new Camera(),
                new Camera(),
                new Camera(),
                new Camera(),
            };

            cameras[0].SetupView(new Vector3(0, 20, 28), new Vector3(0, 0, 0), Vector3.Up); //TOP VIEW
            cameras[1].SetupView(new Vector3(0, 5, 30), new Vector3(0, 0, 0), Vector3.Up);  //FRONT VIEW
            cameras[2].SetupView(new Vector3(-25, 7, 25), new Vector3(0, 0, 0), Vector3.Up);//LEFT VIEW
            cameras[3].SetupView(new Vector3(25, 7, 25), new Vector3(0, 0, 0), Vector3.Up); //RIGHT VIEW

            topViewport = new Viewport();
            topViewport.X = 0;
            topViewport.Y = 0;
            topViewport.Width = screen.Width / 2;
            topViewport.Height = screen.Height / 2;
            topViewport.MinDepth = 0;
            topViewport.MaxDepth = 1;

            frontViewport = new Viewport();
            frontViewport.X = 0;
            frontViewport.Y = screen.Height / 2;
            frontViewport.Width = screen.Width / 2;
            frontViewport.Height = screen.Height / 2;
            frontViewport.MinDepth = 0;
            frontViewport.MaxDepth = 1;

            leftViewport = new Viewport();
            leftViewport.X = screen.Width / 2;
            leftViewport.Y = 0;
            leftViewport.Width = screen.Width / 2;
            leftViewport.Height = screen.Height / 2;
            leftViewport.MinDepth = 0;
            leftViewport.MaxDepth = 1;

            rightViewport = new Viewport();
            rightViewport.X = screen.Width / 2;
            rightViewport.Y = screen.Height / 2;
            rightViewport.Width = screen.Width / 2;
            rightViewport.Height = screen.Height / 2;
            rightViewport.MinDepth = 0;
            rightViewport.MaxDepth = 1;            
            
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

            //camera.Update(gameTime);
            helicopter.Update(gameTime);

            //foreach (GameObject obj in colliders)
            //{
            //    if (camera.IsColliding(obj.BBox))
            //    {
            //        camera.RestorePosition();
            //        obj.SetColliderColor(Color.Red);
            //    }
            //    else obj.SetColliderColor(Color.Green);
            //}

            base.Update(gameTime);
        }

        private Texture2D CreatePixelTexture(GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            return texture;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            // GraphicsDevice.RasterizerState = rs;

            Viewport original = graphics.GraphicsDevice.Viewport;

            graphics.GraphicsDevice.Viewport = topViewport;
            plane.Draw(cameras[0]);
            helicopter.Draw(cameras[0]);
            foreach (Cube cube in cubes)
                cube.Draw(cameras[0]);

            graphics.GraphicsDevice.Viewport = leftViewport;
            plane.Draw(cameras[1]);
            helicopter.Draw(cameras[1]);
            foreach (Cube cube in cubes)
                cube.Draw(cameras[1]);

            graphics.GraphicsDevice.Viewport = frontViewport;
            plane.Draw(cameras[2]);
            helicopter.Draw(cameras[2]);
            foreach (Cube cube in cubes)
                cube.Draw(cameras[2]);

            graphics.GraphicsDevice.Viewport = rightViewport;
            plane.Draw(cameras[3]);
            helicopter.Draw(cameras[3]);
            foreach (Cube cube in cubes)
                cube.Draw(cameras[3]);

            GraphicsDevice.Viewport = original;

            base.Draw(gameTime);
        }
    }
}
