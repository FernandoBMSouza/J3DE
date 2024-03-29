using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Cube : GameObject
    {
        public Cube(Game1 game, GraphicsDevice device, Vector3 position)
            : base(device, game.Content.Load<Texture2D>(@"Images\bricks"))
        {
            world *= Matrix.CreateTranslation(position);
        }

        protected override VertexPositionTexture[] GenerateVertices()
        {
            return new VertexPositionTexture[] 
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
