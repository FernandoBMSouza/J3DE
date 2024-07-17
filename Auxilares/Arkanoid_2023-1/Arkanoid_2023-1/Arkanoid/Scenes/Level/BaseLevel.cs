using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public abstract class BaseLevel : Scene
    {
        public Ball Ball { get; set; }
        public Player Player { get; set; }

        public BaseLevel(Game game) : base(game)
        {
            this.Ball = new Ball(new Vector2(game.Window.ClientBounds.Width / 2, 0),
                                 game.Content.Load<Texture2D>(@"Images/ball"),
                                 new Vector2(400, 400));

            this.Player = new Player(new Vector2((game.Window.ClientBounds.Width - 200) / 2,
                                                 (game.Window.ClientBounds.Height - 50)),
                                     game.Content.Load<Texture2D>(@"Images/barra"),
                                     new Vector2(300, 0));
        }

        public override void Update(GameTime gameTime)
        {
            this.Ball.Update(gameTime, game.Window.ClientBounds);

            this.Player.UpdatePosition(this.Ball);

            this.Player.Update(gameTime, game.Window.ClientBounds);

            if (this.Ball.Rectangle.Intersects(this.Player.Rectangle))
            {
                this.Ball.Speed = new Vector2(this.Ball.Speed.X, -this.Ball.Speed.Y);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Ball.Draw(spriteBatch);

            this.Player.Draw(spriteBatch);
        }
    }
}
