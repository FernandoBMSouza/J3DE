using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Primitives
{
    public class Triangle : Shape
    {
        public Triangle(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, new Vector3(scale.X, scale.Y, 0), colliderVisible)
        {
            Vector3 size = new Vector3(1, 1, 0);

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-size.X, -size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0,  size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z) / 2f, color),
            };
        }
    }
}
