using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03.GameObjects.Primitives
{
    class Triangle3D : Primitive
    {
        public Triangle3D(Game1 game, Texture2D texture, bool showColliderLines = false)
            : base(game, texture, showColliderLines)
        {
            Size = Vector3.One;

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(      0, Size.Y, Size.Z) / 2f, new Vector2(.5f,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                // REAR
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(      0, Size.Y,-Size.Z) / 2f, new Vector2(.5f,0)),

                // BOT
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),

                // LEFT
                new VertexPositionTexture(new Vector3(      0, Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(      0, Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(      0, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),

                // RIGHT
                new VertexPositionTexture(new Vector3(      0, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(      0, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(      0, Size.Y,-Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
