using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dorgas.GameObjects.Shapes
{
    public class Triangle3D : Shape
    {
        public Triangle3D(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, color, effect, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionColor[]
            {
                // FRONT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                // REAR
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0, size.Y,-size.Z) / 2f, color),

                // BOT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),

                // LEFT
                new VertexPositionColor(new Vector3(      0, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(      0, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0, size.Y,-size.Z) / 2f, color),

                // RIGHT
                new VertexPositionColor(new Vector3(      0, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(      0, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(      0, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
            };
        }
    }
}
