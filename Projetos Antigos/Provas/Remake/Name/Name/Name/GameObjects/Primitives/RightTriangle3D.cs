using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Name.GameObjects.Primitives
{
    class RightTriangle3D : Primitive
    {
        public RightTriangle3D(Game1 game, Color color, Color colorBorder, bool showColliderLines = false)
            : base(game, color, showColliderLines)
        {
            Size = Vector3.One;
            vertices = new VertexPositionColor[] 
            { 
                // FRONT
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, color),

                // REAR
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, color),

                // BOT
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),

                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),

                // LEFT
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, colorBorder),

                // RIGHT
                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, colorBorder),

                new VertexPositionColor(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, colorBorder),
                new VertexPositionColor(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, colorBorder),
            };
        }
    }
}
