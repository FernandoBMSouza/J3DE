using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo01
{
    interface ITransform
    {
        void Update(GameTime gameTime);
        void Draw(Camera camera);

        void SetIdentity();
        void Translation(Vector3 position);
        void Scale(Vector3 scale);
        void RotationX(float angle);
        void RotationY(float angle);
        void RotationZ(float angle);
    }
}
