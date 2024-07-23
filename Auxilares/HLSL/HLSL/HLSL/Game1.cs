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

namespace HLSL
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        VertexPositionTexture[] verts;
        VertexBuffer vertexBuffer;
        Matrix world, view, projection;
        // BasicEffect effect;
        Effect effect;
        Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "HLSL - PIXEL SHADER";
        }

        protected override void Initialize()
        {
            world = Matrix.Identity;
            world *= Matrix.CreateScale(2, 2, 1);
            view = Matrix.CreateLookAt(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                             Window.ClientBounds.Width / (float)Window.ClientBounds.Height,
                                                             1, 100);
            
            // GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            verts = new VertexPositionTexture[6];
            verts[0] = new VertexPositionTexture(new Vector3(-1, 1, 0), new Vector2(0, 0));
            verts[1] = new VertexPositionTexture(new Vector3( 1, 1, 0), new Vector2(1, 0));
            verts[2] = new VertexPositionTexture(new Vector3(-1,-1, 0), new Vector2(0, 1));

            verts[3] = new VertexPositionTexture(new Vector3( 1, 1, 0), new Vector2(1, 0));
            verts[4] = new VertexPositionTexture(new Vector3( 1,-1, 0), new Vector2(1, 1));
            verts[5] = new VertexPositionTexture(new Vector3(-1,-1, 0), new Vector2(0, 1));

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionTexture), verts.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionTexture>(verts);

            // effect = new BasicEffect(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>(@"Textures\paisagem");
            effect = Content.Load<Effect>(@"Effects\Effect1");
        }

        protected override void UnloadContent()
        {
            texture.Dispose();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            //effect.World = world;
            //effect.View = view;
            //effect.Projection = projection;
            //// effect.VertexColorEnabled = true;
            //effect.TextureEnabled = true;
            //effect.Texture = texture;

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(world);
            effect.Parameters["View"].SetValue(view);
            effect.Parameters["Projection"].SetValue(projection);
            effect.Parameters["colorTexture"].SetValue(texture);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, verts, 0, verts.Length / 3);
            }
           // effect.TextureEnabled = false;

            base.Draw(gameTime);
        }
    }
}
