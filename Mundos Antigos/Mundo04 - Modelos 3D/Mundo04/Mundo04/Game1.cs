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

namespace Mundo04
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;

        Quad plane;
        Cube house;
        Windmill[] windmills;

        Tower tower;
        WindmillModel[] windmillModels;
        Hero hero;

        Random random;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 04";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera();
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);


            plane = new Quad(this, GraphicsDevice);
            house = new Cube(this, GraphicsDevice);
            windmills = new Windmill[]
            {
                new Windmill(this, GraphicsDevice, random.Next(50,500)),
                new Windmill(this, GraphicsDevice, random.Next(50,500)),
            };

            tower = new Tower(this);

            windmillModels = new WindmillModel[]
            {
                new WindmillModel(this, random.Next(50, 500)),
                new WindmillModel(this, random.Next(50, 500)),
            };

            hero = new Hero(this);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            camera.Update(gameTime);

            plane.SetIdentity();
            plane.Scale(new Vector3(20, 0, 20));

            house.SetIdentity();
            house.Translation(new Vector3(0,1,0));

            foreach (Windmill w in windmills)
                w.Update(gameTime);

            windmills[0].RotationY(45);
            windmills[1].RotationY(-45);

            windmills[0].Translation(new Vector3(-8, 2, -6));
            windmills[1].Translation(new Vector3( 8, 2, -6));

            tower.SetIdentity();
            tower.Scale(new Vector3(1,4,1));
            tower.RotationX(0);
            tower.Translation(new Vector3(0, 4, -8));

            foreach (WindmillModel w in windmillModels)
                w.Update(gameTime);

            windmillModels[0].RotationY(+135);
            windmillModels[1].RotationY(-135);

            windmillModels[0].Translation(new Vector3(-8, 1.5f, 6));
            windmillModels[1].Translation(new Vector3(8, 1.5f, 6));

            hero.SetIdentity();
            hero.Scale(new Vector3(.2f));
            hero.Translation(new Vector3(0, 1.5f, 6));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            //GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);
            house.Draw(camera);
            foreach (Windmill w in windmills)
                w.Draw(camera);

            tower.Draw(camera);
            foreach (WindmillModel w in windmillModels)
                w.Draw(camera);

            hero.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
