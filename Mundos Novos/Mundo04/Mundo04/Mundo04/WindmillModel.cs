using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    public class WindmillModel : ICollider
    {

        public BoundingBox BBox
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsColliding(BoundingBox other)
        {
            throw new NotImplementedException();
        }

        public void SetColliderColor(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
