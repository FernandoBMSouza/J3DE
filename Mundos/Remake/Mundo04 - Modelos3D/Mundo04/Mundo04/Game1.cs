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
using Mundo04.Utilities;
using Mundo04.GameObjects;
using Mundo04.GameObjects.Primitives;
using Mundo04.GameObjects.Windmill;

namespace Mundo04
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        GameObject[] gameObjects;
        Texture2D[] textures;

        bool showCollidersLines = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO 04 - MODELOS";
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

            textures = new Texture2D[]
            {
                Content.Load<Texture2D>(@"Images\grass"),
                Content.Load<Texture2D>(@"Images\bricks"),
                Content.Load<Texture2D>(@"Images\rocks"),
                Content.Load<Texture2D>(@"Images\wood"),
            };

            gameObjects = new GameObject[]
            {
                new Quad(this, textures[0], showCollidersLines),
                new Cube(this, textures[1], showCollidersLines),
                new Windmill(this, textures[2], textures[3], showCollidersLines),
                new Windmill(this, textures[2], textures[3], showCollidersLines),
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
                go.World = Matrix.Identity;

            gameObjects[0].World *= Matrix.CreateScale(20);
            gameObjects[1].World *= Matrix.CreateTranslation(new Vector3(0, gameObjects[1].Size.Y / 2f, 0));
            
            gameObjects[2].World *= Matrix.CreateRotationY(MathHelper.ToRadians(-45));
            gameObjects[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians(45));

            gameObjects[2].World *= Matrix.CreateTranslation(new Vector3(gameObjects[2].Size.X * 4f, gameObjects[2].Size.Y / 2f, 0));
            gameObjects[3].World *= Matrix.CreateTranslation(new Vector3(-gameObjects[3].Size.X * 4f, gameObjects[3].Size.Y / 2f, 0));
            
            //Window.Title = "Info: " + gameObjects[0].GetPosition() + " - " + gameObjects[0].GetRotation() + " - " + gameObjects[0].GetScale() + " - " + gameObjects[0].Size;
            foreach(GameObject go in gameObjects)
                go.Update(gameTime);

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
