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

        public GameObject()
        {
            World = Matrix.Identity;
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(Camera camera)
        { }
    }
}
