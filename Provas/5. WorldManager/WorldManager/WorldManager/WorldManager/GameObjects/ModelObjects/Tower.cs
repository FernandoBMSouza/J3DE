using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects.ModelObjects
{
    class Tower : GameObject
    {
        public Tower(Game1 game)
            : base(game)
        {
            Size = new Vector3(3, 4, 3);
            Model = game.Models["tower"];
        }
    }
}
