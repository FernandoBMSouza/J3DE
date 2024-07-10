﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    interface ICollider
    {
        BoundingBox BBox { get; }
        void UpdateBoundingBox();
        bool IsColliding(BoundingBox other);
        void SetColliderColor(Color color);
    }
}
