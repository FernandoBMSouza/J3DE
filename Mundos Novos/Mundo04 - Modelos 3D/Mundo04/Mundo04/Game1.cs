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
        Random random;

        Quad plane;
        Cube house;
        Windmill[] windmills;
        WindmillModel[] windmillModels;

        List<ICollider> colliders;
        const bool SHOW_COLLIDERS = false;

        Hero hero;
        Tower tower;

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

            camera = new Camera(this);
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);


            plane = new Quad(this, GraphicsDevice, SHOW_COLLIDERS);
            house = new Cube(this, GraphicsDevice, SHOW_COLLIDERS);
            windmills = new Windmill[]
            {
                new Windmill(this, GraphicsDevice, random.Next(50,1000), true, SHOW_COLLIDERS),
                new Windmill(this, GraphicsDevice, random.Next(50,1000), true, SHOW_COLLIDERS),
            };
            windmillModels = new WindmillModel[]
            {
                new WindmillModel(this, GraphicsDevice, random.Next(50,1000), true, SHOW_COLLIDERS),
                new WindmillModel(this, GraphicsDevice, random.Next(50,1000), true, SHOW_COLLIDERS),
            };
            hero = new Hero(this, GraphicsDevice, SHOW_COLLIDERS);
            tower = new Tower(this, GraphicsDevice, SHOW_COLLIDERS);

            colliders = new List<ICollider>() { plane, house, windmills[0], windmills[1], hero, tower, windmillModels[0], windmillModels[1], };
            
            //TRANSFORMATIONS
            plane.Scale(new Vector3(20, 0, 20));
            house.Translation(new Vector3(0, 1, 0));

            windmills[0].Rotation('Y', 45, true);
            windmills[1].Rotation('Y', -45, true);
            windmills[0].Translation(new Vector3(-8, 2, -6), true);
            windmills[1].Translation(new Vector3( 8, 2, -6), true);

            windmillModels[0].Rotation('Y', 135, true);
            windmillModels[1].Rotation('Y',-135, true);
            windmillModels[0].Translation(new Vector3(-8, 1.5f, 6), true);
            windmillModels[1].Translation(new Vector3( 8, 1.5f, 6), true);

            hero.SetIdentity();
            hero.Scale(new Vector3(.2f));
            hero.Translation(new Vector3(0, 1.5f, 6));

            tower.SetIdentity();
            tower.Scale(new Vector3(1, 4, 1));
            tower.Rotation('X', 0);
            tower.Translation(new Vector3(0, 4, -8));
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
            foreach (Windmill w in windmills) w.Update(gameTime);
            foreach (WindmillModel w in windmillModels) w.Update(gameTime);

            foreach (ICollider c in colliders)
            {
                if (camera.IsColliding(c.BBox))
                {
                    camera.RestorePosition();
                    c.SetColliderColor(Color.Red);
                }
                else
                {
                    c.SetColliderColor(Color.Green);
                }
            }
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
            hero.Draw(camera);
            tower.Draw(camera);
            foreach (Windmill w in windmills)
                w.Draw(camera);
            foreach (WindmillModel w in windmillModels)
                  w.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
