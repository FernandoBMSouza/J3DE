﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    public abstract class GameObject
    {
        GraphicsDevice device;
        VertexBuffer buffer;
        BasicEffect effect;
        Matrix world;

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
            Position = Vector3.Zero;
            Angle = Vector3.Zero;
            Size = Vector3.One;
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
            Position = position;
            world *= Matrix.CreateTranslation(position);
        }

        public void Scale(Vector3 scale)
        {
            Size *= scale;
            world *= Matrix.CreateScale(scale);
        }

        public void Rotation(char axis, float angle)
        {
            float radians = MathHelper.ToRadians(angle);
            switch (axis)
            {
                case 'X':
                case 'x':
                    Angle += new Vector3(angle, 0, 0);
                    world *= Matrix.CreateRotationX(radians);
                    break;
                case 'Y':
                case 'y':
                    Angle += new Vector3(0, angle, 0);
                    world *= Matrix.CreateRotationY(radians);
                    break;
                case 'Z':
                case 'z':
                    Angle += new Vector3(0, 0, angle);
                    world *= Matrix.CreateRotationZ(radians);
                    break;
                default:
                    break;
            }
        }
    }
}