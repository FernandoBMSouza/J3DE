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
using Name.GameObjects.Shapes;
using Name.GameObjects.Windmill;
using Name.GameObjects.Name;

namespace Name
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
            Window.Title = "FERNANDO";
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
            go.Add(new Fernando(this, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), Color.Blue, colliderVisible));

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

            // TRATAMENTO DE COLISAO
            foreach (GameObject g in go)
            {
                if (g.IsColliding(camera.BBox))
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

            foreach (GameObject g in go) g.Draw(camera, effect);

            base.Draw(gameTime);
        }
    }
}
