using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class PropellerModel : GameObject
    {
        public PropellerModel(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Model = game.Content.Load<Model>(@"Models\propeller");

            Size = new Vector3(2, 10, .5f);
            LBox = new LineBox(game, Size, Color.Green);

            UpdateBoundingBox();
        }
    }
}
