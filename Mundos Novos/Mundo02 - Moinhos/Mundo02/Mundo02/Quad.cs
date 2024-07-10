﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    public class Quad : GameObject
    {
        public Quad(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
            : base(game, device, lineBoxVisible)
        {
            Size = new Vector3(2, 0, 2);
            LBox = new LineBox(game, Size, Color.Green);
            UpdateBoundingBox();
            
            Vertices = new VertexPositionColor[]
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
