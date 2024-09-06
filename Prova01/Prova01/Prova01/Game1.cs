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
using Prova01.Utilities;
using Prova01.GameObjects;
using Prova01.GameObjects.Shapes;
using Prova01.GameObjects.Windmill;
using Prova01.GameObjects.Prova01;

namespace Prova01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;
        BasicEffect effect;

        List<GameObject> go;

        bool colliderVisible = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO";
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
            go.Add(new Quad(this, Vector3.Zero, Vector3.Zero, new Vector3(100), Color.DarkSlateGray, colliderVisible));
            go.Add(new Track(this, new Vector3(0, 1, 0), new Vector3(0, 0, 0), new Vector3(5, .5f, 5), Color.Black, true));
            go.Add(new Snail(this, new Vector3(0, 1.8f, -15), new Vector3(0, 270, 0), new Vector3(1, 1, 1), Color.Yellow, true));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            effect = new BasicEffect(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            camera.Update(gameTime);

            foreach (GameObject g in go) g.Update(gameTime);

            Window.Title = "Caracol POS = " + go[2].GetPosition() + " ROT = " + go[2].GetRotation();

            // TRATAMENTO DE COLISAO
            foreach (GameObject g in go)
            {
                if (g.IsColliding(camera.BBox))
                {
                    camera.RestorePosition();
                    g.SetColliderColor(Color.Red);
                }
                else
                {
                    g.SetColliderColor(Color.Green);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (GameObject g in go) g.Draw(camera, effect);

            base.Draw(gameTime);
        }
    }
}
