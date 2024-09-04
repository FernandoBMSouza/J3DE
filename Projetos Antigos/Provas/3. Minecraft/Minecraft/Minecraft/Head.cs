﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Head : Cube
    {
        public Head(Game game, Texture2D texture)
            : base(game, texture)
        {
            Size = new Vector3(2, 2, 2);
            Texture = texture;
            Vertices = new VertexPositionTexture[] 
            {
                //DIREITA
                new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(8,8) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(0,8) / 64f),
                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(8,16) / 64f),

                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(8,16) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(0,8) / 64f),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(0,16) / 64f),

                //ESQUERDA
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(16,8) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(16,16) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(24,8) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(16,16) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(24,16) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(24,8) / 64f),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(24,16) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(32,16) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(24,8) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(24,8) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(32,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(32,8) / 64f),

                // FRENTE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8, 16) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(8, 8) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(16, 8) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8, 16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(16, 8) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(16, 16) / 64f),

                // BASE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(16,8) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(24,0) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(16,0) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(16,8) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(24,8) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(24,0) / 64f),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(8,8) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(8,0) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(16,0) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(8,8) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(16,0) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(16,8) / 64f),
            };
        }
    }
}