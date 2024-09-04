using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Mundo01.GameObjects.Primitives;

namespace Mundo01.GameObjects.Windmill
{
    public class Building : GameObject
    {
        public Building(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, new Vector3(1,2,2), colliderVisible)
        {
            children.Add(new Cube(game, position + new Vector3(0, 0, .5f), rotation, scale, new Vector3(1,2,1), color, false));
            children.Add(new RightTriangle3D(game, position + new Vector3(0, 0, -.5f), rotation + new Vector3(0, 90, 0), scale,  new Vector3(1,2,1), color, false));
        }
    }
}
