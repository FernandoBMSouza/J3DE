using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo03.GameObjects.Primitives
{
    class Triangle : Primitive
    {
        public Triangle(Game1 game, Texture2D texture, bool showColliderLines = false)
            : base(game, texture, showColliderLines)
        {
            Size = new Vector3(1, 1, 0);

            vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-Size.X, -Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(      0,  Size.Y, Size.Z) / 2f, new Vector2(.5f,0)),
                new VertexPositionTexture(new Vector3( Size.X, -Size.Y, Size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
