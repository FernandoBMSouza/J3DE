using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Primitives
{
    class Square : Primitive
    {
        public Square(Game1 game, Color color)
            : base(game, color)
        {
            Vector3 size = new Vector3(1, 1, 0);
            size /= 2;

            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-size.X, -size.Y, size.Z), color),
                new VertexPositionColor(new Vector3(-size.X,  size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z), color),

                new VertexPositionColor(new Vector3(-size.X,  size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X,  size.Y, size.Z), color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z), color),
            };
        }
    }
}
