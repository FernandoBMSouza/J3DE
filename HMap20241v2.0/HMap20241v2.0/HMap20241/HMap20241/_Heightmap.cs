using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HMap20241
{
    public class _Heightmap
    {
        Game game;
        Matrix world;
        VertexPositionNormalTexture[] verts;
        VertexBuffer vBuffer;
        int[] indexes;
        IndexBuffer iBuffer;
        Texture2D hmapTex, colorTex;
        int row, column;
        BasicEffect effect;
        Color[] color;

        // NORMALS
        VertexPositionColor[] normals;
        VertexBuffer normalVBuffer;
        BasicEffect normalEffect;

        public _Heightmap(Game game)
        {
            this.game = game;

            this.CreateMatrix();
            this.CreateVertex();
            this.CreateVBuffer();
            this.CreateIndexes();
            this.CreateIBuffer();
            this.CreateEffect();
            this.LoadTexture();
            this.RecalculateNormals();
            this.NormalizeNormals();

            // NORMALS
            this.CreateNormals();
            this.CreateNormalVBuffer();
        }

        private void CreateMatrix()
        {
            this.world = Matrix.Identity;
            //this.world *= Matrix.CreateScale(this.scale);
            //this.world *= Matrix.CreateTranslation(this.position);
        }

        private void CreateVertex()
        {
            this.LoadHeightmapTexture();
         
            this.row = 100;
            this.column = 100;

            this.verts = new VertexPositionNormalTexture[row * column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    float u = j / (float)(column - 1);
                    float v = i / (float)(row - 1);

                    int _u = (int)(u * (this.hmapTex.Width-1));
                    int _v = (int)(v * (this.hmapTex.Height-1));

                    float _h = this.color[_u * hmapTex.Width + _v].B / 10f;

                    verts[i * column + j] = new VertexPositionNormalTexture(
                                                        new Vector3(j - ((column-1)/2f), _h, i - ((row-1)/2f)),
                                                        new Vector3(0, 1, 0),
                                                        new Vector2(u, v));
                }
            }
        }

        private void CreateVBuffer()
        {
            this.vBuffer = new VertexBuffer(this.game.GraphicsDevice,
                                            typeof(VertexPositionNormalTexture),
                                            this.verts.Length,
                                            BufferUsage.None);
            this.vBuffer.SetData<VertexPositionNormalTexture>(this.verts);
        }

        private void CreateIndexes()
        {
            this.indexes = new int[(column - 1) * (row - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    indexes[k++] = i * column + j;
                    indexes[k++] = i * column + (j + 1);
                    indexes[k++] = (i + 1) * column + j;

                    indexes[k++] = i * column + (j + 1);
                    indexes[k++] = (i + 1) * column + (j + 1);
                    indexes[k++] = (i + 1) * column + j;
                }
            }
        }

        private void CreateIBuffer()
        {
            this.iBuffer = new IndexBuffer(this.game.GraphicsDevice,
                                           IndexElementSize.ThirtyTwoBits,
                                           this.indexes.Length,
                                           BufferUsage.None);
            this.iBuffer.SetData<int>(this.indexes);
        }

        private void CreateEffect()
        {
            this.effect = new BasicEffect(this.game.GraphicsDevice);

            this.normalEffect = new BasicEffect(this.game.GraphicsDevice);
        }

        private void LoadTexture()
        {
            this.colorTex = this.game.Content.Load<Texture2D>(@"Textures\hm");
        }

        private void LoadHeightmapTexture()
        {
            this.hmapTex = this.game.Content.Load<Texture2D>(@"Textures\hm");

            this.color = new Color[hmapTex.Width * hmapTex.Height];

            hmapTex.GetData<Color>(this.color);
        }

        public void Update(GameTime gt)
        {
            this.world *= Matrix.CreateRotationY(0.001f);
        }

        public void Draw(_Camera camera)
        {
            effect.World = this.world;
            effect.View = camera.GetView();
            effect.Projection = camera.GetProjection();

            effect.TextureEnabled = true;
            effect.Texture = colorTex;

            //effect.EnableDefaultLighting();
            //effect.AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f);
            //effect.DiffuseColor = new Vector3(1, 1, 1);
            //effect.SpecularColor = new Vector3(1,1,0);
            //effect.SpecularPower = 10;
            effect.FogEnabled = true;
            effect.FogStart = 60;
            effect.FogEnd = 90;
            effect.FogColor = Color.CornflowerBlue.ToVector3();

            this.game.GraphicsDevice.SetVertexBuffer(this.vBuffer);
            this.game.GraphicsDevice.Indices = this.iBuffer;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.game.GraphicsDevice.DrawUserIndexedPrimitives
                    <VertexPositionNormalTexture>(PrimitiveType.TriangleList,
                                                  this.verts,
                                                  0,
                                                  this.verts.Length,
                                                  this.indexes,
                                                  0,
                                                  this.indexes.Length / 3);
            }

            this.DrawNormals(camera);
        }

        private void CreateNormals()
        {
            this.normals = new VertexPositionColor[row * column * 2];

            int k = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    this.normals[k++] = new VertexPositionColor(this.verts[i * column + j].Position, Color.YellowGreen);
                    this.normals[k++] = new VertexPositionColor(this.verts[i * column + j].Position + 
                                                                this.verts[i * column + j].Normal, Color.YellowGreen);
                }
            }
        }

        private void CreateNormalVBuffer()
        {
            this.normalVBuffer = new VertexBuffer(this.game.GraphicsDevice,
                                                  typeof(VertexPositionColor),
                                                  this.normals.Length,
                                                  BufferUsage.None);
            this.normalVBuffer.SetData<VertexPositionColor>(this.normals);
        }
        
        private void RecalculateNormals()
        {
            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column - 1; j++)
                {
                    for (int l = 0; l < 2; l++)
                    {
                        Vector3 v0 = verts[indexes[k++]].Position;
                        Vector3 v1 = verts[indexes[k++]].Position;
                        Vector3 v2 = verts[indexes[k++]].Position;
                        Vector3 cross = Vector3.Cross(v1 - v0, v1 - v2);
                        k -= 3;
                        verts[indexes[k++]].Normal += cross;
                        verts[indexes[k++]].Normal += cross;
                        verts[indexes[k++]].Normal += cross;
                    }
                }
            }
        }

        private void NormalizeNormals()
        {
            for (int i = 0; i < verts.Length; i++)
            {
                verts[i].Normal.Normalize();
            }
        }

        private void DrawNormals(_Camera camera)
        {
            normalEffect.World = this.world;
            normalEffect.View = camera.GetView();
            normalEffect.Projection = camera.GetProjection();

            normalEffect.VertexColorEnabled = true;

            this.game.GraphicsDevice.SetVertexBuffer(this.normalVBuffer);

            foreach (EffectPass pass in normalEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.game.GraphicsDevice.DrawUserPrimitives
                    <VertexPositionColor>(PrimitiveType.LineList,
                                          this.normals,
                                          0,
                                          this.normals.Length / 2);
            }
        }
    }
}