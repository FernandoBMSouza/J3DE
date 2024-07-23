#define USE_TEXTURE

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Head : Cube
    {
        public Head(Game game, GraphicsDevice device, Texture2D texture)
            : base(game, device, texture)
        {
            Size = new Vector3(2, 2, 2);
#if USE_TEXTURE
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
