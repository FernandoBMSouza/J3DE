using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    public class Triangle : GameObject
    {
        public Triangle(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(2, 2, 2);
            Vertices = new VertexPositionColor[]
            {
                //FRENTE
                new VertexPositionColor(new Vector3(-1,-1,1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1,1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1,1), Color.Blue),

                //TRÁS
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Blue),

                //BASE
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.LightBlue),

                //TOPO
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.LightBlue),

                //ESQUERDA
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),                
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
            };
        }
    }
}
