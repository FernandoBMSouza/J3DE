#define USE_TEXTURE
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo05
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
#if USE_TEXTURE
        protected Texture2D Texture { get; set; }
        protected Texture2D TextureWinter { get; set; }
        protected VertexPositionTexture[] Vertices { get; set; }
#else
        protected VertexPositionColor[] Vertices { get; set; }
#endif

        public GameObject(Game game)
        {
            this.game = game;
            Vertices = null;
            Texture = null;
            TextureWinter = null;

            if (Vertices != null)
            {
#if USE_TEXTURE
                buffer = new VertexBuffer(game.GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          Vertices.Length,
                                          BufferUsage.None);
                buffer.SetData<VertexPositionTexture>(Vertices);
#else
                buffer = new VertexBuffer(game.GraphicsDevice, 
                                          typeof(VertexPositionColor), 
                                          Vertices.Length, 
                                          BufferUsage.None);
                buffer.SetData<VertexPositionColor>(Vertices);
#endif
            }

            effect = game.Content.Load<Effect>(@"Effects\morphing");

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            Size = Vector3.One;
        }

        public virtual void Update(GameTime gameTime)
        { 
            
        }

        public void Draw(Camera camera, GameTime gameTime, bool showColliders = false)
        {
            Draw(camera, Matrix.Identity, gameTime, showColliders);
        }
        
        public virtual void Draw(Camera camera, Matrix parentWorld, GameTime gameTime, bool showColliders = false)
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
            
#if USE_TEXTURE
            effect.Parameters["normalTexture"].SetValue(Texture);
            effect.Parameters["winterTexture"].SetValue(TextureWinter);
            float gt = (float)(gameTime.TotalGameTime.TotalSeconds % 10) / 10;
            effect.Parameters["gameTime"].SetValue(gt);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
            }
            //effect.TextureEnabled = false;
#else
            effect.VertexColorEnabled = true;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (Vertices != null)
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                   Vertices,
                                                                   0,
                                                                   Vertices.Length / 3);
            }
            effect.VertexColorEnabled = false;
#endif

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
