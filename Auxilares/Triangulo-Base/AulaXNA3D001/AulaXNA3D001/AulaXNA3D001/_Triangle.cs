using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AulaXNA3D001
{
    public class _Triangle
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;

        public _Triangle(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3( 0, 1,0),Color.Red),   //v0
                new VertexPositionColor(new Vector3( 1,-1,0),Color.Green), //v1
                new VertexPositionColor(new Vector3(-1,-1,0),Color.Blue),  //v2
            };

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionColor),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);

            this.effect = new BasicEffect(this.device);
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                    this.verts, 0, 1);
            }
        }
    }
}
