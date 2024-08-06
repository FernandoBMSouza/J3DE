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

namespace WindowsGame1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        _Background background;
        _Animation animation;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // criando fundo de tela / cenário
            this.background = new _Background(this,
                                              Vector2.Zero,
                                              new Point(graphics.PreferredBackBufferWidth,
                                                        graphics.PreferredBackBufferHeight));

            // criando personagem animado
            int w = 100;
            int h = 200;
            float x = Window.ClientBounds.Width / 2f - w / 2f;
            float y = Window.ClientBounds.Height - h * 1.18f;
            float speed = 200;
            this.animation = new _Animation(this,
                                            new Vector2(x, y),
                                            new Point(w, h),
                                            new Vector2(speed));

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) 
                this.Exit();

            this.animation.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            this.background.Draw(spriteBatch);
            this.animation.Draw(this.spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
