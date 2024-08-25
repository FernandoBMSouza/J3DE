using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Effects
{
    public abstract class GameObject
    {
        private VertexBuffer buffer;
        protected Effect effect;
        private Game game;

        private Vector3 size;
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        public Vector3 Size
        {
            get { return size; }
            protected set 
            {
                size = value;
                LBox = new LineBox(game, size/scale, Color.Green);
                UpdateBoundingBox(Position, size);
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
                UpdateBoundingBox(position, Size);
            }
        }
        public Vector3 Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                UpdateBoundingBox(Position, Size);                                      
            }
        }
        public Vector3 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                Size *= scale;
            }
        }

        public LineBox LBox { get; protected set; }
        public BoundingBox BBox { get; private set; }
        protected Model Model { get; set; }
        protected Texture2D Texture { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }

        public GameObject(Game game)
        {
            this.game = game;
            Vertices = null;
            Texture = null;
            Model = null;

            if (Vertices != null)
            {
                buffer = new VertexBuffer(game.GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          Vertices.Length,
                                          BufferUsage.None);
                buffer.SetData<VertexPositionTexture>(Vertices);
            }

            effect = game.Content.Load<Effect>(@"Effects\Ambient");

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            Size = Vector3.One;
        }

        public virtual void Update(GameTime gameTime)
        { 
            
        }

        public void Draw(Camera camera, bool showColliders = false)
        {
            Draw(camera, Matrix.Identity, showColliders);
        }
        
        public virtual void Draw(Camera camera, Matrix parentWorld, bool showColliders = false)
        {
            if (Vertices != null)
                game.GraphicsDevice.SetVertexBuffer(buffer);

            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;

            //effect.World = result;
            //effect.View = camera.View;
            //effect.Projection = camera.Projection;
            //effect.TextureEnabled = true;
            //effect.Texture = Texture;

            //foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();
            //    if (Vertices != null)
            //        game.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
            //                                                       Vertices,
            //                                                       0,
            //                                                       Vertices.Length / 3);
            //}
            //effect.TextureEnabled = false;

            if (Model != null)
            {
                //foreach (ModelMesh mesh in Model.Meshes)
                //{
                //    foreach (BasicEffect be in mesh.Effects)
                //    {
                //        be.EnableDefaultLighting();
                //        be.PreferPerPixelLighting = true;
                //        be.World = localMatrix * parentWorld;
                //        be.View = camera.View;
                //        be.Projection = camera.Projection;
                //    }
                //    mesh.Draw();
                //}

                foreach (ModelMesh mesh in Model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = effect;
                        effect.Parameters["World"].SetValue(result);
                        effect.Parameters["View"].SetValue(camera.View);
                        effect.Parameters["Projection"].SetValue(camera.Projection);
                        //effect.Parameters["AmbientColor"].SetValue(Color.Green.ToVector4());
                        //effect.Parameters["AmbientIntensity"].SetValue(0.5f);
                    }
                    mesh.Draw();
                }
            }
            if (showColliders) LBox.Draw(result, camera);
        }

        public void UpdateBoundingBox(Vector3 position, Vector3 size)
        {
            BBox = new BoundingBox(position - (size / 2f),
                                   position + (size / 2f));
        }

        public bool IsColliding(BoundingBox other)
        {
            return BBox.Intersects(other);
        }

        public void SetColliderColor(Color color)
        {
            LBox.SetColor(color);
        }
    }
}
