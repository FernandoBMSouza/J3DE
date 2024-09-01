﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Primitives
{
    class Cube : Primitive
    {
        public Cube(Game1 game, Color color)
            : base(game, color)
        {
            Size = Vector3.One;
            vertices = new VertexPositionColor[]
            {
                // FRONT
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),

                // REAR
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, color),

                // RIGHT
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3( Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),

                // LEFT
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),

                // TOP
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y, Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, Size.Y, Size.Z) / 2f, color),

                // BOT
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),
            };
        }
    }
}