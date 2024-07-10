using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    public class Hero : GameObject
    {
        public Hero(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Model = game.Content.Load<Model>(@"Models\hero");

            Size = new Vector3(6, 15, 3);
            LBox = new LineBox(game, Size, Color.Green);

            UpdateBoundingBox();
        }
    }
}
