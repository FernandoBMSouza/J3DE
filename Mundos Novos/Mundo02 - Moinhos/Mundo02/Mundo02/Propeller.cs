﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    public class Propeller : GameObject
    {
        public Propeller(GraphicsDevice device)
            : base(device)
        {
            Size = new Vector3(2, 4, 0);
            Vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0,0,0), Color.Blue),
                new VertexPositionColor(new Vector3(-1,1,0), Color.Red),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),

                new VertexPositionColor(new Vector3(-1,1,0), Color.Red),
                new VertexPositionColor(new Vector3(-1,4,0), Color.Blue),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),

                new VertexPositionColor(new Vector3(-1,4,0), Color.Blue),
                new VertexPositionColor(new Vector3( 1,4,0), Color.Red),
                new VertexPositionColor(new Vector3( 1,1,0), Color.Green),
            };
        }
    }
}
