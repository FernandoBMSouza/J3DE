using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo04
{
    class Tower : GameObject
    {
        public Tower(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Model = game.Content.Load<Model>(@"Models\tower");

            Size = new Vector3(3, 3, 3);
            LBox = new LineBox(game, Size, Color.Green);

            UpdateBoundingBox();
        }
    }
}
