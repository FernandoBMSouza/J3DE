using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldName
{
    abstract class Shape : ITransform
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix world;

        protected VertexPositionColor[] Vertices { get; set; }

        public Shape(GraphicsDevice device)
        {
            this.device = device;
            Vertices = null;

            if (Vertices != null)
            {
                buffer = new VertexBuffer(device,
                                          typeof(VertexPositionColor),
                                          Vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(Vertices);
            }

            effect = new BasicEffect(device);
            SetIdentity();
        }

        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            effect.World = world;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
            }
        }

        public void SetIdentity()
        {
            world = Matrix.Identity;
        }

        public void Translation(Vector3 position)
        {
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
