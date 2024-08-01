using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects
{
    public class Quad : GameObject
    {
        public Quad(Game1 game, Texture2D texture = null)
            : base(game)
        {
            Size = new Vector3(2, 0, 2);
            Texture = texture;

            if (Texture == null)
            {
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
            else
            {
                TextureVertices = new VertexPositionTexture[]
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
}
