using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Models
{
    class BladeModel : Model3D
    {
        public BladeModel(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(2, 10, 1));
            this.model = game.Content.Load<Model>(@"3DModels\blade");
        }
    }
}
