using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PresentationWorld
{
    class KinematicSphere : GameObject
    {
        public KinematicSphere(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Collider = ColliderType.BoundingSphere;
            Size = new Vector3(7, 7, 7);
        }
    }
}
