#define USE_TEXTURE

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    class Cube : Shape
    {
        public Cube(Game1 game, GraphicsDevice device)
            : base(device)
        {
#if USE_TEXTURE
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
#else
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
#endif
        }
    }
}
