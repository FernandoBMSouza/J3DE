using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.GameObjects.Primitives
{
    public class Cube : Shape
    {
        public Cube(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            Vector3 size = Vector3.One;

            vertices = new VertexPositionColor[]
            {
                // FRONT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                // REAR
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z) / 2f, color),

                // RIGHT
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),

                // LEFT
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),

                // TOP
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, size.Z) / 2f, color),

                // BOT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
            };
        }
    }
}
