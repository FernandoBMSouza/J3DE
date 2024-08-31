using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
    class Cube : Primitive
    {
        public Cube(Game1 game, Color color)
            : base(game, color)
        {
            Vector3 size = new Vector3(1, 1, 1);
            size /= 2;

            vertices = new VertexPositionColor[]
            {
                // FRONT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z), color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z), color),

                // REAR
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z), color),

                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z), color),

                // RIGHT
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z), color),

                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z), color),

                // LEFT
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z), color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z), color),

                // TOP
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z), color),

                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z), color),

                // BOT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z), color),

                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z), color),
            };
        }
    }
}
