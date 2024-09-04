using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    public class Quad : GameObject
    {
        public Quad(Game game)
            : base(game)
        {
            Size = new Vector3(2, 0, 2);
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
        }
    }
}
