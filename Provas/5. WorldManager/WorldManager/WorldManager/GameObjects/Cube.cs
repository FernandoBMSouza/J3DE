using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldManager.GameObjects
{
    public class Cube : GameObject
    {
        public Cube(Game1 game, Texture2D texture = null)
            : base(game)
        {
            Size = new Vector3(2, 2, 2);
            Texture = texture;

            if (Texture == null)
            {
                Vertices = new VertexPositionColor[]
                {
                    // RIGHT
                    new VertexPositionColor(new Vector3(1, 1, 1), Color.Green),
                    new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),

                    new VertexPositionColor(new Vector3(1,-1, 1), Color.Yellow),
                    new VertexPositionColor(new Vector3(1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3(1,-1,-1), Color.Red),

                    // LEFT
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                
                    // BACK
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),

                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                
                    // FRONT
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
                    new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                
                    // BASE
                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                    new VertexPositionColor(new Vector3(-1,-1,-1), Color.Green),

                    new VertexPositionColor(new Vector3(-1,-1, 1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1,-1, 1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1,-1,-1), Color.Red),
                
                    // TOP
                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3(-1, 1,-1), Color.Yellow),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),

                    new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red),
                    new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue),
                    new VertexPositionColor(new Vector3( 1, 1, 1), Color.Green),
                };
            }
            else
            {
                TextureVertices = new VertexPositionTexture[] 
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
}
