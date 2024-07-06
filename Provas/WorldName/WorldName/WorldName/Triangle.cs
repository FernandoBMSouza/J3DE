using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldName
{
    class Triangle : Shape
    {
        public Triangle(GraphicsDevice device)
            : base(device)
        { 
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
