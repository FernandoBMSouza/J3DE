using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public class _Cube : _Collider
    {
        Game game;
        protected Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        protected float angle;

        public _Cube(Game game, Vector3 position, Vector3 dimension,
                     Color color, bool visible)
            : base(game, position, dimension, color, visible)
        {
            this.game = game;

            this.CreateMatrix();
            this.CreateVertex();
            this.CreateVBuffer();
            this.CreateIndexes();
            this.CreateIBuffer();
        }

        private void CreateMatrix()
        {
            this.world = Matrix.Identity;
            //this.world *= Matrix.CreateScale(this.scale);
            this.world *= Matrix.CreateRotationY(this.angle);
            this.world *= Matrix.CreateTranslation(this.position);
        }

        private void CreateVertex()
        {
            float v = 1;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-v, v,-v), Color.Red),//0
                new VertexPositionColor(new Vector3( v, v,-v), Color.Green),//1
                new VertexPositionColor(new Vector3(-v, v, v), Color.Blue),//2
                new VertexPositionColor(new Vector3( v, v, v), Color.Yellow),//3

                new VertexPositionColor(new Vector3(-v,-v,-v), Color.Red),//4
                new VertexPositionColor(new Vector3( v,-v,-v), Color.Green),//5
                new VertexPositionColor(new Vector3(-v,-v, v), Color.Blue),//6
                new VertexPositionColor(new Vector3( v,-v, v), Color.Yellow),//7
            };
        }

        private void CreateVBuffer()
        {
            this.vBuffer = new VertexBuffer(this.game.GraphicsDevice,
                                            typeof(VertexPositionColor),
                                            this.verts.Length,
                                            BufferUsage.None);
            this.vBuffer.SetData<VertexPositionColor>(this.verts);
        }

        private void CreateIndexes()
        {
            this.indexes = new short[]
            {
                // cima
                0, 1, 3,
                0, 3, 2,

                // baixo
                6, 7, 5,
                6, 5, 4,

                // front
                2, 3, 7,
                2, 7, 6,

                // right
                3, 1, 5,
                3, 5, 7,

                // back
                1, 0, 4,
                1, 4, 5,

                // left
                0, 2, 6,
                0, 6, 4,
            };
        }

        private void CreateIBuffer()
        {
            this.iBuffer = new IndexBuffer(this.game.GraphicsDevice,
                                           IndexElementSize.SixteenBits,
                                           this.indexes.Length,
                                           BufferUsage.None);
            this.iBuffer.SetData<short>(this.indexes);
        }

        public virtual void Update(GameTime gt)
        {
            //this.angle += 0.01f;
            this.CreateMatrix();
        }

        public override void Draw(BasicEffect e)
        {
            e.World = this.world;
            e.VertexColorEnabled = true;

            this.game.GraphicsDevice.SetVertexBuffer(this.vBuffer);
            this.game.GraphicsDevice.Indices = this.iBuffer;

            foreach (EffectPass pass in e.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionColor>(PrimitiveType.TriangleList,
                                          this.verts,
                                          0,
                                          this.verts.Length,
                                          this.indexes,
                                          0,
                                          this.indexes.Length / 3);
            }
            e.VertexColorEnabled = false;

            base.Draw(e);
        }
    }
}
