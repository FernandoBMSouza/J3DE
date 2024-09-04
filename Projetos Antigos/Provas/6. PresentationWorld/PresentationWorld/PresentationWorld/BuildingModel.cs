using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PresentationWorld
{
    class BuildingModel : GameObject
    {
        public BuildingModel(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Model = game.Content.Load<Model>(@"Models\building");
            Texture = game.Content.Load<Texture2D>(@"Images\rocks");
            Size = new Vector3(2, 5, 4);
        }
    }
}
