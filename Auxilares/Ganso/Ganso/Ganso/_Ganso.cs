using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ganso
{
    class _Ganso
    {
        Game1 game;
        Texture2D texture;
        Vector2 position;
        Vector2 speed;
        Point size;

        public _Ganso(Game1 game, Vector2 position, Vector2 speed, Point size)
        {
            this.game = game;
            this.position = position;
            this.size = size;
            this.speed = speed;
            texture = game.Content.Load<Texture2D>(@"Content\Ganso");
        }

        public void Update(GameTime gameTime)
        {
            position += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            if (position.X + size.X > game.Window.ClientBounds.Width || position.X < 0)
                speed.X *= -1;

            if (position.Y + size.Y > game.Window.ClientBounds.Height || position.Y < 0)
                speed.Y *= -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, size.X, size.Y), Color.White);
        }
    }
}
