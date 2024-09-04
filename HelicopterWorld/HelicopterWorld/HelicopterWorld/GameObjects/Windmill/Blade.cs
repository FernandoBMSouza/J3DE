using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using HelicopterWorld.GameObjects.Primitives;

namespace HelicopterWorld.GameObjects.Windmill
{
    public class Blade : GameObject
    {
        public Blade(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, new Vector3(.5f, 1, .1f), colliderVisible)
        {
            children.Add(new Cube(game, new Vector3(0, .25f, 0), Vector3.Zero, new Vector3(1, 1, 1), new Vector3(.5f, .5f, .05f), color, colliderVisible));
            children.Add(new Triangle3D(game, new Vector3(0, -.25f, 0), new Vector3(0, 0, 180), new Vector3(1, 1, 1), new Vector3(.5f, .5f, .05f), color, colliderVisible));
        }
    }
}
