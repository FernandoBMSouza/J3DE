using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Tower : BaseModel
    {
        public Tower(Game1 game) 
            : base()
        {
            Model = game.Content.Load<Model>(@"Models\tower");
        }
    }
}
