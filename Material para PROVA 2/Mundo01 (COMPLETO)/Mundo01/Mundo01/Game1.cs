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
using Mundo01.GameObjects.ShapesTexture;
using Mundo01.GameObjects.Models;
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

        List<GameObject> go;
        List<Texture2D> textures;
        List<Effect> effects;

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

            effects = new List<Effect>();
            effects.Add(Content.Load<Effect>(@"Effects\basic"));
            effects.Add(Content.Load<Effect>(@"Effects\basicColor"));

            camera = new Camera(this);
            go = new List<GameObject>();
            go.Add(new QuadTexture(this, Vector3.Zero, Vector3.Zero, new Vector3(15), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(0, .5f, 0), Vector3.Zero, Vector3.One, effects[0], textures[1], colliderVisible));
            go.Add(new Windmill(this, new Vector3( 5, 1, -3), new Vector3(0, -45, 0), Vector3.One, effects[0], textures[2], textures[3], colliderVisible));
            //go.Add(new Windmill(this, new Vector3(-5, 1, -3), new Vector3(0,  45, 0), Vector3.One, effects[0], textures[2], textures[3], colliderVisible));
            go.Add(new Windmill(this, new Vector3(-5, 1, -3), new Vector3(0, 45, 0), Vector3.One, Color.Blue, Color.Yellow, effects[1], colliderVisible));
            go.Add(new Hero(this, new Vector3(0, .8f, 3), new Vector3(0, 0, 0), new Vector3(.1f), colliderVisible));
            go.Add(new Tower(this, new Vector3(0, 2, -3), new Vector3(0, 0, 0), new Vector3(1,2,1), colliderVisible));
            go.Add(new WindmillModel(this, new Vector3( 5, 0.8f, 3), new Vector3(0, 225, 0), new Vector3(.5f), colliderVisible));
            go.Add(new WindmillModel(this, new Vector3(-5, 0.8f, 3), new Vector3(0, 135, 0), new Vector3(.5f), colliderVisible));

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

            foreach (GameObject g in go) g.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
