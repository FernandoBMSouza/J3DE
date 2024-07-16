using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HelicopterWorld
{
    public abstract class GameObject
    {
        private GraphicsDevice device;
        private VertexBuffer buffer;
        private BasicEffect effect;

        protected VertexPositionColor[] Vertices { get; set; }

        private Vector3 size;
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        public Vector3 Size
        {
            get { return size; }
            protected set 
            {
                size = value;
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }
        public Vector3 Rotation
        {
            get 
            {
                return new Vector3(MathHelper.ToDegrees(rotation.X),
                                   MathHelper.ToDegrees(rotation.Y),
                                   MathHelper.ToDegrees(rotation.Z));  
            }
            set
            {
                rotation = new Vector3(MathHelper.ToRadians(value.X),
                                       MathHelper.ToRadians(value.Y),
                                       MathHelper.ToRadians(value.Z));                                   
            }
        }
        public Vector3 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                Size *= scale;
            }
        }

        public GameObject(GraphicsDevice device)
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

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            Size = Vector3.One;
        }

        public void Draw(Camera camera)
        {
            Draw(camera, Matrix.Identity);
        }
        
        public void Draw(Camera camera, Matrix parentWorld)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(Rotation.Y), 
                                                                 MathHelper.ToRadians(Rotation.X),
                                                                 MathHelper.ToRadians(Rotation.Z))
                                 * Matrix.CreateTranslation(Position);

            effect.World = localMatrix * parentWorld;
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
            effect.VertexColorEnabled = false;
        }
    }
}
