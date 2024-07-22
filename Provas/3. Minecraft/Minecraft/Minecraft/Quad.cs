﻿#define USE_TEXTURE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Quad : GameObject
    {
        public Quad(Game game, GraphicsDevice device)
            : base(game, device)
        {
            Size = new Vector3(2, 0, 2);
#if USE_TEXTURE
            Texture = game.Content.Load<Texture2D>(@"Images\grass");
            Vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-1, 0, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 0,-1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 0,-1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1, 0, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 0,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1, 0, 1), new Vector2(1,1)),
            };
#else
            Vertices = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1, 0, 1), Color.Green),
                new VertexPositionColor(new Vector3(-1, 0,-1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0,-1), Color.Green),

                new VertexPositionColor(new Vector3(-1, 0, 1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0,-1), Color.Green),
                new VertexPositionColor(new Vector3( 1, 0, 1), Color.Yellow), 
            };
#endif
        }
    }
}
