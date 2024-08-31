using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helicopter
{
    abstract class GameObject
    {
        public Matrix World { get; set; }
        public GameObject[] Children { get; set; }

        public GameObject()
        {
            World = Matrix.Identity;
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
                foreach(GameObject child in Children)
                    child.Draw(camera);
            }
        }
    }
}
