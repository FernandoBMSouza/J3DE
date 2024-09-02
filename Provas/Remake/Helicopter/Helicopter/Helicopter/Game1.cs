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
using Helicopter.Utilities;
using Helicopter.GameObjects;
using Helicopter.GameObjects.Primitives;
using Helicopter.GameObjects.Windmill;

namespace Helicopter
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        List<GameObject> gameObjects;

        bool showCollidersLines = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "HELICOPTER";
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

            gameObjects = new List<GameObject>();
            gameObjects.Add(new Quad(this, Color.Green, showCollidersLines));
            gameObjects.Add(new Cube(this, Color.DarkGray, showCollidersLines));
            gameObjects.Add(new Cube(this, Color.DarkGray, showCollidersLines));
            gameObjects.Add(new Ship(this, Color.Blue, Color.DarkGoldenrod, gameObjects[1], gameObjects[2], showCollidersLines));

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

            gameObjects[0].World *= Matrix.CreateScale(50);
            gameObjects[1].World *= Matrix.CreateScale(new Vector3(3));
            gameObjects[2].World *= Matrix.CreateScale(new Vector3(3, 6, 3));
            gameObjects[1].World *= Matrix.CreateTranslation(new Vector3(gameObjects[1].Size.X * -15, (gameObjects[1].Size.Y * gameObjects[1].GetScale().Y) / 2, 0));
            gameObjects[2].World *= Matrix.CreateTranslation(new Vector3(gameObjects[2].Size.X * 15, (gameObjects[2].Size.Y * gameObjects[2].GetScale().Y) / 2, 0));

            gameObjects[3].World *= Matrix.CreateTranslation(gameObjects[1].GetPosition() + new Vector3(0, (gameObjects[1].Size.Y * gameObjects[1].GetScale().Y) / 2 + (gameObjects[3].Size.Y * gameObjects[3].GetScale().Y) / 2, 0));

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
