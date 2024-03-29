using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Building : GameObject
    {
        public Building(Game1 game, GraphicsDevice device, Vector3 position, float angle)
            : base(device, game.Content.Load<Texture2D>(@"Images\rocks"))
        {
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            world *= Matrix.CreateTranslation(position);
        }

        protected override VertexPositionTexture[] GenerateVertices()
        {
            return new VertexPositionTexture[]
            {
                //Dimensões do Prédio:
                //Largura: 2
                //Alutra: 4
                //Profundidade: 6

                //BASE
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(1,1)),

                //TOPO
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(1,1)),

                //LATERAL ESQUERDA 01
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0,0)),

                //LATERAL DIREITA 01
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(0,1)),

                //LATERAL ESQUERDA 02
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(0.5f,0)),

                 //LATERAL DIREITA 02
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0.5f,0)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(1,1)),

                //FRENTE
                new VertexPositionTexture(new Vector3(-1,-2, 3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-1, 2, 3), new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( 1, 2, 3), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( 1,-2, 3), new Vector2(1,1)),

                //TRASEIRA
                new VertexPositionTexture(new Vector3(-1, 2, 1), new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-1,-2,-3), new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( 1,-2,-3), new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( 1, 2, 1), new Vector2(0,0)),
            };
        }
    }
}
