using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PresentationWorld
{
    public enum ColliderType
    {
        BoundingBox,
        BoundingSphere
    }

    public abstract class GameObject
    {
        private GraphicsDevice device;
        private VertexBuffer buffer;
        protected BasicEffect effect;
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
                if(Collider == ColliderType.BoundingBox) LBox = new LineBox(game, size / scale, Color.Green);
                else if (Collider == ColliderType.BoundingSphere)
                {
                    Vector3 realSize = new Vector3(size.X, size.Y, size.Z) / scale;
                    float radius = Math.Max(realSize.X, Math.Max(realSize.Y, realSize.Z)) / 2f;

                    LSphere = new LineSphere(game, radius, Color.Green);
                }
                
                UpdateCollider();
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
                UpdateCollider();
            }
        }
        public Vector3 Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                UpdateCollider();                                      
            }
        }
        public Vector3 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                Size *= scale;
                UpdateCollider();
            }
        }

        public LineBox LBox { get; protected set; }
        public LineSphere LSphere { get; protected set; }
        public BoundingBox BBox { get; private set; }
        public BoundingSphere BSphere { get; private set; }
        protected Model Model { get; set; }
        protected Texture2D Texture { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }

        public ColliderType Collider { get; set; }

        public GameObject(Game game, GraphicsDevice device)
        {
            this.game = game;
            this.device = device;
            Vertices = null;
            Texture = null;
            Model = null;
            Collider = ColliderType.BoundingBox;

            if (Vertices != null)
            {
                buffer = new VertexBuffer(device,
                                          typeof(VertexPositionTexture),
                                          Vertices.Length,
                                          BufferUsage.None);
                buffer.SetData<VertexPositionTexture>(Vertices);
            }

            effect = new BasicEffect(device);

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
                device.SetVertexBuffer(buffer);

            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;
            effect.World = result;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

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

            if (Model != null)
            {
                foreach (ModelMesh mesh in Model.Meshes)
                {
                    foreach (BasicEffect be in mesh.Effects)
                    {
                        //be.EnableDefaultLighting();
                        be.World = localMatrix * parentWorld;
                        be.View = camera.View;
                        be.Projection = camera.Projection;
                        be.TextureEnabled = true;
                        be.Texture = Texture;
                    }
                    mesh.Draw();
                }
            }
            if (showColliders)
            {
                if (Collider == ColliderType.BoundingBox)
                {
                    LBox.Draw(effect);
                }
                else if (Collider == ColliderType.BoundingSphere)
                {
                    LSphere.Draw(effect);
                }
            }
        }

        private void UpdateCollider()
        {
            if (Collider == ColliderType.BoundingBox)
            {
                BBox = new BoundingBox(Position - (Size / 2f),
                                       Position + (Size / 2f));
            }
            else if (Collider == ColliderType.BoundingSphere)
            {
                float radius = Math.Max(Size.X, Math.Max(Size.Y, Size.Z)) / 2f;                
                BSphere = new BoundingSphere(Position, radius);
            }
        }

        public virtual bool IsColliding(GameObject other)
        {
            if (Collider == ColliderType.BoundingBox)
            {
                if (other.Collider == ColliderType.BoundingBox)
                {
                    return BBox.Intersects(other.BBox);
                }
                else if (other.Collider == ColliderType.BoundingSphere)
                {
                    return BBox.Intersects(other.BSphere);
                }
            }
            else if (Collider == ColliderType.BoundingSphere)
            {
                if (other.Collider == ColliderType.BoundingBox)
                {
                    return BSphere.Intersects(other.BBox);
                }
                else if (other.Collider == ColliderType.BoundingSphere)
                {
                    return BSphere.Intersects(other.BSphere);
                }
            }
            return false;
        }

        public void SetColliderColor(Color color)
        {
            if (Collider == ColliderType.BoundingBox)
            {
                LBox.SetColor(color);
            }
            else if (Collider == ColliderType.BoundingSphere)
            {
                LSphere.SetColor(color);
            }
        }
    }
}
