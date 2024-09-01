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
using Mundo01.Utilities;
using Mundo01.GameObjects;
using Mundo01.GameObjects.Primitives;

namespace Mundo01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        GameObject[] gameObjects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO 01";
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
                new Quad(this, Color.DarkGreen),
                new Cube(this, Color.Blue),
            };

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

            foreach (GameObject go in gameObjects)
            {
                go.Update(gameTime);
                go.World = Matrix.Identity;
            }

            gameObjects[0].World *= Matrix.CreateScale(20);
            gameObjects[1].World *= Matrix.CreateTranslation(new Vector3(0, gameObjects[1].Size.Y / 2f, 0));

            Window.Title = "Info: " + gameObjects[0].GetPosition() + " - " + gameObjects[0].GetRotation() + " - " + gameObjects[0].GetScale() + " - " + gameObjects[0].Size;

            foreach (GameObject go in gameObjects)
            {
                if (camera.IsColliding(go.BoundingBox))
                {
                    camera.RestorePosition();
                    go.SetColliderColor(Color.Red);
                }
                else
                {
                    go.SetColliderColor(Color.Green);
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
