using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects.ModelObjects
{
    class BladeModel : GameObject
    {
        public BladeModel(Game1 game)
            : base(game)
        {
            Size = new Vector3(2, 10, .5f);
            Model = game.Models["blade"];
        }
    }
}
