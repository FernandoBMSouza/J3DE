using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace HelicopterWorld
{
    class Quad : Shape
    {
        public Quad(GraphicsDevice device) 
            : base(device)
        {
            Vertex = new VertexPositionColor[]
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
