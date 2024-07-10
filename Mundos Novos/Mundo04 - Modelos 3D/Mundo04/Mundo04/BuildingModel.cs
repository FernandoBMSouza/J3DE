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
        public BuildingModel(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Model = game.Content.Load<Model>(@"Models\building");

            Size = new Vector3(2, 5, 3);
            LBox = new LineBox(game, Size, Color.Green);

            UpdateBoundingBox();
        }
    }
}
