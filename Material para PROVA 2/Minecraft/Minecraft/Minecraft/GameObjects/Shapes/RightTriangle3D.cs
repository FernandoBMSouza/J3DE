using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Shapes
{
    public class RightTriangle3D : Shape
    {
        public RightTriangle3D(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionColor[] 
            { 
                // FRONT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                // REAR
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),

                // BOT
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),

                // LEFT
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),

                // RIGHT
                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y, size.Z) / 2f, color),

                new VertexPositionColor(new Vector3(-size.X, size.Y, size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,-size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,-size.Y,-size.Z) / 2f, color),
            };
        }
    }
}
