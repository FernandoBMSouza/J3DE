using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo02
{
    public abstract class GameObject
    {
        private GraphicsDevice device;
        private VertexBuffer buffer;
        private BasicEffect effect;
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
                UpdateBoundingBox();
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
                UpdateBoundingBox();
            }
        }
        public Vector3 Rotation
        {
            get { return rotation; }
            set
            {
                rotation = value;
                rotation = new Vector3(MathHelper.ToRadians(rotation.X),
                                       MathHelper.ToRadians(rotation.Y),
                                       MathHelper.ToRadians(rotation.Z));
                                                        
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
        protected VertexPositionColor[] Vertices { get; set; }

        public GameObject(Game game, GraphicsDevice device)
        {
            this.game = game;
            this.device = device;
            Vertices = null;

            if (Vertices != null)
            {
                buffer = new VertexBuffer(device,
                                          typeof(VertexPositionColor),
                                          Vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(Vertices);
            }

            effect = new BasicEffect(device);

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            Size = Vector3.One;
            LBox = new LineBox(game, Size, Color.Green);
        }

        public void Update(GameTime gameTime) 
        {
            
        }

        public void Draw(Camera camera)
        {
            if (Vertices != null)
                device.SetVertexBuffer(buffer);

            effect.World = Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z) *
                           Matrix.CreateScale(Scale) *
                           Matrix.CreateTranslation(Position);

            effect.View = camera.View;
            effect.Projection = camera.Projection;

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
            }
            LBox.Draw(effect);
        }

        public void UpdateBoundingBox()
        {
            BBox = new BoundingBox(Position - (Size / 2f),
                                   Position + (Size / 2f));
        }

        public bool IsColliding(BoundingBox other)
        {
            return BBox.Intersects(other);
        }
    }
}
