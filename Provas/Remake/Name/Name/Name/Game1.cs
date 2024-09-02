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
using Name.Utilities;
using Name.GameObjects;
using Name.GameObjects.Primitives;
using Name.GameObjects.Name.Letters;
using Name.GameObjects.Name;

namespace Name
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        GameObject[] gameObjects;

        bool showCollidersLines = false;
        float speed, angle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "FERNANDO - PROVA 01";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera(this);

            gameObjects = new GameObject[]
            {
                new Fernando(this, Color.Blue, Color.LightBlue, showCollidersLines),
            };

            speed = 100;

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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            camera.Update(gameTime);

            angle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            foreach (GameObject go in gameObjects)
            {
                go.Update(gameTime);
                go.World = Matrix.Identity;
                go.World *= Matrix.CreateScale(new Vector3(1,1,.5f));
                go.World *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            }

            //Window.Title = "Info: " + gameObjects[0].GetPosition() + " - " + gameObjects[0].GetRotation() + " - " + gameObjects[0].GetScale() + " - " + gameObjects[0].Size;

            // TRATAMENTO DE COLISAO
            foreach (GameObject go in gameObjects)
            {
                if (camera.IsColliding(go))
                {
                    camera.RestorePosition();
                    go.BoxCollider.SetColor(Color.Red);
                }
                else
                {
                    go.BoxCollider.SetColor(Color.Green);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject go in gameObjects)
                go.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
