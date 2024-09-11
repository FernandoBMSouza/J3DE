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
using Estudo.Utilities;
using Estudo.GameObjects;
using Estudo.GameObjects.ShapesTexture;
using Estudo.GameObjects.Models;
using Estudo.GameObjects.Shapes;
using Estudo.GameObjects.Windmill;
using Estudo.GameObjects.Mine;

namespace Estudo
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;
        Random random;

        List<GameObject> go;
        List<Texture2D> textures;
        List<Effect> effects;

        bool colliderVisible = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "ESTUDO";
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
            random = new Random();

            textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>(@"Images\grass"));
            textures.Add(Content.Load<Texture2D>(@"Images\marrom"));
            textures.Add(Content.Load<Texture2D>(@"Images\spider"));
            textures.Add(Content.Load<Texture2D>(@"Images\rosa"));
            textures.Add(Content.Load<Texture2D>(@"Images\azul"));

            effects = new List<Effect>();
            effects.Add(Content.Load<Effect>(@"Effects\basic"));

            go = new List<GameObject>();
            go.Add(new QuadTexture(this, Vector3.Zero, Vector3.Zero, new Vector3(100), effects[0], textures[0], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3(-25, 2, 0), Vector3.Zero, new Vector3(5,5,5), effects[0], textures[1], colliderVisible));
            go.Add(new CubeTexture(this, new Vector3( 25, 5, 0), Vector3.Zero, new Vector3(5,10,5), effects[0], textures[1], colliderVisible));
            go.Add(new Helicopter(this, new Vector3(-25, 6, 0), Vector3.Zero, new Vector3(2), effects[0], textures[3], textures[4], colliderVisible));
            go.Add(new Spider(this, new Vector3(0, .25f, 20), Vector3.Zero, new Vector3(.25f), effects[0], textures[2], (Helicopter)go[3], colliderVisible));

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

            foreach (GameObject g in go) 
                g.Update(gameTime);

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
