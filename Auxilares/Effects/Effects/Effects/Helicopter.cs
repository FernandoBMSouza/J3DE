using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Effects
{
    class Helicopter : GameObject
    {
        public Helicopter(Game1 game)
            : base(game)
        {
            Size = new Vector3(2, 5, 3);
            Model = game.Content.Load<Model>(@"Models\Helicopter");
        }
    }
}
