using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    public class Quad : GameObject
    {
        public Quad(Game game, GraphicsDevice device)
            : base(game, device, true)
        {
            Size = new Vector3(1, 0, 1);
            Vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-.5f, 0, .5f), Color.Green),
                new VertexPositionColor(new Vector3(-.5f, 0,-.5f), Color.Green),
                new VertexPositionColor(new Vector3( .5f, 0,-.5f), Color.Green),

                new VertexPositionColor(new Vector3(-.5f, 0, .5f), Color.Green),
                new VertexPositionColor(new Vector3( .5f, 0,-.5f), Color.Green),
                new VertexPositionColor(new Vector3( .5f, 0, .5f), Color.Yellow), 
            };
            UpdateLineBox();
            UpdateBoundingBox();
        }
    }
}
