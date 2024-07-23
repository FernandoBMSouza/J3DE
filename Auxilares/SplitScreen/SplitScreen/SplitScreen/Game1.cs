using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SplitScreen
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Model model;
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0.001f, 4), new Vector3(0, 0, 0), Vector3.UnitZ);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);

        private Matrix topView = Matrix.CreateLookAt(new Vector3(0, 0, 4), new Vector3(0, 0, 0), new Vector3(0, 0.001f, 1f));
        private Matrix frontView = Matrix.CreateLookAt(new Vector3(0, 4, 0), new Vector3(0, 0, 0), Vector3.UnitZ);
        private Matrix sideView = Matrix.CreateLookAt(new Vector3(4, 0, 0), new Vector3(0, 0, 0), Vector3.UnitZ);
        private Matrix perspectiveView = Matrix.CreateLookAt(new Vector3(4, 4, 4), new Vector3(0, 0, 0), Vector3.UnitZ);

        private Viewport topViewport;
        private Viewport sideViewport;
        private Viewport frontViewport;
        private Viewport perspectiveViewport;

        Texture2D divider;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            divider = CreatePixelTexture(GraphicsDevice);

            topViewport = new Viewport(0, 0, 400, 240);
            sideViewport = new Viewport(400, 0, 400, 240);
            frontViewport = new Viewport(0, 240, 400, 240);
            perspectiveViewport = new Viewport(400, 240, 400, 240);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            model = Content.Load<Model>("Ship");
        }

        protected override void UnloadContent()
        {
        }

        float angle = 0;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            angle += 0.01f;
            world = Matrix.CreateRotationZ(angle);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Viewport original = GraphicsDevice.Viewport;

            GraphicsDevice.Viewport = topViewport;
            DrawModel(model, world, topView, projection);

            GraphicsDevice.Viewport = sideViewport;
            DrawModel(model, world, sideView, projection);

            GraphicsDevice.Viewport = frontViewport;
            DrawModel(model, world, frontView, projection);

            GraphicsDevice.Viewport = perspectiveViewport;
            DrawModel(model, world, perspectiveView, projection);

            GraphicsDevice.Viewport = original;

            int lineThickness = 3;
            spriteBatch.Begin();
            //Linha vertical
            spriteBatch.Draw(divider, new Rectangle(400 - lineThickness / 2, 0, lineThickness, GraphicsDevice.Viewport.Height), Color.Green);
            // Linha horizontal
            spriteBatch.Draw(divider, new Rectangle(0, 240 - lineThickness / 2, GraphicsDevice.Viewport.Width, lineThickness), Color.Green);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

        private Texture2D CreatePixelTexture(GraphicsDevice graphicsDevice)
        {
            Texture2D texture = new Texture2D(graphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });
            return texture;
        }
    }
}
