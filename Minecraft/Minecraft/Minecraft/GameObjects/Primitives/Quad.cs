using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Primitives
{
    public class Quad : Shape
    {
        public Quad(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, Color color, bool colliderVisible = true)
            : base(game, position, rotation, new Vector3(scale.X, 0, scale.Z), new Vector3(size.X, 0, size.Z), colliderVisible)
        {
            size.Y = 0;

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-size.X,  size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,  size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X,  size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y, size.Z) / 2f, color),
            };
        }
    }
}
