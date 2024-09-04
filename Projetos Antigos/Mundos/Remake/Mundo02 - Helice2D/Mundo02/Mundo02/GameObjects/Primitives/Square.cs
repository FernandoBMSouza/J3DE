using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo02.GameObjects.Primitives
{
    class Square : Primitive
    {
        public Square(Game1 game, Color color, bool showColliderLines = false)
            : base(game, color, showColliderLines)
        {
            Size = new Vector3(1, 1, 0);

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-Size.X, -Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-Size.X,  Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, -Size.Y, Size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-Size.X,  Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X,  Size.Y, Size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( Size.X, -Size.Y, Size.Z) / 2f, color),
            };
        }
    }
}
