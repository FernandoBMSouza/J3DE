using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    class Plane : GameObject
    {
        public Plane(GraphicsDevice device)
            : base(device)
        {
            world *= Matrix.CreateScale(10);
        }

        protected override VertexPositionColor[] GenerateVertices()
        {
            return new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1, 0, 1), Color.Green),
                new VertexPositionColor(new Vector3(-1, 0,-1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0,-1), Color.Green),

                new VertexPositionColor(new Vector3(-1, 0, 1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0,-1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0, 1), Color.Yellow),
            };
        }
    }
}
