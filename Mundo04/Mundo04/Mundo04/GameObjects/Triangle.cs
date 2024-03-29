using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Triangle
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;
        BasicEffect effect;

        public Triangle(GraphicsDevice device)
        {
            this.device = device;
            world = Matrix.Identity;

            verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(0,1,0), Color.Red),
                new VertexPositionColor(new Vector3(1,-1,0), Color.Green),
                new VertexPositionColor(new Vector3(-1,-1,0), Color.Blue),
            };

            vertexBuffer = new VertexBuffer(device, typeof(VertexPositionColor), verts.Length, BufferUsage.None);
            vertexBuffer.SetData<VertexPositionColor>(verts);

            effect = new BasicEffect(device);
        }

        public void Draw(Camera camera)
        {
            device.SetVertexBuffer(vertexBuffer);

            effect.World = world;
            effect.View = camera.GetView();
            effect.Projection = camera.GetProjection();

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, verts, 0, verts.Length / 3);
            }
        }
    }
}
