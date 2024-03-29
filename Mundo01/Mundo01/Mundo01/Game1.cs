using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mundo01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screen screen;
        Camera camera;
        GameObject plane;
        GameObject cube;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            IsMouseVisible = true;
            Window.Title = "MUNDO 01";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screen = Screen.GetInstance();
            screen.Width = graphics.PreferredBackBufferWidth;
            screen.Height = graphics.PreferredBackBufferHeight;

            camera = new Camera();
            plane = new Plane(GraphicsDevice);
            cube = new Cube(GraphicsDevice, new Vector3(0,1,0));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //RasterizerState rs = new RasterizerState();
            //rs.CullMode = CullMode.None;
            //rs.FillMode = FillMode.WireFrame;
            //GraphicsDevice.RasterizerState = rs;

            plane.Draw(camera);            
            cube.Draw(camera);

            base.Draw(gameTime);
        }
    }
}
