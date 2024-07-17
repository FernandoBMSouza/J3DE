#define AUTOMATIC

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Arkanoid
{
    public class Player : GameObject
    {
        Vector2 Speed { get; set; }

        public Player(Vector2 position, Texture2D texture, Vector2 speed)
            : base(position, texture)
        {
            this.Speed = speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
#if AUTOMATIC
#else
            this.Input(gameTime);
#endif
            if (Position.X < 0)
                Position = new Vector2(0, Position.Y);
            else if (Position.X > clientBounds.Width - 200 - this.Texture.Width)
                Position = new Vector2(clientBounds.Width - 200 - this.Texture.Width, Position.Y);

            base.Update(gameTime, clientBounds);
        }

        public void UpdatePosition(GameObject gameObject)
        {
#if AUTOMATIC
            this.Position = new Vector2(gameObject.Position.X - 34, Position.Y);
#endif
        }

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                this.Position -= this.Speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                this.Position += this.Speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
        }
    }
}
