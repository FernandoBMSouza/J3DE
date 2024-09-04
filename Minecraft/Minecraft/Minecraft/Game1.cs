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
using Minecraft.Utilities;
using Minecraft.GameObjects;
using Minecraft.GameObjects.Primitives;
using Minecraft.GameObjects.Windmill;
using Minecraft.GameObjects.Character;

namespace Minecraft
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        List<GameObject> go;

        bool showCollidersLines = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO MINECRAFT";
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
            go = new List<GameObject>();
            go.Add(new Quad(this, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(100), new Vector3(1), Color.Green, showCollidersLines));
            go.Add(new Player(this, new Vector3(0, 2.6f, 0), new Vector3(0, 0, 0), new Vector3(1), Color.DarkGoldenrod, showCollidersLines));

            for (int i = 0; i < 50; i++)
                go.Add(new Enemy(this, new Vector3(0, 2.6f, 0), Vector3.Zero, Vector3.One, Color.Black, showCollidersLines));

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

            foreach (GameObject g in go) g.Update(gameTime);

            // TRATAMENTO DE COLISAO
            foreach (GameObject g in go)
            {
                if (camera.IsColliding(g.GetCollider()))
                {
                    camera.RestorePosition();
                    //g.BoxCollider.SetColor(Color.Red);
                }
                else
                {
                    //g.BoxCollider.SetColor(Color.Green);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
