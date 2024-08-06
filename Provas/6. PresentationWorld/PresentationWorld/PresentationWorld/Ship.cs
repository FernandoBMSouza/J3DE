using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PresentationWorld
{
    class Ship : GameObject
    {
        public Ship(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(1, 1.5f, .3f);
            Model = game.Content.Load<Model>(@"Models\Ship");
            Texture = game.Content.Load<Texture2D>(@"Images\ShipTexture");
        }
    }
}
