using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PresentationWorld
{
    class BladeModel : GameObject
    {
        public BladeModel(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(2, 10, .5f);
            Model = game.Content.Load<Model>(@"Models\blade");
            Texture = game.Content.Load<Texture2D>(@"Images\wood");
        }
    }
}
