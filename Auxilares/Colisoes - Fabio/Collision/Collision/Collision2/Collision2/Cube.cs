using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Collision2
{
    class Cube
    {
        #region variables
        GraphicsDevice graphicsDevice;

        VertexPositionColor[] verts;
        VertexBuffer vertexBuffer;

        short[] index;
        IndexBuffer indexBuffer;

        protected Matrix world;
        protected Vector3 position;

        protected float angle;

        BoundingBox boundingBox;        

        bool wireframe = true;
        #endregion

        public Cube(ref GraphicsDeviceManager graphics, Vector3 position)
        {
            this.graphicsDevice = graphics.GraphicsDevice;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-1, 1, 1), Color.Red), // 0
                new VertexPositionColor(new Vector3( 1, 1, 1), Color.Blue), // 1
                new VertexPositionColor(new Vector3( 1,-1, 1), Color.Green), // 2
                new VertexPositionColor(new Vector3(-1,-1, 1), Color.Yellow), // 3
                new VertexPositionColor(new Vector3(-1, 1,-1), Color.Red), // 4
                new VertexPositionColor(new Vector3( 1, 1,-1), Color.Blue), // 5
                new VertexPositionColor(new Vector3( 1,-1,-1), Color.Green), // 6
                new VertexPositionColor(new Vector3(-1,-1,-1), Color.Yellow), // 7
            };

            this.vertexBuffer = new VertexBuffer(this.graphicsDevice,
                                                 typeof(VertexPositionColor),
                                                 this.verts.Length,
                                                 BufferUsage.None);
            this.vertexBuffer.SetData<VertexPositionColor>(this.verts);

            this.index = new short[]
            {
                0, 1, 2, // front
                0, 2, 3,
                1, 5, 6, // rigth
                1, 6, 2,
                5, 4, 7, // back
                5, 7, 6,
                4, 0, 3, // left
                4, 3, 7,
                4, 5, 1, // up
                4, 1, 0,
                3, 2, 6, // down
                3, 6, 7,
            };

            this.indexBuffer = new IndexBuffer(this.graphicsDevice,
                                               IndexElementSize.SixteenBits,
                                               this.index.Length,
                                               BufferUsage.None);
            this.indexBuffer.SetData<short>(this.index);

            this.world = Matrix.Identity;

            this.position = position;

            this.angle = 0;

            //List<Vector3> boxVerts = new List<Vector3>();
            
            //foreach (VertexPositionColor v in  this.verts)
            //{
            //    boxVerts.Add(v.Position);
            //}

            //this.boundingBox = BoundingBox.CreateFromPoints(boxVerts);

            this.boundingBox = new BoundingBox();
            this.UpdateBoundingBox();

            Console.WriteLine(this.boundingBox.ToString());
        }

        public virtual void Update(GameTime gameTime)
        {
            //this.angle += gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationX(this.angle);
            this.world *= Matrix.CreateRotationY(this.angle);
            this.world *= Matrix.CreateTranslation(this.position);

            //this.UpdateBoundingBox();            
        }

        public virtual void Draw(ref BasicEffect effect, ref Matrix view, ref Matrix projection)
        {
            this.graphicsDevice.SetVertexBuffer(this.vertexBuffer);
            this.graphicsDevice.Indices = this.indexBuffer;

            RasterizerState rs = new RasterizerState(); 
            
            if (this.wireframe)
            {
                rs.CullMode = CullMode.None;
                rs.FillMode = FillMode.WireFrame;
            }
            else
            {
                rs.CullMode = CullMode.CullCounterClockwiseFace;
                rs.FillMode = FillMode.Solid;
            }
            
            this.graphicsDevice.RasterizerState = rs;
            
            effect.World = this.world;
            effect.View = view;
            effect.Projection = projection;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.graphicsDevice.DrawUserIndexedPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                    this.verts, 0, this.verts.Length, this.index, 0, this.index.Length / 3);
            }
        }

        protected void UpdateBoundingBox()
        {
            this.boundingBox.Min = this.position - Vector3.One;
            this.boundingBox.Max = this.position + Vector3.One;
        }

        public BoundingBox GetBoundingBox()
        {
            return this.boundingBox;
        }

        public void UseWireframe(bool use)
        {
            this.wireframe = use;
        }

        public bool IsWireframe()
        {
            return this.wireframe;
        }

    }
}
