using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    public class Arm : Cube
    {
        public Arm(Game game, GraphicsDevice device, Texture2D texture)
            : base(game, device, texture)
        {
            Size = new Vector3(2, 2, 2);
            Texture = texture;
            Vertices = new VertexPositionTexture[] 
            {
                //DIREITA
                new VertexPositionTexture(new Vector3(1, 1, 1), new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(48,32) / 64f),

                new VertexPositionTexture(new Vector3(1,-1, 1), new Vector2(48,32) / 64f),
                new VertexPositionTexture(new Vector3(1, 1,-1), new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3(1,-1,-1), new Vector2(52,32) / 64f),

                //ESQUERDA
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(40,20) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(44,20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(44,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(44,20) / 64f),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(52,32) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(56,32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(52,20) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(56,32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(56,20) / 64f),

                // FRENTE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(44, 32) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(44, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(48, 20) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(44, 32) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(48, 20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(48, 32) / 64f),

                // BASE
                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(52,16) / 64f),
                new VertexPositionTexture(new Vector3(-1,-1,-1), new Vector2(48,16) / 64f),

                new VertexPositionTexture(new Vector3(-1,-1, 1), new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1, 1), new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3( 1,-1,-1), new Vector2(52,16) / 64f),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(44,20) / 64f),
                new VertexPositionTexture(new Vector3(-1, 1,-1), new Vector2(44,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(48,16) / 64f),

                new VertexPositionTexture(new Vector3(-1, 1, 1), new Vector2(44,20) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1,-1), new Vector2(48,16) / 64f),
                new VertexPositionTexture(new Vector3( 1, 1, 1), new Vector2(48,20) / 64f),
            };
        }
    }
}
