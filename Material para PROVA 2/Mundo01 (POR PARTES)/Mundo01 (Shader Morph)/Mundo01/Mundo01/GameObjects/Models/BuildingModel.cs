using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Models
{
    public class BuildingModel : Model3D
    {
        public BuildingModel(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(2, 5, 2));
            this.model = game.Content.Load<Model>(@"3DModels\building");
        }
    }
}
