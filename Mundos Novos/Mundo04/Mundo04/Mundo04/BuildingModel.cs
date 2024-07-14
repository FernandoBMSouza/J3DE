using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class BuildingModel : GameObject
    {
        public BuildingModel(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Model = game.Content.Load<Model>(@"Models\building");
            Size = new Vector3(2, 5, 3);
        }
    }
}
