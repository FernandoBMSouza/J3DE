#define USE_TEXTURE

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Leg : Cube
    {
        public Leg(Game game, GraphicsDevice device, Texture2D texture)
            : base(game, device, texture)
        {
            Size = new Vector3(2, 2, 2);
#if USE_TEXTURE
            Texture = texture;
            Vertices = new VertexPositionTexture[] 
            {
                //DIREITA
                new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(0,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(4,32) / 64f),

                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(4,32) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(0,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(0,32) / 64f),

                //ESQUERDA
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(8,20) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(12,20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8,32) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(12,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(12,20) / 64f),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(12,32) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(12,20) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(12,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(16,20) / 64f),

                // FRENTE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(4, 32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(4, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(8, 20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(4, 32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(8, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(8, 32) / 64f),

                // BASE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(12,16) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(8,16) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(8,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(12,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(12,16) / 64f),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(4,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(8,16) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(8,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(8,20) / 64f),
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
