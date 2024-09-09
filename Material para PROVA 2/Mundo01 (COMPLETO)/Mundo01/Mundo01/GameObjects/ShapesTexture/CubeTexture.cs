using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.ShapesTexture
{
    public class CubeTexture : ShapeTexture
    {
        public CubeTexture(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(1,1)),

                // REAR
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(0,0)),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(1,0)),

                // RIGHT
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(1,1)),

                // LEFT
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(1,1)),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(0,0)),

                // TOP
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(1,1)),

                // BOT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(0,1)),

                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
