using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Prova01.GameObjects.Shapes;
using Prova01.Utilities.Collision;

namespace Prova01.GameObjects.Windmill
{
    public class Blade : GameObject
    {
        public Blade(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(.5f, 1, .1f));

            children.Add(new Cube(game, new Vector3(0, .25f, 0), Vector3.Zero, new Vector3(.5f, .5f, .05f), color, false));
            children.Add(new Triangle3D(game, new Vector3(0, -.25f, 0), new Vector3(0, 0, 180), new Vector3(.5f, .5f, .05f), color, false));
        }
    }
}
