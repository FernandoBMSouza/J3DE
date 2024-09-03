using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo04.GameObjects.Primitives
{
    class Quad : Primitive
    {
        public Quad(Game1 game, Texture2D texture, bool showColliderLines = false)
            : base(game, texture, showColliderLines)
        {
            Size = new Vector3(1, 0, 1);
            vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-Size.X,  Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-Size.X,  Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,  Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-Size.X,  Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,  Size.Y,-Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,  Size.Y, Size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
