using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Background : GameObject
    {
        public Background(Vector2 position, Texture2D texture) 
            : base(position, texture)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle clientBounds)
        {
            spriteBatch.Draw(this.Texture, 
                             new Rectangle(0,0,clientBounds.Width,clientBounds.Height),
                             Color.White);
        }
    }
}
