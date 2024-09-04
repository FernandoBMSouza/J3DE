using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects.ModelObjects
{
    class BuildingModel : GameObject
    {
        public BuildingModel(Game1 game)
            : base(game)
        {
            Size = new Vector3(2, 5, 4);
            Model = game.Models["building"];
        }
    }
}
