using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects.ModelObjects
{
    class Hero : GameObject
    {
        public Hero(Game1 game)
            : base(game)
        {
            Size = new Vector3(6, 15, 3);
            Model = game.Models["hero"];
        }
    }
}
