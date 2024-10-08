﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class BladeModel : GameObject
    {
        public BladeModel(Game1 game)
            : base(game)
        {
            Size = new Vector3(2, 10, .5f);
            Model = game.Content.Load<Model>(@"Models\blade");
        }
    }
}
