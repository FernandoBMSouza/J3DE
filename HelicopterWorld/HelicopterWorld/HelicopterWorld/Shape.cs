using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HelicopterWorld
{
    class Shape : ITransform
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix world;

        protected VertexPositionColor[] Vertex { get; set; }
        public Vector3 Position { get; private set; }

        public Shape(GraphicsDevice device)
        {
            this.device = device;
            Position = Vector3.Zero;
            Vertex = null;

            if (Vertex != null)
            {
                buffer = new VertexBuffer(device,
                                          typeof(VertexPositionColor),
                                          Vertex.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(Vertex);
            }

            effect = new BasicEffect(device);
            SetIdentity();

        }

        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            if (Vertex != null)
                device.SetVertexBuffer(buffer);

            effect.World = world;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertex != null)
                    device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                   Vertex,
                                                                   0,
                                                                   Vertex.Length / 3);
            }
        }

        public void SetIdentity()
        {
            world = Matrix.Identity;
        }

        public void Translation(Vector3 position)
        {
            Position = position;
            world *= Matrix.CreateTranslation(position);
        }

        public void Scale(Vector3 scale)
        {
            world *= Matrix.CreateScale(scale);
        }

        public void RotationX(float angle)
        {
            world *= Matrix.CreateRotationX(MathHelper.ToRadians(angle));
        }

        public void RotationY(float angle)
        {
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
        }

        public void RotationZ(float angle)
        {
            world *= Matrix.CreateRotationZ(MathHelper.ToRadians(angle));
        }
    }
}
