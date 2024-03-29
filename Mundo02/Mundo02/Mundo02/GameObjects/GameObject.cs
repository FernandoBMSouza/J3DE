using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    abstract class GameObject
    {
        private GraphicsDevice device;
        private VertexBuffer buffer;
        private BasicEffect effect;

        protected Matrix world;
        protected VertexPositionColor[] vertices;

        public GameObject(GraphicsDevice device)
        {
            this.device = device;
            world = Matrix.Identity;

            vertices = GenerateVertices();

            if (vertices.Length > 0)
            {
                buffer = new VertexBuffer(device, typeof(VertexPositionColor), vertices.Length, BufferUsage.None);
                buffer.SetData<VertexPositionColor>(vertices);
            }


            effect = new BasicEffect(device);
        }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(Camera camera) { Draw(camera, new Matrix[] { world }); }

        public virtual void Draw(Camera camera, Matrix[] matrices)
        {
            device.SetVertexBuffer(buffer);

            Matrix result = Matrix.Identity;

            foreach (Matrix m in matrices)
                result *= m;

            effect.World = result;
            effect.View = camera.GetView();
            effect.Projection = camera.GetProjection();

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                if (vertices.Length > 0)
                    device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, vertices.Length / 3);
            }
        }

        protected virtual VertexPositionColor[] GenerateVertices() { return null; }
    }
}
