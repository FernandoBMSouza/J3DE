using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    public class Cube : GameObject
    {
        public Cube(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(2, 2, 2);
            Vertices = new VertexPositionColor[]
            {
                // RIGHT
                new VertexPositionColor(new Vector3(1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(1,-1, 1), Color.LightBlue),

                new VertexPositionColor(new Vector3(1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(1,-1,-1), Color.LightBlue),
                // LEFT
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),
                // BACK
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Blue),

                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Blue),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                // FRONT
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Blue),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Blue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.Blue),
                // BASE
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.LightBlue),
                // TOP
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.LightBlue),

                new VertexPositionColor(new Vector3(-1, 1, 1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.LightBlue),
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.LightBlue),                
            };
        }
    }
}
