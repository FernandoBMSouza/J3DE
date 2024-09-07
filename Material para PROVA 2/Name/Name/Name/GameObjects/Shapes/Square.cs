using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Name.GameObjects.Shapes
{
    public class Square : Shape
    {
        public Square(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            Vector3 size = new Vector3(1,1,0);
            SetSize(size);

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
