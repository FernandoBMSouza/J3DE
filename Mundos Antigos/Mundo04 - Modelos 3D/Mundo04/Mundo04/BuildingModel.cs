using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo04
{
    class BuildingModel : BaseModel
    {
        public BuildingModel(Game1 game)
            : base()
        {
            Model = game.Content.Load<Model>(@"Models\building");
        }
    }
}
