using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Tower : GameObject
    {
        public Tower(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(3, 4, 3);
            Model = game.Content.Load<Model>(@"Models\tower");
        }
    }
}
