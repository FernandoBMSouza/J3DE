using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    interface ICollider
    {
        BoundingBox BBox { get; }
        bool IsColliding(BoundingBox other);
        void SetColliderColor(Color color);
    }
}
