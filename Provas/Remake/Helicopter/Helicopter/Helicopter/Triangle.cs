﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    class Triangle : Primitive
    {
        public Triangle(Game1 game, Color color) 
            : base(game, color)
        {
            Vector3 size = new Vector3(1, 1, 0);
            size /= 2;

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-size.X, -size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(      0,  size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z), color),
            };
        }
    }
}