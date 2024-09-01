using Microsoft.Xna.Framework;
using Mundo01.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Mundo01.GameObjects.Primitives;

namespace Mundo01.GameObjects
{
    abstract class GameObject
    {
        public Matrix World { get; set; }
        public GameObject[] Children { get; set; }
        public Vector3 Size { get; set; }

        public LineBox ColliderLines { get; protected set; }
        public BoundingBox Collider { get; private set; }
        protected BasicEffect effect;
        Game1 game;

        Vector3 previousPosition;
        Vector3 previousScale;
        Vector3 previousSize;

        public bool Visible { get; set; }

        public GameObject(Game1 game)
        {
            this.game = game;
            effect = new BasicEffect(game.GraphicsDevice);
            Size = Vector3.One;

            Visible = true;

            World = Matrix.Identity;

            previousPosition = GetPosition();
            previousScale = GetScale();

            UpdateCollider();
        }

        public virtual void Update(GameTime gameTime)
        {
            if (Children != null)
            {
                foreach (GameObject child in Children)
                {
                    child.Visible = false;
                }
            }

            Vector3 currentPosition = GetPosition();
            Vector3 currentScale = GetScale();
            Vector3 currentSize = Size;

            if (currentPosition != previousPosition || currentScale != previousScale || currentSize != previousSize)
            {
                UpdateCollider();
                previousPosition = currentPosition;
                previousScale = currentScale;
                previousSize = currentSize;
            }
        }

        public virtual void Draw(Camera camera)
        {
            if (Children != null)
            {
                foreach (GameObject child in Children)
                    child.Draw(camera);
            }

            if (Visible) ColliderLines.Draw(effect, camera);
        }

        public Vector3 GetPosition()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return translation;
        }

        public Vector3 GetRotation()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return new Vector3(rotation.ToEulerAngles().X, rotation.ToEulerAngles().Y, rotation.ToEulerAngles().Z);
        }

        public Vector3 GetScale()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return scale;
        }

        public void UpdateCollider()
        {
            Vector3 position = GetPosition();
            Vector3 scale = GetScale();
            Vector3 dimension = scale * Size;

            ColliderLines = new LineBox(game, position, scale, Size, Color.Green);
            Collider = new BoundingBox(position - (dimension / 2f),
                                       position + (dimension / 2f));
        }

        public bool IsColliding(GameObject other)
        {
            return Collider.Intersects(other.Collider);         
        }

        public void SetColliderColor(Color color)
        {
            if (Visible) ColliderLines.SetColor(color);
        }
    }
}
