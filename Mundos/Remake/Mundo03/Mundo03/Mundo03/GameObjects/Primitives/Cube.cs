using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo03.GameObjects.Primitives
{
    class Cube : Primitive
    {
        public Cube(Game1 game, Texture2D texture, bool showColliderLines = false)
            : base(game, texture, showColliderLines)
        {
            Size = Vector3.One;
            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                // REAR
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, new Vector2(1,0)),

                // RIGHT
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3( Size.X, Size.Y, Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,1)),

                // LEFT
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),

                // TOP
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-Size.X, Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y,-Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X, Size.Y, Size.Z) / 2f, new Vector2(1,1)),

                // BOT
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y, Size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,0)),

                new VertexPositionTexture(new Vector3(-Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y, Size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( Size.X,-Size.Y,-Size.Z) / 2f, new Vector2(0,0)),
            };
        }
    }
}
