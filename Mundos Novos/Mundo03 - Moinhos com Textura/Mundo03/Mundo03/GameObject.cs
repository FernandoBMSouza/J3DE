﻿#define USE_TEXTURE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    public abstract class GameObject : ICollider
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;

        Matrix worldScale;
        Matrix worldRotation;
        Matrix worldTranslation;
        Matrix auxWorld;

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

        public BoundingBox BBox { get; private set; }
        public LineBox LBox { get; protected set; }
        bool lineBoxVisible;

#if USE_TEXTURE
        protected Texture2D Texture { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }
#else
        protected VertexPositionColor[] Vertices { get; set; }
#endif

        public GameObject(Game1 game, GraphicsDevice device, bool lineBoxVisible = false)
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
            this.lineBoxVisible = lineBoxVisible;
            UpdateBoundingBox();
        }


        public void Update(GameTime gameTime) { }

        public void Draw(Camera camera)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            effect.World = (worldScale * worldRotation * worldTranslation) * auxWorld;
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
            effect.TextureEnabled = false;
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
            if (lineBoxVisible) LBox.Draw(effect, effect.World);
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

        public void SetColliderColor(Color color)
        {
            LBox.SetColor(color);
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

            UpdateBoundingBox();
        }

        public void Translation(Vector3 position, bool aux = false)
        {
            Position = position;
            if (aux) auxWorld *= Matrix.CreateTranslation(position);
            else worldTranslation *= Matrix.CreateTranslation(position);
            UpdateBoundingBox();
        }

        public void Scale(Vector3 scale, bool aux = false)
        {
            Size *= scale;
            if (aux) auxWorld *= Matrix.CreateScale(scale);
            else worldScale *= Matrix.CreateScale(scale);
            UpdateBoundingBox();
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
            UpdateBoundingBox();
        }
    }
}