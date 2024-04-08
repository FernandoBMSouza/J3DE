#define USE_TEXTURE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    abstract class Shape : ITransform
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix world;

#if USE_TEXTURE
        protected Texture2D Texture { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }
#else
        protected VertexPositionColor[] Vertices { get; set; }
#endif

        public Shape(GraphicsDevice device)
        {
            this.device = device;

#if USE_TEXTURE
            Texture = null;
            if (Vertices != null)
            {
                buffer = new VertexBuffer(device,
                                          typeof(VertexPositionTexture),
                                          Vertices.Length,
                                          BufferUsage.None);
                buffer.SetData<VertexPositionTexture>(Vertices);
            }
#else
            Vertices = null;
            if (Vertices != null)
            {
                buffer = new VertexBuffer(device, 
                                          typeof(VertexPositionColor), 
                                          Vertices.Length, 
                                          BufferUsage.None);
                buffer.SetData<VertexPositionColor>(Vertices);
            }
#endif



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

#if USE_TEXTURE
            effect.TextureEnabled = true;
            effect.Texture = Texture;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
            }
#else
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
#endif
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
