using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    class Blade : GameObject
    {
        public Blade(Game1 game)
            : base(game)
        {
            Size = new Vector3(2, 8, 0);
            Texture = game.Content.Load<Texture2D>(@"Images\wood");
            Vertices = new VertexPositionTexture[]
            {
                // TOP
                new VertexPositionTexture(new Vector3( 0,0,0), new Vector2(.5f,1)),
                new VertexPositionTexture(new Vector3(-1,1,0), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,1,0), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1,1,0), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1,4,0), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,1,0), new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-1,4,0), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,4,0), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,1,0), new Vector2(1,1)),

                // BOTTOM
                new VertexPositionTexture(new Vector3( 0, 0,0), new Vector2(.5f,1)),
                new VertexPositionTexture(new Vector3( 1,-1,0), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-1,0), new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-1,-1,0), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1,-1,0), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1,-4,0), new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-1,-4,0), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-1,0), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1,-4,0), new Vector2(1,0)),
            };
        }
    }
}
