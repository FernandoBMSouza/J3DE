using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    interface ICollider
    {
        LineBox LBox { get; }
        BoundingBox BBox { get; }
        void UpdateBoundingBox();
        bool IsColliding(BoundingBox other);
    }
}
