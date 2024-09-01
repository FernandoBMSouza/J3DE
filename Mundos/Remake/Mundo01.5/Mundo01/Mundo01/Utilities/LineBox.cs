using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mundo01.Utilities;

namespace Mundo01.GameObjects.Primitives
{
    class LineBox
    {
        private Game1 game;
        private VertexBuffer vertexBuffer;
        private VertexPositionColor[] vertices;
        private Color color;
        private Matrix worldMatrix;

        public LineBox(Game1 game, Vector3 position, Vector3 scale, Vector3 size, Color color)
        {
            this.game = game;
            this.color = color;
            this.vertices = CreateVertices(position, size, color);
            UpdateVertexBuffer();
            this.worldMatrix = Matrix.CreateScale(scale) * Matrix.CreateTranslation(position);
        }

        private VertexPositionColor[] CreateVertices(Vector3 position, Vector3 size, Color color)
        {
            return new VertexPositionColor[]
            {
                // Front face
                new VertexPositionColor(new Vector3(-size.X, size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, size.Y, -size.Z) / 2f, color),

                // Back face
                new VertexPositionColor(new Vector3(-size.X, -size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, -size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, -size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, -size.Y, -size.Z) / 2f, color),

                // Vertical lines
                new VertexPositionColor(new Vector3(-size.X,  size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, -size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y, -size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X,  size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3( size.X, -size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X,  size.Y,  size.Z) / 2f, color),
                new VertexPositionColor(new Vector3(-size.X, -size.Y,  size.Z) / 2f, color),
            };
        }

        private void UpdateVertexBuffer()
        {
            vertexBuffer = new VertexBuffer(game.GraphicsDevice,
                                            typeof(VertexPositionColor),
                                            vertices.Length,
                                            BufferUsage.None);
            vertexBuffer.SetData(vertices);
        }

        public void SetColor(Color newColor)
        {
            this.color = newColor;

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].Color = newColor;
            }

            UpdateVertexBuffer();
        }

        public void Draw(BasicEffect effect, Camera camera)
        {
            if (vertices != null)
            {
                game.GraphicsDevice.SetVertexBuffer(vertexBuffer);

                effect.World = worldMatrix;
                effect.View = camera.View;
                effect.Projection = camera.Projection;
                effect.VertexColorEnabled = true;

                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                        PrimitiveType.LineList,
                        vertices,
                        0,
                        vertices.Length / 2);
                }

                effect.VertexColorEnabled = false;
            }
        }
    }
}
