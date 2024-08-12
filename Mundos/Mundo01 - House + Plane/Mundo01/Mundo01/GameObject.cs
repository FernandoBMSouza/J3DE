using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01
{
    public abstract class GameObject
    {
        // ATRIBUTOS
        private Game game;
        private Vector3 size;
        private Vector3 scale;
        private Vector3 position;
        private Vector3 rotation;
        private BoundingBox boundingBox;
        private BasicEffect effect;
        private VertexBuffer buffer;

        protected LineBox lineBox;
        protected VertexPositionColor[] vertices;

        // CONSTRUTORES
        public GameObject(Game game)
        {
            this.game = game;
            InitializeBuffer();
            scale = Vector3.One;
            effect = new BasicEffect(game.GraphicsDevice);
        }

        // GETTERS E SETTERS
        public Vector3 GetSize() { return size; }
        public Vector3 GetPosition() { return position; }
        public Vector3 GetScale() { return scale; }
        public Vector3 GetRotation() { return rotation; }
        public BoundingBox GetBoundingBox() { return boundingBox; }

        public void SetSize(Vector3 value) 
        {
            size = value;
            lineBox = new LineBox(game, size/scale, Color.Green);
            UpdateBoundingBox(position, size);
        }
        public void SetPosition(Vector3 value)
        {
            position = value;
            UpdateBoundingBox(position, size);
        }
        public void SetRotation(Vector3 value)
        {
            rotation = value;
            UpdateBoundingBox(position, size);
        }
        public void SetScale(Vector3 value)
        {
            scale = value;
            SetSize(size * scale);
        }
        
        // METODOS
        private void InitializeBuffer()
        {
            if (vertices != null)
            {
                buffer = new VertexBuffer(game.GraphicsDevice,
                                          typeof(VertexPositionColor),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(vertices);
            }
        }
        private Matrix GenerateMatrix(Matrix parentWorld)
        {
            Matrix localMatrix = Matrix.CreateScale(scale)
                                 * Matrix.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z)
                                 * Matrix.CreateTranslation(position);

            return localMatrix * parentWorld;
        }

        public void UpdateBoundingBox(Vector3 position, Vector3 size)
        {
            boundingBox = new BoundingBox(position - (size / 2f),
                                   position + (size / 2f));
        }
        public void SetColliderColor(Color color)
        {
            lineBox.SetColor(color);
        }
        public bool IsColliding(BoundingBox other)
        {
            return boundingBox.Intersects(other);
        }
        
        public virtual void Update(GameTime gameTime)
        { 
            
        }
        public virtual void Draw(Camera camera, Matrix parentWorld, bool showColliders = false)
        {
            if (vertices != null) game.GraphicsDevice.SetVertexBuffer(buffer);
            
            effect.World = GenerateMatrix(parentWorld);
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                if (vertices != null)
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                                vertices,
                                                                                0,
                                                                                vertices.Length / 3);
            }
            effect.VertexColorEnabled = false;

            if (showColliders) lineBox.Draw(effect);
        }
        public void Draw(Camera camera, bool showColliders = false)
        {
            Draw(camera, Matrix.Identity, showColliders);
        }
    }
}
