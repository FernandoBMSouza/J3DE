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

namespace Collision2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Matrix view, projection;

        List<Cube> cubeList = new List<Cube>();

        BasicEffect effect;

        bool useWireframe = false;
        int count = 0;
        int gap = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            this.view = Matrix.CreateLookAt(new Vector3(0, 3, 15),
                                            Vector3.Zero,
                                            Vector3.Up);

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  Window.ClientBounds.Width /
                                                                  (float)Window.ClientBounds.Height,
                                                                  0.1f, 100);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.effect = new BasicEffect(GraphicsDevice);

            this.cubeList.Add(new Player(ref this.graphics, new Vector3(3,0,0)));

            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(5.5f, 0, 6))); 
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(5.5f, 0, 3))); 
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(5.5f, 0, 0)));
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(5.5f, 0,-3)));
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(5.5f, 0,-6)));

            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(0, 0, 6)));
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(0, 0, 3))); 
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(0, 0, 0)));
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(0, 0, -3)));
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(0, 0, -6)));

            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(-5.5f, 0, 6)));
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(-5.5f, 0, 3))); 
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(-5.5f, 0, 0)));
            //this.cubeList.Add(new Cube(ref this.graphics, new Vector3(-5.5f, 0,-3)));
            this.cubeList.Add(new Cube(ref this.graphics, new Vector3(-5.5f, 0,-6)));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            foreach (Cube c in this.cubeList)
            {
                c.Update(gameTime);
            }

            for (var i = 1; i < this.cubeList.Count; i++)
            {
                if (this.cubeList[i].GetBoundingBox().Intersects(this.cubeList[0].GetBoundingBox()))
                {
                    ((Player)this.cubeList[0]).RestorePosition(gameTime);
                    this.cubeList[i].UseWireframe(this.cubeList[0].IsWireframe());
                }
            }

            for (var i = 1; i < this.cubeList.Count; i++)
            {
                if (this.cubeList[i].IsWireframe() == this.useWireframe)
                {
                    this.count++;
                }
            }

            if (this.count == this.cubeList.Count - 1 &&
                 this.cubeList[0].IsWireframe() == this.useWireframe)
            {
                this.useWireframe = !this.useWireframe;
            }

            if (this.count == this.cubeList.Count - 1)
            {
                gap++;
            }

            if (gap > 0 && gap <= 100)
            {
                gap++;
            }
            else if (gap > 100)
            {
                this.cubeList[0].UseWireframe(this.useWireframe);
                gap = 0;
            }

            this.count = 0;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            foreach (Cube c in this.cubeList)
            {
                c.Draw(ref effect, ref this.view, ref this.projection);
            }

            base.Draw(gameTime);
        }
    }
}
