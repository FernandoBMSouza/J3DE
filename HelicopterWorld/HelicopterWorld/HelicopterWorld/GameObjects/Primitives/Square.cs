using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HelicopterWorld.GameObjects.Primitives
{
    public class Square : Shape
    {
        public Square(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, new Vector3(size.X, size.Y, 0), colliderVisible)
        {
            vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-size.X, -size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,  size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X,  size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, size.Z) / 2f, color),
            };
        }
    }
}
