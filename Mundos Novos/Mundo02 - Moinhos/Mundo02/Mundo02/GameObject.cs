using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo02
{
    public abstract class GameObject : ITransform
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix worldScale;
        Matrix worldRotation;
        Matrix worldTranslation;
        Matrix auxWorld;

        protected VertexPositionColor[] Vertices { get; set; }

        public Vector3 Position { get; protected set; }
        public Vector3 Size { get; protected set; }

        private Vector3 angle;
        public Vector3 Angle
        {
            get { return angle; }
            protected set
            {
                angle = new Vector3(
                (value.X % 360 + 360) % 360,
                (value.Y % 360 + 360) % 360,
                (value.Z % 360 + 360) % 360);
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
            SetIdentity();
        }

        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            effect.World = (worldScale * worldRotation * worldTranslation) * auxWorld;
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
            Position = Vector3.Zero;
            Angle = Vector3.Zero;
            Size = Vector3.One;

            worldScale = Matrix.Identity;
            worldRotation = Matrix.Identity;
            worldTranslation = Matrix.Identity;
            auxWorld = Matrix.Identity;
        }

        public void Translation(Vector3 position, bool aux = false)
        {
            Position = position;
            if (aux) auxWorld *= Matrix.CreateTranslation(position);
            else worldTranslation *= Matrix.CreateTranslation(position);
        }

        public void Scale(Vector3 scale, bool aux = false)
        {
            Size *= scale;
            if (aux) auxWorld *= Matrix.CreateScale(scale);
            else worldScale *= Matrix.CreateScale(scale);
        }

        public void Rotation(char axis, float angle, bool aux = false)
        {
            float radians = MathHelper.ToRadians(angle);
            switch (axis)
            {
                case 'X':
                case 'x':
                    Angle += new Vector3(angle, 0, 0);
                    if (aux) auxWorld *= Matrix.CreateRotationX(radians);
                    else worldRotation *= Matrix.CreateRotationX(radians);
                    break;
                case 'Y':
                case 'y':
                    Angle += new Vector3(0, angle, 0);
                    if (aux) auxWorld *= Matrix.CreateRotationY(radians);
                    else worldRotation *= Matrix.CreateRotationY(radians);
                    break;
                case 'Z':
                case 'z':
                    Angle += new Vector3(0, 0, angle);
                    if (aux) auxWorld *= Matrix.CreateRotationZ(radians);
                    else worldRotation *= Matrix.CreateRotationZ(radians);
                    break;
                default:
                    break;
            }
        }
    }
}
