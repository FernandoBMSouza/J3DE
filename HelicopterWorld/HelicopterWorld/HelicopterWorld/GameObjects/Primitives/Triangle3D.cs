﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HelicopterWorld.GameObjects.Primitives
{
    public class Triangle3D : Shape
    {
        public Triangle3D(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, size, colliderVisible)
        {
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