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

namespace Collision
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Matrix view, projection;
        BasicEffect effect;

        _Collider[] collider;
        _Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.view = Matrix.CreateLookAt(new Vector3(10, 10, 10),
                                            Vector3.Zero,
                                            Vector3.Up);
            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  Window.ClientBounds.Width / (float)Window.ClientBounds.Height,
                                                                  0.001f,
                                                                  1000);

            this.collider = new _Collider[]
            {
                new _Collider(this, new Vector3(0,2,-6), new Vector3(6, 4, 0.5f), Color.Green),
                new _Collider(this, new Vector3(0,2, 6), new Vector3(6, 4, 0.5f), Color.Green),
            };

            this.player = new _Player(this, new Vector3(0, 0.5f, 0), Vector3.One, Color.White);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.effect = new BasicEffect(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            this.player.Update(gameTime);

            foreach (_Collider c in this.collider)
            {
                if (c.IsColliding(this.player.GetBoundingBox()))
                {
                    Window.Title = "COLIDINDO";
                    c.GetLineBox().SetColor(Color.Red);
                    this.player.RestorePosition();
                    return;
                }
                else
                {
                    Window.Title = "-----";
                    c.GetLineBox().SetColor(Color.Green);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.effect.View = this.view;
            this.effect.Projection = this.projection;

            foreach (_Collider c in this.collider)
            {
                c.Draw(this.effect);
            }

            this.player.Draw(this.effect);

            base.Draw(gameTime);
        }
    }
}
