using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public class _Gnomo : _NPC
    {
        Game game;
        Matrix world;
        Vector3 position;
        VertexPositionColor[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        float angle, speedRotY;
        static Random r = new Random();

        public _Gnomo(Game game, Vector3 position, Vector3 dimension, Color color, bool visible)
            : base(game, position, dimension, color, visible)
        {
            this.game = game;

            this.position = new Vector3(0,1,0);

            int aux = r.Next(100);
            if (aux < 33)
            {
                this.speedRotY = 10;
            }
            else if (aux < 66)
            {
                this.speedRotY = -10;
            }
            else
            {
                this.speedRotY = 0;
            }

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
            this.world *= base.world;
        }

        private void CreateVertex()
        {
            float v = 1.1f;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(0,v * 2,0), Color.Red),//0

                new VertexPositionColor(new Vector3(-v,0,-v), Color.Red),//1
                new VertexPositionColor(new Vector3( v,0,-v), Color.Red),//2
                new VertexPositionColor(new Vector3(-v,0, v), Color.Red),//3
                new VertexPositionColor(new Vector3( v,0, v), Color.Red),//4
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
                // baixo
                3, 4, 1,
                4, 2, 1,

                // front
                0, 4, 3,

                // right
                0, 2, 4,

                // back
                0, 1, 2,

                // left
                0, 3, 1,
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

        public override void Update(GameTime gt)
        {
            angle += speedRotY * gt.ElapsedGameTime.Milliseconds * 0.001f;

            this.CreateMatrix();

            base.Update(gt);
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
