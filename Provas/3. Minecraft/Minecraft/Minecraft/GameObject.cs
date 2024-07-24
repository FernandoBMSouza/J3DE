using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft
{
    public abstract class GameObject
    {
        private VertexBuffer buffer;
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

        public Effect effect { get; set; }
        public LineBox LBox { get; protected set; }
        public BoundingBox BBox { get; private set; }

        protected Texture2D Texture { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }

        public GameObject(Game game)
        {
            this.game = game;
            Vertices = null;
            Texture = null;

            effect = game.Content.Load<Effect>(@"Effects\Effect1");

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            Size = Vector3.One;

            if (Vertices != null)
            {
                buffer = new VertexBuffer(game.GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          Vertices.Length,
                                          BufferUsage.None);
                buffer.SetData<VertexPositionTexture>(Vertices);
            }
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

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(result);
            effect.Parameters["View"].SetValue(camera.View);
            effect.Parameters["Projection"].SetValue(camera.Projection);
            effect.Parameters["colorTexture"].SetValue(Texture);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
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
