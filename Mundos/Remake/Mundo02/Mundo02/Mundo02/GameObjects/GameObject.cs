using Microsoft.Xna.Framework;
using Mundo02.Utilities;

namespace Mundo02.GameObjects
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
    }
}
