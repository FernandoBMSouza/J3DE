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
using Mundo01.GameObjects.Shapes;
using Mundo01.GameObjects.Windmill;

namespace Mundo01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;
        BasicEffect effect;

        List<GameObject> go;
        List<Texture2D> textures;

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

            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>(@"Images\grass"));
            textures.Add(Content.Load<Texture2D>(@"Images\bricks"));
            textures.Add(Content.Load<Texture2D>(@"Images\rocks"));
            textures.Add(Content.Load<Texture2D>(@"Images\wood"));

            camera = new Camera(this);
            go = new List<GameObject>();
            go.Add(new Quad(this, Vector3.Zero, Vector3.Zero, new Vector3(15), textures[0], colliderVisible));
            go.Add(new Cube(this, new Vector3(0, .5f, 0), Vector3.Zero, Vector3.One, textures[1], colliderVisible));
            go.Add(new Windmill(this, new Vector3(-5, 1, 0), new Vector3(0, 45, 0), Vector3.One, textures[2], textures[3], colliderVisible));
            go.Add(new Windmill(this, new Vector3( 5, 1, 0), new Vector3(0, -45, 0), Vector3.One, textures[2], textures[3], colliderVisible));

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
