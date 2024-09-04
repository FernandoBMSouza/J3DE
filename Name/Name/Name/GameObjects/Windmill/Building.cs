using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Name.GameObjects.Shapes;

namespace Name.GameObjects.Windmill
{
    public class Building : GameObject
    {
        public Building(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 2, 2));

            children.Add(new Cube(game, new Vector3(0, 0, .5f), new Vector3(0, 0, 0), new Vector3(1, 2, 1), color, false));
            children.Add(new RightTriangle3D(game, new Vector3(0, 0, -.5f), new Vector3(0, 90, 0), new Vector3(1, 2, 1), color, false));
        }
    }
}
