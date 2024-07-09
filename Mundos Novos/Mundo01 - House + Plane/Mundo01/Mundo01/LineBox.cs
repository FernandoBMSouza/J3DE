using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01
{
    public class LineBox
    {
        Matrix worldScale;
        Matrix worldRotation;
        Matrix worldTranslation;
        Vector3 position;
        public Vector3 scale;
        Vector3 angle;
        VertexPositionColor[] vertices;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        Color color;
        Game game;

        public LineBox(Game game, Vector3 position, Vector3 scale, Vector3 angle, Color color)
        {
            this.game = game;
            this.position = position;
            this.scale = scale;
            this.angle = angle;
            this.color = color;

            SetIdentity();
            CreateVertex();
            CreateVBuffer();
            CreateIndexes();
            CreateIBuffer();
        }

        private void CreateVertex()
        {
            //float v = .5f;
            Vector3 v = scale/2;
            vertices = new VertexPositionColor[]
            {
                //SUPERIOR
                new VertexPositionColor(new Vector3(-v.X, v.Y,-v.Z), color), //0 - ESQUERDA E TRASEIRA
                new VertexPositionColor(new Vector3( v.X, v.Y,-v.Z), color), //1 - DIREITA  E TRASEIRA
                new VertexPositionColor(new Vector3(-v.X, v.Y, v.Z), color), //2 - ESQUERDA E FRENTE
                new VertexPositionColor(new Vector3( v.X, v.Y, v.Z), color), //3 - DIREITA  E FRENTE
                //INFERIOR
                new VertexPositionColor(new Vector3(-v.X,-v.Y,-v.Z), color), //4 - ESQUERDA E TRASEIRA
                new VertexPositionColor(new Vector3( v.X,-v.Y,-v.Z), color), //5 - DIREITA  E TRASEIRA
                new VertexPositionColor(new Vector3(-v.X,-v.Y, v.Z), color), //6 - ESQUERDA E FRENTE
                new VertexPositionColor(new Vector3( v.X,-v.Y, v.Z), color), //7 - DIREITA  E FRENTE
            };
        }

        private void CreateVBuffer()
        {
            vBuffer = new VertexBuffer(game.GraphicsDevice,
                                       typeof(VertexPositionColor),
                                       vertices.Length,
                                       BufferUsage.None);
            vBuffer.SetData<VertexPositionColor>(vertices);
        }

        private void CreateIndexes()
        {
            indexes = new short[] 
            { 
                //OS NUMEROS AQUI SAO OS MESMOS CRIADOS NO METODO CREATEVERTEX
                //SUPERIOR
                0, 1,
                1, 3,
                3, 2,
                2, 0,

                //INFERIOR
                4, 5,
                5, 7,
                7, 6,
                6, 4,

                //VERTICAL
                0, 4,
                1, 5,
                2, 6,
                3, 7,
            };
        }

        private void CreateIBuffer()
        {
            iBuffer = new IndexBuffer(game.GraphicsDevice,
                                      IndexElementSize.SixteenBits,
                                      indexes.Length,
                                      BufferUsage.None);
            iBuffer.SetData<short>(indexes);
        }

        public void Draw(BasicEffect e)
        {
            e.World = worldScale * worldRotation * worldTranslation;
            e.VertexColorEnabled = true;
            game.GraphicsDevice.SetVertexBuffer(vBuffer);
            game.GraphicsDevice.Indices = iBuffer;

            foreach (EffectPass pass in e.CurrentTechnique.Passes)
            {
                pass.Apply();
                game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionColor>(PrimitiveType.LineList,
                                          vertices,
                                          0,
                                          vertices.Length,
                                          indexes,
                                          0,
                                          indexes.Length / 2);

            }
            e.VertexColorEnabled = false;
        }

        public void SetIdentity()
        {
            position = Vector3.Zero;
            angle = Vector3.Zero;
            scale = Vector3.One;

            worldScale = Matrix.Identity;
            worldRotation = Matrix.Identity;
            worldTranslation = Matrix.Identity;
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
            worldTranslation *= Matrix.CreateTranslation(position);
        }

        public void SetScale(Vector3 scale)
        {
            this.scale = scale;
            worldScale = Matrix.CreateScale(scale);
        }

        public void SetAngleX(float angle)
        {
            this.angle.X = angle;
            worldRotation *= Matrix.CreateRotationX(angle);
        }

        public void SetAngleY(float angle)
        {
            this.angle.Y = angle;
            worldRotation *= Matrix.CreateRotationY(angle);
        }

        public void SetAngleZ(float angle)
        {
            this.angle.Z = angle;
            worldRotation *= Matrix.CreateRotationZ(angle);
        }

        public void SetColor(Color color)
        {
            this.color = color;
            for (int i = 0; i < vertices.Length; i++)
                vertices[i].Color = this.color;
        }
    }
}
