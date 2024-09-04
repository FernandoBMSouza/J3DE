using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PresentationWorld
{
    public class LineSphere
    {
        private VertexPositionColor[] vertices;
        private VertexBuffer vBuffer;
        private short[] indexes;
        private IndexBuffer iBuffer;
        private Color color;
        private Game game;
        private int longitudeSegments = 24; // Número de segmentos longitudinais
        private int latitudeSegments = 12;  // Número de segmentos latitudinais

        public LineSphere(Game game, float radius, Color color)
        {
            this.game = game;
            this.color = color;
            CreateVertices(radius);
            CreateIndexes();
            CreateBuffers();
        }

        private void CreateVertices(float radius)
        {
            int numVertices = (longitudeSegments + 1) * (latitudeSegments + 1);
            vertices = new VertexPositionColor[numVertices];

            int index = 0;
            for (int lat = 0; lat <= latitudeSegments; lat++)
            {
                float theta = (float)(lat * Math.PI / latitudeSegments);
                float sinTheta = (float)Math.Sin(theta);
                float cosTheta = (float)Math.Cos(theta);

                for (int lon = 0; lon <= longitudeSegments; lon++)
                {
                    float phi = (float)(lon * 2 * Math.PI / longitudeSegments);
                    float sinPhi = (float)Math.Sin(phi);
                    float cosPhi = (float)Math.Cos(phi);

                    Vector3 position = new Vector3(
                        radius * cosPhi * sinTheta,
                        radius * cosTheta,
                        radius * sinPhi * sinTheta
                    );

                    vertices[index++] = new VertexPositionColor(position, color);
                }
            }
        }

        private void CreateIndexes()
        {
            int numIndices = longitudeSegments * latitudeSegments * 6;
            indexes = new short[numIndices];
            int index = 0;

            for (int lat = 0; lat < latitudeSegments; lat++)
            {
                for (int lon = 0; lon < longitudeSegments; lon++)
                {
                    short topLeft = (short)((lat * (longitudeSegments + 1)) + lon);
                    short topRight = (short)(topLeft + 1);
                    short bottomLeft = (short)((topLeft + (longitudeSegments + 1)));
                    short bottomRight = (short)(bottomLeft + 1);

                    // Upper triangle
                    indexes[index++] = topLeft;
                    indexes[index++] = bottomLeft;
                    indexes[index++] = topRight;

                    // Lower triangle
                    indexes[index++] = topRight;
                    indexes[index++] = bottomLeft;
                    indexes[index++] = bottomRight;
                }
            }
        }

        private void CreateBuffers()
        {
            vBuffer = new VertexBuffer(game.GraphicsDevice,
                                       typeof(VertexPositionColor),
                                       vertices.Length,
                                       BufferUsage.None);
            vBuffer.SetData(vertices);

            iBuffer = new IndexBuffer(game.GraphicsDevice,
                                      IndexElementSize.SixteenBits,
                                      indexes.Length,
                                      BufferUsage.None);
            iBuffer.SetData(indexes);
        }

        public void SetColor(Color color)
        {
            this.color = color;
            for (int i = 0; i < vertices.Length; i++)
                vertices[i].Color = this.color;
        }

        public void Draw(BasicEffect e)
        {
            e.VertexColorEnabled = true;
            game.GraphicsDevice.SetVertexBuffer(vBuffer);
            game.GraphicsDevice.Indices = iBuffer;

            foreach (EffectPass pass in e.CurrentTechnique.Passes)
            {
                pass.Apply();
                game.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(
                    PrimitiveType.LineList,
                    vertices,
                    0,
                    vertices.Length,
                    indexes,
                    0,
                    indexes.Length / 2
                );
            }
            e.VertexColorEnabled = false;
        }
    }
}
