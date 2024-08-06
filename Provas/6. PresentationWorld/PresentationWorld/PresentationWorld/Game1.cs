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

namespace PresentationWorld
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
        Ship ship;
        WindmillModel[] windmillModels;

        List<GameObject> colliders;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "PRESENTATION WORLD";
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            camera = new Camera(this);

            ship = new Ship(this, GraphicsDevice);
            plane = new Quad(this, GraphicsDevice);
            house = new Cube(this, GraphicsDevice);
            windmillModels = new WindmillModel[]
            {
                new WindmillModel(this, GraphicsDevice, random.Next(1,10)),
                new WindmillModel(this, GraphicsDevice, random.Next(1,10)),
            };

            ship.Scale = new Vector3(5, 5, 5);
            ship.Position = new Vector3(-20, 3, 20);
            ship.Rotation = new Vector3(MathHelper.ToRadians(-90), 0, 0);
            

            plane.Scale = new Vector3(70, 1, 70);
            house.Position = new Vector3(0, 1, 0);

            windmillModels[0].Position = new Vector3(-8, 2, 0);
            windmillModels[1].Position = new Vector3( 8, 2, 0);

            windmillModels[0].Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);
            windmillModels[1].Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);

            colliders = new List<GameObject>() { plane, house, ship, windmillModels[0], windmillModels[1] };

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

            foreach (WindmillModel windmillModel in windmillModels)
                windmillModel.Update(gameTime);

            foreach (GameObject obj in colliders)
            {
                if (camera.IsColliding(obj.BBox) || camera.IsColliding(obj.BSphere))
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
            ship.Draw(camera, true);
            plane.Draw(camera, true);
            house.Draw(camera, true);
            foreach (WindmillModel windmillModel in windmillModels)
                windmillModel.Draw(camera, true);

            base.Draw(gameTime);
        }
    }
}
