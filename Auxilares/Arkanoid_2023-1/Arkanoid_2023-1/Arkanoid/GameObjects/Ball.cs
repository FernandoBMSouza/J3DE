using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Ball : GameObject
    {
        public Vector2 Speed { get; set; }

        public Ball(Vector2 position, Texture2D texture, Vector2 speed)
            : base(position, texture)
        {
            this.Speed = speed;
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            this.Position += this.Speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            if (this.Position.X < 0 || this.Position.X > clientBounds.Width - 200 - this.Texture.Width)
                this.Speed = new Vector2(-Speed.X, Speed.Y);

            if (this.Position.Y < 0 || this.Position.Y > clientBounds.Height - this.Texture.Height)
                this.Speed = new Vector2(Speed.X, -Speed.Y);

            base.Update(gameTime, clientBounds);
        }
    }
}
