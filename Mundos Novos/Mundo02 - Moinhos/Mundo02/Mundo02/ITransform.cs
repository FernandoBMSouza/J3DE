using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    interface ITransform
    {
        void Update(GameTime gameTime);
        void Draw(Camera camera);

        void SetIdentity();
        void Translation(Vector3 position, bool aux = false);
        void Scale(Vector3 scale, bool aux = false);
        void Rotation(char axis, float angle, bool aux = false);
    }
}
