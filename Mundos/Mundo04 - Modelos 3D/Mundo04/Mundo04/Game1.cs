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

namespace Mundo04
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

        Hero hero;
        Tower tower;
        WindmillModel[] windmillModels;

        List<GameObject> colliders;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 04";
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
            house = new Cube(this, GraphicsDevice);
            windmills = new Windmill[]
            {
                new Windmill(this, GraphicsDevice, random.Next(1,10)),
                new Windmill(this, GraphicsDevice, random.Next(1,10)),
            };

            hero = new Hero(this, GraphicsDevice);
            tower = new Tower(this, GraphicsDevice);
            windmillModels = new WindmillModel[]
            {
                new WindmillModel(this, GraphicsDevice, random.Next(1,10)),
                new WindmillModel(this, GraphicsDevice, random.Next(1,10)),
            };

            plane.Scale = new Vector3(20, 1, 20);
            house.Position = new Vector3(0, 1, 0);

            windmills[0].Position = new Vector3(-8, 2, -8);
            windmills[1].Position = new Vector3( 8, 2, -8);

            windmills[0].Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);
            windmills[1].Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);

            hero.Scale = new Vector3(.2f);
            hero.Position = new Vector3(0, 1.5f, 6);

            tower.Scale = new Vector3(1, 4, 1);
            tower.Position = new Vector3(0, 4, -8);

            windmillModels[0].Position = new Vector3(-8, 2, 8);
            windmillModels[1].Position = new Vector3( 8, 2, 8);

            windmillModels[0].Rotation = new Vector3(0, MathHelper.ToRadians(135), 0);
            windmillModels[1].Rotation = new Vector3(0, MathHelper.ToRadians(-135), 0);

            colliders = new List<GameObject>() { plane, house, windmills[0], windmills[1], hero, tower, windmillModels[0], windmillModels[1] };

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

            foreach (WindmillModel windmillModel in windmillModels)
                windmillModel.Update(gameTime);

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

            plane.Draw(camera, true);
            house.Draw(camera, true);
            foreach (Windmill windmill in windmills)
                windmill.Draw(camera, true);

            hero.Draw(camera, true);
            tower.Draw(camera, true);
            foreach (WindmillModel windmillModel in windmillModels)
                windmillModel.Draw(camera, true);

            base.Draw(gameTime);
        }
    }
}
