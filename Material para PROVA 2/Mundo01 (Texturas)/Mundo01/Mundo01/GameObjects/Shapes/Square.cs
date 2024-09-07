using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Shapes
{
    public class Square : Shape
    {
        public Square(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, colliderVisible)
        {
            Vector3 size = new Vector3(1,1,0);
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-size.X, -size.Y, size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-size.X,  size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, -size.Y, size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-size.X,  size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,  size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X, -size.Y, size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
