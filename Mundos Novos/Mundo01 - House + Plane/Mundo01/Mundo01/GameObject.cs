using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    public abstract class GameObject : ICollider
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix worldScale;
        Matrix worldRotation;
        Matrix worldTranslation;

        public LineBox LBox { get; private set; }
        bool lineBoxVisible;

        protected VertexPositionColor[] Vertices { get; set; }
        public BoundingBox BBox { get; private set; }
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


        public GameObject(Game game, GraphicsDevice device, bool lineBoxVisible = true)
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

            this.lineBoxVisible = lineBoxVisible;
            this.LBox = new LineBox(game, Position, Size, Color.Green);

            UpdateBoundingBox();
        }

        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            effect.World = worldScale * worldRotation * worldTranslation;
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

            if (lineBoxVisible) LBox.Draw(effect);
        }

        public void UpdateBoundingBox()
        {
            BBox = new BoundingBox(Position - (Size / 2f),
                                   Position + (Size / 2f));

        }

        public bool IsColliding(BoundingBox other)
        {
            return BBox.Intersects(other);
        }

        public void SetIdentity()
        {
            Position = Vector3.Zero;
            Angle = Vector3.Zero;
            Size = Vector3.One;

            worldScale = Matrix.Identity;
            worldRotation = Matrix.Identity;
            worldTranslation = Matrix.Identity;

            UpdateBoundingBox();
        }

        public void Translation(Vector3 position)
        {
            Position = position;
            worldTranslation *= Matrix.CreateTranslation(position);
            LBox.SetPosition(Position);
            UpdateBoundingBox();
        }

        public void Scale(Vector3 scale)
        {
            Size *= scale;
            worldScale *= Matrix.CreateScale(scale);
            LBox.SetScale(Size);
            UpdateBoundingBox();
        }

        public void Rotation(char axis, float angle)
        {
            float radians = MathHelper.ToRadians(angle);
            switch (axis)
            {
                case 'X':
                case 'x':
                    Angle += new Vector3(angle, 0, 0);
                    worldRotation *= Matrix.CreateRotationX(radians);
                    break;
                case 'Y':
                case 'y':
                    Angle += new Vector3(0, angle, 0);
                    worldRotation *= Matrix.CreateRotationY(radians);
                    break;
                case 'Z':
                case 'z':
                    Angle += new Vector3(0, 0, angle);
                    worldRotation *= Matrix.CreateRotationZ(radians);
                    break;
                default:
                    break;
            }
        }
    }
}