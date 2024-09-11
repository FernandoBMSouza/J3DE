using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Estudo.GameObjects.Models
{
    public class Hero : Model3D
    {
        public Hero(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(3, 13, 2));
            this.model = game.Content.Load<Model>(@"3DModels\hero");
        }
    }
}
