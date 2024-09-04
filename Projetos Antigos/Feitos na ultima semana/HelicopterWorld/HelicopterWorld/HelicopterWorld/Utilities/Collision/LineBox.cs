using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HelicopterWorld.Utilities.Collision
{
    public class LineBox
    {
        Matrix world;
        Vector3 position, scale;
        VertexPositionColor[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        Color color;
        Game game;

        public LineBox(Game game, Vector3 position, Vector3 scale, Vector3 size, Color color)
        {
            this.game = game;
            this.position = position;
            this.scale = scale;
            this.color = color;

            CreateMatrix();
            CreateVertex(size);
            CreateVBuffer();
            CreateIndexes();
            CreateIBuffer();
        }

        private void CreateMatrix()
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateScale(this.scale);
            this.world *= Matrix.CreateTranslation(this.position);
        }

        private void CreateVertex(Vector3 size)
        {
            Vector3 v = size / 2f;

            this.verts = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(-v.X, v.Y,-v.Z), this.color),//0
                new VertexPositionColor(new Vector3( v.X, v.Y,-v.Z), this.color),//1
                new VertexPositionColor(new Vector3(-v.X, v.Y, v.Z), this.color),//2
                new VertexPositionColor(new Vector3( v.X, v.Y, v.Z), this.color),//3

                new VertexPositionColor(new Vector3(-v.X,-v.Y,-v.Z), this.color),//4
                new VertexPositionColor(new Vector3( v.X,-v.Y,-v.Z), this.color),//5
                new VertexPositionColor(new Vector3(-v.X,-v.Y, v.Z), this.color),//6
                new VertexPositionColor(new Vector3( v.X,-v.Y, v.Z), this.color),//7
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
                0, 1,
                1, 3,
                3, 2,
                2, 0,

                // baixo
                4, 5,
                5, 7,
                7, 6,
                6, 4,

                // vertical
                0, 4,
                1, 5,
                2, 6,
                3, 7
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

        public void Draw(BasicEffect e, Camera camera)
        {
            e.World = this.world;
            e.World = world;
            e.View = camera.View;
            e.Projection = camera.Projection;

            e.VertexColorEnabled = true;

            this.game.GraphicsDevice.SetVertexBuffer(this.vBuffer);
            this.game.GraphicsDevice.Indices = this.iBuffer;

            foreach (EffectPass pass in e.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionColor>(PrimitiveType.LineList,
                                          this.verts,
                                          0,
                                          this.verts.Length,
                                          this.indexes,
                                          0,
                                          this.indexes.Length / 2);
            }
            e.VertexColorEnabled = false;
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
            this.CreateMatrix();
        }

        public void SetScale(Vector3 scale)
        {
            this.scale = scale;
            this.CreateMatrix();
        }

        public void SetColor(Color color)
        {
            this.color = color;

            for (int i = 0; i < this.verts.Length; i++)
            {
                this.verts[i].Color = this.color;
            }
        }

    }
}
