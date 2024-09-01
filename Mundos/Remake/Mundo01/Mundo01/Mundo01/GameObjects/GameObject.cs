using Microsoft.Xna.Framework;
using Mundo01.Utilities;

namespace Mundo01.GameObjects
{
    abstract class GameObject
    {
        public Matrix World { get; set; }
        public GameObject[] Children { get; set; }
        public Vector3 Size { get; set; }

        public GameObject()
        {
            World = Matrix.Identity;
            Size = Vector3.One;
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
        }

        public virtual void Draw(Camera camera)
        {
            if (Children != null)
            {
                foreach (GameObject child in Children)
                    child.Draw(camera);
            }
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

    }
}
