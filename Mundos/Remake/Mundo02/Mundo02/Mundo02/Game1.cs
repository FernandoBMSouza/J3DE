using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Mundo02.Utilities;
using Mundo02.GameObjects;
using Mundo02.GameObjects.Primitives;
using Mundo02.GameObjects.Windmill;

namespace Mundo02
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen screen;
        Camera camera;

        GameObject[] gameObjects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MUNDO 02";
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

            gameObjects = new GameObject[]
            {
                new Square(this, Color.DarkGreen),
                new Cube(this, Color.Blue),
                new Windmill(this, Color.DarkRed, Color.Yellow),
                new Windmill(this, Color.DarkRed, Color.Yellow),
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
            {
                go.Update(gameTime);
                go.World = Matrix.Identity;                
            }

            gameObjects[0].World *= Matrix.CreateScale(20);
            gameObjects[0].World *= Matrix.CreateRotationX(MathHelper.ToRadians(270));
            gameObjects[1].World *= Matrix.CreateTranslation(new Vector3(0, gameObjects[1].Size.Y / 2f, 0));

            gameObjects[2].World *= Matrix.CreateRotationY(MathHelper.ToRadians(-45));
            gameObjects[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians( 45));

            gameObjects[2].World *= Matrix.CreateTranslation(new Vector3( gameObjects[2].Size.X * 4f, gameObjects[2].Size.Y / 2f, 0));
            gameObjects[3].World *= Matrix.CreateTranslation(new Vector3(-gameObjects[3].Size.X * 4f, gameObjects[3].Size.Y / 2f, 0));

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
