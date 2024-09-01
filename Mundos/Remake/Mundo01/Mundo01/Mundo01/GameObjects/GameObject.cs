using Microsoft.Xna.Framework;
using Mundo01.Utilities;
using Mundo01.Utilities.Collision;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Mundo01.GameObjects
{
    abstract class GameObject
    {
        public Matrix World { get; set; }
        public GameObject[] Children { get; set; }
        public Vector3 Size { get; set; }

        public LineBox LineBox { get; protected set; }
        public BoundingBox BoundingBox { get; private set; }
        bool visible;
        protected BasicEffect effect;
        Game1 game;

        Vector3 previousPosition;
        Vector3 previousScale;
        Vector3 previousSize;

        public GameObject(Game1 game)
        {
            this.game = game;
            visible = true;
            effect = new BasicEffect(game.GraphicsDevice);
            Size = Vector3.One;

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
                    child.Update(gameTime);
                    child.World *= World;
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

            if (visible) LineBox.Draw(effect);
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
            Debug.WriteLine("Dimension: " + GetScale() * Size);
            LineBox = new LineBox(game, Size, Color.Green);
            BoundingBox = new BoundingBox(GetPosition() - ((GetScale() * Size) / 2f),
                                          GetPosition() + ((GetScale() * Size) / 2f));
        }

        public bool IsColliding(GameObject other)
        {
            return BoundingBox.Intersects(other.BoundingBox);
        }

        public void SetColliderColor(Color color)
        {
            LineBox.SetColor(color);
        }

    }
}
