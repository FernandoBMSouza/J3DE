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

namespace Mundo03
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Random random;

        Screen screen;
        Camera camera;

        Quad plane;
        Cube house;
        Windmill[] windmills;

        List<GameObject> colliders;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 03";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            camera = new Camera(this);

            plane = new Quad(this);
            house = new Cube(this);
            windmills = new Windmill[]
            {
                new Windmill(this, random.Next(1,10)),
                new Windmill(this, random.Next(1,10)),
            };

            plane.Scale = new Vector3(20, 1, 20);
            house.Position = new Vector3(0, 1, 0);

            windmills[0].Position = new Vector3(-8, 2,0);
            windmills[1].Position = new Vector3( 8, 2,0);

            windmills[0].Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);
            windmills[1].Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);

            colliders = new List<GameObject>() { plane, house, windmills[0], windmills[1] };

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

            foreach(Windmill windmill in windmills) 
                windmill.Update(gameTime);

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
            house.Draw(camera);
            foreach (Windmill windmill in windmills)
                windmill.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
