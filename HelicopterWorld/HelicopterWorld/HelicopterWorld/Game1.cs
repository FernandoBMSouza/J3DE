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
using HelicopterWorld.Utilities;
using HelicopterWorld.GameObjects;
using HelicopterWorld.GameObjects.Primitives;
using HelicopterWorld.GameObjects.Windmill;

namespace HelicopterWorld
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
            Window.Title = "MUNDO HELICOPTERO";
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
            go.Add(new Quad(this, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(25), new Vector3(1), Color.Green, showCollidersLines));
            go.Add(new Cube(this, new Vector3(-5, .5f, 0), new Vector3(0, 0, 0), new Vector3(3,1,3), new Vector3(1), Color.DarkGray, showCollidersLines));
            go.Add(new Cube(this, new Vector3(5, 1.5f, 0), new Vector3(0, 0, 0), new Vector3(3), new Vector3(1), Color.DarkGray, showCollidersLines));
            go.Add(new Helicopter(this, new Vector3(-5,1.5f,0), new Vector3(0,0,0), new Vector3(1,1,1), Color.CadetBlue, Color.DarkGoldenrod, go[1], go[2], true));

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