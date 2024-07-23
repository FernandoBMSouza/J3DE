#define USE_TEXTURE

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Body : Cube
    {
        public Body(Game game, GraphicsDevice device, Texture2D texture)
            : base(game, device, texture)
        {
            Size = new Vector3(2, 2, 2);
#if USE_TEXTURE
            Texture = texture;
            Vertices = new VertexPositionTexture[] 
            {
                //DIREITA
                new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(28,20) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(32,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(28,32) / 64f),

                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(28,32) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(32,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(32,32) / 64f),

                //ESQUERDA
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(20,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(16,20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(20,32) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(16,20) / 64f),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(32,32) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(32,20) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(32,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(40,20) / 64f),

                // FRENTE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(20, 32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(20, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(28, 20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(20, 32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(28, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(28, 32) / 64f),

                // BASE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(28,16) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(36,20) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(28,20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(28,16) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(36,16) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(36,20) / 64f),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(20,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(28,16) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(28,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(28,20) / 64f),
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
