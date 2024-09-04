﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Mundo01.GameObjects.Primitives;

namespace Mundo01.GameObjects.Windmill
{
    public class Blade : GameObject
    {
        public Blade(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, new Vector3(.5f, 1, .1f), colliderVisible)
        {
            children.Add(new Cube(game, position + new Vector3(0, .25f, 0), rotation, scale * new Vector3(1, 1, .1f), new Vector3(.5f), color, false));
            children.Add(new Triangle3D(game, position + new Vector3(0,-.25f, 0), rotation + new Vector3(0,0,180), scale * new Vector3(1,1,.1f), new Vector3(.5f), color, false));
        }
    }
}