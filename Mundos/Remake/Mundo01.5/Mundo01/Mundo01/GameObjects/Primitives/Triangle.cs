using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Primitives
{
    class Triangle : Primitive
    {
        public Triangle(Game1 game, Color color)
            : base(game, color)
        {
            Size = new Vector3(1, 1, 0);

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-Size.X, -Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0,  Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, -Size.Y, Size.Z) / 2f, color),
            };
        }
    }
}
