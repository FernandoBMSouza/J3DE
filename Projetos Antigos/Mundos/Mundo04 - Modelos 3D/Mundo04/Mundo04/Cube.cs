﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    public class Cube : GameObject
    {
        public Cube(Game game)
            : base(game)
        {
            Size = new Vector3(2, 2, 2);
            Texture = game.Content.Load<Texture2D>(@"Images\bricks");
            Vertices = new VertexPositionTexture[] 
            {
                //DIREITA
                new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(1,1)),

                //ESQUERDA
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(0,0)),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(0,0)),

                //FRENTE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(1,1)),

                // BASE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(1,1)),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(1,1)),
            };
        }
    }
}