using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    class Plane : GameObject
    {
        public Plane(Game1 game, GraphicsDevice device)
            : base(device, game.Content.Load<Texture2D>(@"Images\grass"))
        {
            world *= Matrix.CreateScale(15);
        }

        protected override VertexPositionTexture[] GenerateVertices()
        {
            return new VertexPositionTexture[]
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
