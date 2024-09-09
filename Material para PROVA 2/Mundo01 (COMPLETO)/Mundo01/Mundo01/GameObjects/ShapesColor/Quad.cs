using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Shapes
{
    public class Quad : Shape
    {
        public Quad(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, color, effect, colliderVisible)
        {
            Vector3 size = new Vector3(1, 0, 1);
            SetSize(size);

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
